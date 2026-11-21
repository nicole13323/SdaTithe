using Microsoft.Data.Sqlite;
using SdaTithe.Models;
namespace SdaTithe.Data;

public class UserRepository
{
    private const string Select =
        "SELECT u.Id,u.FullName,u.Username,u.Phone,u.PasswordHash,u.Role,u.ChurchId,u.HasAccount,c.Name " +
        "FROM Users u LEFT JOIN Churches c ON c.Id = u.ChurchId ";

    private static User Read(SqliteDataReader r) => new()
    {
        Id = r.GetInt32(0),
        FullName = r.GetString(1),
        Username = r.IsDBNull(2) ? null : r.GetString(2),
        Phone = r.IsDBNull(3) ? null : r.GetString(3),
        PasswordHash = r.GetString(4),
        Role = Enum.Parse<Role>(r.GetString(5)),
        ChurchId = r.IsDBNull(6) ? null : r.GetInt32(6),
        HasAccount = r.GetInt32(7) == 1,
        ChurchName = r.IsDBNull(8) ? "" : r.GetString(8)
    };

    public User? FindByPhoneOrUsername(string key)
    {
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = Select + "WHERE u.Phone=@k OR u.Username=@k LIMIT 1";
        cmd.Parameters.AddWithValue("@k", key);
        using var r = cmd.ExecuteReader();
        return r.Read() ? Read(r) : null;
    }

    public User? FindById(int id)
    {
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = Select + "WHERE u.Id=@id";
        cmd.Parameters.AddWithValue("@id", id);
        using var r = cmd.ExecuteReader();
        return r.Read() ? Read(r) : null;
    }

    public bool PhoneExists(string phone)
    {
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Phone=@p";
        cmd.Parameters.AddWithValue("@p", phone);
        return (long)cmd.ExecuteScalar()! > 0;
    }

    public void Add(User u)
    {
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = "INSERT INTO Users (FullName,Username,Phone,PasswordHash,Role,ChurchId,HasAccount) " +
                          "VALUES (@n,@u,@p,@h,@r,@c,@a)";
        cmd.Parameters.AddWithValue("@n", u.FullName);
        cmd.Parameters.AddWithValue("@u", (object?)u.Username ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@p", (object?)u.Phone ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@h", u.PasswordHash);
        cmd.Parameters.AddWithValue("@r", u.Role.ToString());
        cmd.Parameters.AddWithValue("@c", (object?)u.ChurchId ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@a", u.HasAccount ? 1 : 0);
        cmd.ExecuteNonQuery();
    }

    // churchId null = all churches
    public List<User> SearchMembers(int? churchId, string term)
    {
        var list = new List<User>();
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = Select +
            "WHERE u.Role='Member' AND (@church IS NULL OR u.ChurchId=@church) " +
            "AND (@q='' OR u.FullName LIKE '%'||@q||'%' OR u.Phone LIKE '%'||@q||'%') " +
            "ORDER BY u.FullName";
        cmd.Parameters.AddWithValue("@church", (object?)churchId ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@q", term);
        using var r = cmd.ExecuteReader();
        while (r.Read()) list.Add(Read(r));
        return list;
    }

    public void Delete(int id)
    {
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = "DELETE FROM Users WHERE Id=@id";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}