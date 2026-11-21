using Microsoft.Data.Sqlite;
using SdaTithe.Services;
namespace SdaTithe.Data;

// Demo data on first run: 8 churches, 48 members, about a year of payments.
public static class Seeder
{
    private const string UserSql =
        "INSERT INTO Users (FullName,Username,Phone,PasswordHash,Role,ChurchId,HasAccount) " +
        "VALUES (@n,@u,@p,@h,@r,@c,@a)";

    private static readonly string[] ChurchNames =
        { "Kigali Central", "Remera", "Nyamirambo", "Kimironko", "Gikondo", "Huye", "Musanze", "Rubavu" };
    private static readonly string[] FirstNames =
        { "Jean", "Marie", "Eric", "Alice", "Patrick", "Grace", "Emmanuel", "Claudine", "Samuel", "Immaculee", "David", "Providence" };
    private static readonly string[] LastNames =
        { "Uwimana", "Habimana", "Mukamana", "Nsengimana", "Niyonzima", "Ingabire", "Mugisha", "Uwase" };
    private static readonly int[] Amounts = { 1000, 2000, 5000, 5000, 10000, 20000 };

    public static void Run(SqliteConnection c)
    {
        using var tx = c.BeginTransaction();
        var rnd = new Random(42);
        var pw = PasswordHasher.Hash("1234");
        var today = DateTime.Today;
        int receipt = 0;

        foreach (var name in ChurchNames)
            Insert(c, tx, "INSERT INTO Churches (Name) VALUES (@n)", ("@n", name));

        Insert(c, tx, UserSql, ("@n", "System Admin"), ("@u", "admin"), ("@p", null),
            ("@h", PasswordHasher.Hash("admin123")), ("@r", "Admin"), ("@c", null), ("@a", 1));

        var leaderIds = new long[8];
        for (int i = 0; i < 8; i++)
            leaderIds[i] = Insert(c, tx, UserSql,
                ("@n", "Leader " + ChurchNames[i]), ("@u", "leader" + (i + 1)),
                ("@p", "0788100" + (i + 1).ToString("000")),
                ("@h", pw), ("@r", "ChurchLeader"), ("@c", i + 1), ("@a", 1));

        for (int i = 0; i < 48; i++)
        {
            int churchIdx = i % 8;
            string name = i == 0 ? "Test Member" : FirstNames[i % 12] + " " + LastNames[(i * 3 + i / 12) % 8];
            string phone = i == 0 ? "0788000001" : "0789" + i.ToString("000000");
            bool hasAccount = i % 3 != 0 || i == 0;
            bool lapsed = i % 7 == 3;     // these members stopped paying about 3 months ago

            long memberId = Insert(c, tx, UserSql,
                ("@n", name), ("@u", null), ("@p", phone),
                ("@h", hasAccount ? pw : "!"), ("@r", "Member"),
                ("@c", churchIdx + 1), ("@a", hasAccount ? 1 : 0));

            for (int m = 11; m >= 0; m--)
            {
                if (lapsed && m < 3) continue;
                if (rnd.NextDouble() > 0.8) continue;

                var first = new DateTime(today.Year, today.Month, 1).AddMonths(-m);
                int maxDay = m == 0 ? today.Day : DateTime.DaysInMonth(first.Year, first.Month);
                var date = first.AddDays(rnd.Next(1, maxDay + 1) - 1);

                int roll = rnd.Next(10);
                string method = roll < 4 ? "MTN" : roll < 7 ? "Airtel" : roll < 8 ? "Card" : "Cash";
                long? receivedBy = method == "Cash" ? leaderIds[churchIdx] : null;
                receipt++;

                Insert(c, tx,
                    "INSERT INTO Payments (ReceiptNo,MemberId,ChurchId,Amount,PaidOn,Method,ReceivedBy) " +
                    "VALUES (@rn,@m,@c,@a,@d,@me,@rb)",
                    ("@rn", "RCD" + receipt.ToString("000000")), ("@m", memberId), ("@c", churchIdx + 1),
                    ("@a", Amounts[rnd.Next(Amounts.Length)]), ("@d", date.ToString("yyyy-MM-dd")),
                    ("@me", method), ("@rb", receivedBy));
            }
        }

        tx.Commit();
    }

    private static long Insert(SqliteConnection c, SqliteTransaction tx, string sql,
        params (string, object?)[] ps)
    {
        using var cmd = c.CreateCommand();
        cmd.Transaction = tx;
        cmd.CommandText = sql + "; SELECT last_insert_rowid();";
        foreach (var (k, v) in ps) cmd.Parameters.AddWithValue(k, v ?? DBNull.Value);
        return (long)cmd.ExecuteScalar()!;
    }
}