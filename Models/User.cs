namespace SdaTithe.Models;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string? Username { get; set; }
    public string? Phone { get; set; }
    public string PasswordHash { get; set; } = "";
    public Role Role { get; set; }
    public int? ChurchId { get; set; }
    public string ChurchName { get; set; } = "";
    public bool HasAccount { get; set; } = true;
}