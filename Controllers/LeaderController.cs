using SdaTithe.Data;
using SdaTithe.Models;
using SdaTithe.Services;
namespace SdaTithe.Controllers;

public class LeaderController
{
    private readonly UserRepository _users = new();
    private readonly ChurchRepository _churches = new();
    private readonly PaymentRepository _payments = new();

    // Every method goes through Me, so a Member can never use this controller (FR8).
    private User Me
    {
        get
        {
            var u = Session.Current ?? throw new InvalidOperationException("Not logged in.");
            if (u.Role == Role.Member) throw new UnauthorizedAccessException("Managers only.");
            return u;
        }
    }

    public bool IsAdmin => Me.Role == Role.Admin;

    // Leader: always their own church. Admin: the church asked for (null = all).
    private int? Scope(int? requested) => IsAdmin ? requested : Me.ChurchId;

    private bool InScope(int? churchId) => IsAdmin || churchId == Me.ChurchId;

    public List<Church> GetChurchChoices()
    {
        var all = _churches.GetAll();
        return IsAdmin ? all : all.Where(c => c.Id == Me.ChurchId).ToList();
    }

    public List<User> GetMembers(int? churchId, string search) =>
        _users.SearchMembers(Scope(churchId), (search ?? "").Trim());

    public string? AddMember(string name, string phone, int? churchId)
    {
        int? church = Scope(churchId);
        if (church == null) return "Choose a church first.";

        phone = phone.Trim();
        var error = Validator.Member(name, phone, _users.PhoneExists(phone));
        if (error != null) return error;

        _users.Add(new User
        {
            FullName = name.Trim(),
            Phone = phone,
            PasswordHash = "!",          // no password: this member cannot log in
            Role = Role.Member,
            ChurchId = church,
            HasAccount = false
        });
        return null;
    }

    public string? DeleteMember(int memberId)
    {
        var m = _users.FindById(memberId);
        if (m == null || m.Role != Role.Member) return "Member not found.";
        if (!InScope(m.ChurchId)) return "You can only manage members of your own church.";
        _users.Delete(memberId);
        return null;
    }

    public (Payment? payment, string? error) RecordCash(int memberId, string amountText, DateTime date)
    {
        var m = _users.FindById(memberId);
        if (m == null || m.Role != Role.Member || m.ChurchId == null)
            return (null, "Member not found.");
        if (!InScope(m.ChurchId))
            return (null, "You can only manage members of your own church.");

        if (!int.TryParse(amountText.Trim(), out int amount))
            return (null, "Enter a valid amount in numbers.");
        var err = Validator.Amount(amount);
        if (err != null) return (null, err);
        if (date.Date > DateTime.Today) return (null, "The date cannot be in the future.");

        var id = _payments.Add(new Payment
        {
            MemberId = m.Id,
            ChurchId = m.ChurchId.Value,
            Amount = amount,
            PaidOn = date.Date,
            Method = "Cash",
            ReceivedById = Me.Id
        });
        return (_payments.GetById(id), null);
    }

    // The leader or admin paying their own tithe.
    public (Payment? payment, string? error) PayOwn(string amountText, string methodLabel, int? churchId)
    {
        int? church = Me.ChurchId ?? churchId;
        if (church == null) return (null, "Choose a church first.");

        if (!int.TryParse(amountText.Trim(), out int amount))
            return (null, "Enter a valid amount in numbers.");
        var err = Validator.Amount(amount);
        if (err != null) return (null, err);

        var method = Format.MethodFromLabel(methodLabel);
        if (method == null) return (null, "Choose a payment method.");

        var id = _payments.Add(new Payment
        {
            MemberId = Me.Id,
            ChurchId = church.Value,
            Amount = amount,
            PaidOn = DateTime.Today,
            Method = method
        });
        return (_payments.GetById(id), null);
    }
}