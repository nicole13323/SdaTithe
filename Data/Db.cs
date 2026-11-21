using Microsoft.Data.Sqlite;
using SdaTithe.Services;
namespace SdaTithe.Data;

public static class Db
{
    private static readonly string FilePath =
        Path.Combine(AppContext.BaseDirectory, "tithe.db");

    public static SqliteConnection Open()
    {
        var c = new SqliteConnection($"Data Source={FilePath};Foreign Keys=True");
        c.Open();
        return c;
    }

    public static void Init()
    {
        using var c = Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = @"
        CREATE TABLE IF NOT EXISTS Churches (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL UNIQUE);

        CREATE TABLE IF NOT EXISTS Users (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            FullName TEXT NOT NULL,
            Username TEXT UNIQUE,
            Phone TEXT UNIQUE,
            PasswordHash TEXT NOT NULL,
            Role TEXT NOT NULL CHECK (Role IN ('Member','ChurchLeader','Admin')),
            ChurchId INTEGER REFERENCES Churches(Id),
            HasAccount INTEGER NOT NULL DEFAULT 1);

        CREATE TABLE IF NOT EXISTS Payments (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            ReceiptNo TEXT NOT NULL UNIQUE,
            MemberId INTEGER NOT NULL REFERENCES Users(Id) ON DELETE CASCADE,
            ChurchId INTEGER NOT NULL REFERENCES Churches(Id),
            Amount INTEGER NOT NULL CHECK (Amount >= 100),
            PaidOn TEXT NOT NULL,
            Method TEXT NOT NULL CHECK (Method IN ('MTN','Airtel','Card','Cash')),
            ReceivedBy INTEGER REFERENCES Users(Id));";
        cmd.ExecuteNonQuery();

        var count = c.CreateCommand();
        count.CommandText = "SELECT COUNT(*) FROM Churches";
        if ((long)count.ExecuteScalar()! == 0) Seeder.Run(c);
    }

    private static void SeedBasic(SqliteConnection c)
    {
        Exec(c, "INSERT INTO Churches (Name) VALUES ('Kigali Central')");
        Exec(c, "INSERT INTO Users (FullName,Username,Phone,PasswordHash,Role,ChurchId) VALUES (@n,@u,@p,@h,@r,@c)",
            ("@n", "System Admin"), ("@u", "admin"), ("@p", null), ("@h", PasswordHasher.Hash("admin123")), ("@r", "Admin"), ("@c", null));
        Exec(c, "INSERT INTO Users (FullName,Username,Phone,PasswordHash,Role,ChurchId) VALUES (@n,@u,@p,@h,@r,@c)",
            ("@n", "Church Leader"), ("@u", "leader1"), ("@p", "0788000002"), ("@h", PasswordHasher.Hash("1234")), ("@r", "ChurchLeader"), ("@c", 1));
        Exec(c, "INSERT INTO Users (FullName,Username,Phone,PasswordHash,Role,ChurchId) VALUES (@n,@u,@p,@h,@r,@c)",
            ("@n", "Test Member"), ("@u", null), ("@p", "0788000001"), ("@h", PasswordHasher.Hash("1234")), ("@r", "Member"), ("@c", 1));
    }

    private static void Exec(SqliteConnection c, string sql, params (string, object?)[] ps)
    {
        var cmd = c.CreateCommand();
        cmd.CommandText = sql;
        foreach (var (k, v) in ps) cmd.Parameters.AddWithValue(k, v ?? DBNull.Value);
        cmd.ExecuteNonQuery();
    }
}