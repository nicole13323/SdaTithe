using SdaTithe.Data;
using SdaTithe.Models;
using SdaTithe.Services;
namespace SdaTithe.Controllers;

public class MemberController
{
    private readonly PaymentRepository _payments = new();

    private User Me => Session.Current ?? throw new InvalidOperationException("Not logged in.");

    public (Payment? payment, string? error) Pay(string amountText, string methodLabel)
    {
        if (!int.TryParse(amountText.Trim(), out int amount))
            return (null, "Enter a valid amount in numbers.");

        var err = Validator.Amount(amount);
        if (err != null) return (null, err);

        string? method = methodLabel switch
        {
            "MTN MoMo" => "MTN",
            "Airtel Money" => "Airtel",
            "Card" => "Card",
            _ => null
        };
        if (method == null) return (null, "Choose a payment method.");
        if (Me.ChurchId == null) return (null, "Your account has no church.");

        var id = _payments.Add(new Payment
        {
            MemberId = Me.Id,
            ChurchId = Me.ChurchId.Value,
            Amount = amount,
            PaidOn = DateTime.Today,
            Method = method
        });
        return (_payments.GetById(id), null);
    }

    public (long total, long count, long year) GetSummary() => _payments.Summary(Me.Id);

    public List<Payment> GetHistory() => _payments.GetByMember(Me.Id);

    // A member can only open their own receipts.
    public Payment? GetReceipt(int id)
    {
        var p = _payments.GetById(id);
        return p != null && p.MemberId == Me.Id ? p : null;
    }
}