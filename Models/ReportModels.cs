namespace SdaTithe.Models;

public class PeriodTotal { public string Label { get; set; } = ""; public long Total { get; set; } }
public class MethodTotal { public string Method { get; set; } = ""; public long Total { get; set; } public int Count { get; set; } }
public class MemberTotal { public string Name { get; set; } = ""; public string Phone { get; set; } = ""; public long Total { get; set; } public int Count { get; set; } }
public class ChurchRank { public string Church { get; set; } = ""; public long Total { get; set; } }

public class ReportData
{
    public string Period { get; set; } = "";
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public string ChurchName { get; set; } = "";
    public long Total { get; set; }
    public int Count { get; set; }
    public double Average { get; set; }
    public List<PeriodTotal> Series { get; set; } = new();
    public List<MethodTotal> ByMethod { get; set; } = new();
    public List<MemberTotal> ByMember { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();
}

public class AnalyticsData
{
    public long YearTotal { get; set; }
    public long MonthTotal { get; set; }
    public long LastMonthTotal { get; set; }
    public int MemberCount { get; set; }
    public int ActiveGivers { get; set; }
    public double Participation { get; set; }
    public double AvgPerMember { get; set; }
    public List<string> Inactive { get; set; } = new();
    public List<PeriodTotal> Trend { get; set; } = new();
    public List<MethodTotal> Methods { get; set; } = new();
    public List<ChurchRank> Ranking { get; set; } = new();
}