using SdaTithe.Data;
using SdaTithe.Models;
using SdaTithe.Services;
namespace SdaTithe.Controllers;

public class AuthController
{
    private readonly UserRepository _users = new();

    public (User? user, string? error) Login(string key, string password, Role chosenRole)
    {
        var u = _users.FindByPhoneOrUsername(key.Trim());
        if (u == null || !PasswordHasher.Verify(password, u.PasswordHash))
            return (null, "Wrong phone/username or password.");
        if (u.Role != chosenRole)
            return (null, "This account does not have the chosen role.");
        Session.Current = u;
        return (u, null);
    }
    public string? Register(string name, string phone, int churchId, string password, string confirm)
    {
        phone = phone.Trim();
        var error = Validator.Registration(name, phone, password, confirm, _users.PhoneExists(phone));
        if (error != null) return error;

        _users.Add(new User
        {
            FullName = name.Trim(),
            Phone = phone,
            PasswordHash = PasswordHasher.Hash(password),
            Role = Role.Member,
            ChurchId = churchId,
            HasAccount = true
        });
        return null;
    }
    public void Logout() => Session.Current = null;
}