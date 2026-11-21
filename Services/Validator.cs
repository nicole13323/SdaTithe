namespace SdaTithe.Services;

public static class Validator
{
    public static string? Registration(string name, string phone, string password, string confirm, bool phoneExists)
    {
        if (string.IsNullOrWhiteSpace(name)) return "Full name cannot be empty.";
        if (phone.Trim().Length < 10) return "Phone number must be at least 10 characters.";
        if (phoneExists) return "This phone number is already registered.";
        if (string.IsNullOrEmpty(password)) return "Password is required.";
        if (password != confirm) return "Passwords do not match.";
        return null;
    }

    // Used when a leader adds a member (no password needed).
    public static string? Member(string name, string phone, bool phoneExists)
    {
        if (string.IsNullOrWhiteSpace(name)) return "Full name cannot be empty.";
        if (phone.Trim().Length < 10) return "Phone number must be at least 10 characters.";
        if (phoneExists) return "This phone number is already registered.";
        return null;
    }

    public static string? Amount(int amount) =>
        amount < 100 ? "Minimum tithe amount is 100 RWF." : null;
}