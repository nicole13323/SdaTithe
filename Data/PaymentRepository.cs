using System.Globalization;
using Microsoft.Data.Sqlite;
using SdaTithe.Models;
namespace SdaTithe.Data;

public class PaymentRepository
{
    private const string Select =
        "SELECT p.Id, p.ReceiptNo, p.MemberId, u.FullName, p.ChurchId, c.Name, " +
        "p.Amount, p.PaidOn, p.Method, r.FullName " +
        "FROM Payments p " +
        "JOIN Users u ON u.Id = p.MemberId " +
        "JOIN Churches c ON c.Id = p.ChurchId " +
        "LEFT JOIN Users r ON r.Id = p.ReceivedBy ";

    private static Payment Read(SqliteDataReader r) => new()
    {
        Id = r.GetInt32(0),
        ReceiptNo = r.GetString(1),
        MemberId = r.GetInt32(2),
        MemberName = r.GetString(3),
        ChurchId = r.GetInt32(4),
        ChurchName = r.GetString(5),
        Amount = r.GetInt32(6),
        PaidOn = DateTime.ParseExact(r.GetString(7), "yyyy-MM-dd", CultureInfo.InvariantCulture),
        Method = r.GetString(8),
        ReceivedBy = r.IsDBNull(9) ? null : r.GetString(9)
    };

    public int Add(Payment p)
    {
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText =
            "INSERT INTO Payments (ReceiptNo, MemberId, ChurchId, Amount, PaidOn, Method, ReceivedBy) " +
            "VALUES (@rn, @m, @c, @a, @d, @me, @rb); SELECT last_insert_rowid();";
        cmd.Parameters.AddWithValue("@rn", "RC" + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        cmd.Parameters.AddWithValue("@m", p.MemberId);
        cmd.Parameters.AddWithValue("@c", p.ChurchId);
        cmd.Parameters.AddWithValue("@a", p.Amount);
        cmd.Parameters.AddWithValue("@d", p.PaidOn.ToString("yyyy-MM-dd"));
        cmd.Parameters.AddWithValue("@me", p.Method);
        cmd.Parameters.AddWithValue("@rb", (object?)p.ReceivedById ?? DBNull.Value);
        return (int)(long)cmd.ExecuteScalar()!;
    }

    public Payment? GetById(int id)
    {
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = Select + "WHERE p.Id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        using var r = cmd.ExecuteReader();
        return r.Read() ? Read(r) : null;
    }
    public List<Payment> GetInRange(DateTime from, DateTime to, int? churchId)
    {
        var list = new List<Payment>();
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = Select +
            "WHERE p.PaidOn >= @f AND p.PaidOn <= @t AND (@c IS NULL OR p.ChurchId = @c) " +
            "ORDER BY p.PaidOn DESC, p.Id DESC";
        cmd.Parameters.AddWithValue("@f", from.ToString("yyyy-MM-dd"));
        cmd.Parameters.AddWithValue("@t", to.ToString("yyyy-MM-dd"));
        cmd.Parameters.AddWithValue("@c", (object?)churchId ?? DBNull.Value);
        using var r = cmd.ExecuteReader();
        while (r.Read()) list.Add(Read(r));
        return list;
    }

    public List<Payment> GetByMember(int memberId)
    {
        var list = new List<Payment>();
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = Select + "WHERE p.MemberId = @m ORDER BY p.PaidOn DESC, p.Id DESC";
        cmd.Parameters.AddWithValue("@m", memberId);
        using var r = cmd.ExecuteReader();
        while (r.Read()) list.Add(Read(r));
        return list;
    }

    public (long total, long count, long year) Summary(int memberId)
    {
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText =
            "SELECT COALESCE(SUM(Amount),0), COUNT(*), " +
            "COALESCE(SUM(CASE WHEN strftime('%Y', PaidOn) = @y THEN Amount END),0) " +
            "FROM Payments WHERE MemberId = @m";
        cmd.Parameters.AddWithValue("@m", memberId);
        cmd.Parameters.AddWithValue("@y", DateTime.Now.Year.ToString());
        using var r = cmd.ExecuteReader();
        r.Read();
        return (r.GetInt64(0), r.GetInt64(1), r.GetInt64(2));
    }
}