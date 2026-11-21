using System;
using System.Collections.Generic;
using System.Text;

using SdaTithe.Models;
namespace SdaTithe.Data;

public class ChurchRepository
{
    public List<Church> GetAll()
    {
        var list = new List<Church>();
        using var c = Db.Open();
        var cmd = c.CreateCommand();
        cmd.CommandText = "SELECT Id, Name FROM Churches ORDER BY Name";
        using var r = cmd.ExecuteReader();
        while (r.Read())
            list.Add(new Church { Id = r.GetInt32(0), Name = r.GetString(1) });
        return list;
    }
}
