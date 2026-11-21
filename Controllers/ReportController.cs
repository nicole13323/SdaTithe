using SdaTithe.Data;
using SdaTithe.Models;
using SdaTithe.Services;
namespace SdaTithe.Controllers;

public class ReportController
{
    private readonly PaymentRepository _payments = new();
    private readonly UserRepository _users = new();
    private readonly ChurchRepository _churches = new();

    private User Me
    {
        get
        {
            var u = Session.Current ?? throw new InvalidOperationException("Not logged in.");
            if (u.Role == Role.Member) throw new UnauthorizedAccessException("Managers only.");
            return u;
        }
    }

    public bool IsAdmin => Me.Role == Role.Admin;

    // A leader is always limited to their own church (FR8); an admin may choose.
    private int? Scope(int? requested) => IsAdmin ? requested : Me.ChurchId;

    public List<Church> GetChurchChoices()
    {
        var all = _churches.GetAll();
        return IsAdmin ? all : all.Where(c => c.Id == Me.ChurchId).ToList();
    }

    private static (DateTime from, DateTime to) Range(string period, DateTime d)
    {
        d = d.Date;
        switch (period)
        {
            case "Week":
                int diff = ((int)d.DayOfWeek + 6) % 7;        // Monday = 0
                var monday = d.AddDays(-diff);
                return (monday, monday.AddDays(6));
            case "Year":
                return (new DateTime(d.Year, 1, 1), new DateTime(d.Year, 12, 31));
            default:
                var first = new DateTime(d.Year, d.Month, 1);
                return (first, first.AddMonths(1).AddDays(-1));
        }
    }

    public ReportData BuildReport(string period, DateTime anchor, int? churchId)
    {
        int? church = Scope(churchId);
        var (from, to) = Range(period, anchor);
        var pays = _payments.GetInRange(from, to, church);
        var members = _users.SearchMembers(church, "");

        var r = new ReportData
        {
            Period = period,
            From = from,
            To = to,
            ChurchName = church == null
                ? "All churches"
                : _churches.GetAll().FirstOrDefault(c => c.Id == church)?.Name ?? "",
            Payments = pays,
            Total = pays.Sum(p => (long)p.Amount),
            Count = pays.Count
        };
        r.Average = r.Count == 0 ? 0 : (double)r.Total / r.Count;

        r.ByMethod = pays.GroupBy(p => p.Method)
            .Select(g => new MethodTotal { Method = g.Key, Count = g.Count(), Total = g.Sum(p => (long)p.Amount) })
            .OrderByDescending(x => x.Total).ToList();

        // Every member appears, including those who paid nothing (FR17).
        var rows = members.ToDictionary(m => m.Id,
            m => new MemberTotal { Name = m.FullName, Phone = m.Phone ?? "" });
        foreach (var p in pays)
        {
            if (!rows.TryGetValue(p.MemberId, out var row))
                rows[p.MemberId] = row = new MemberTotal { Name = p.MemberName };
            row.Total += p.Amount;
            row.Count++;
        }
        r.ByMember = rows.Values.OrderByDescending(x => x.Total).ThenBy(x => x.Name).ToList();

        // Bars: by month for a year, by day for a week or a month.
        if (period == "Year")
        {
            for (int m = 1; m <= 12; m++)
                r.Series.Add(new PeriodTotal
                {
                    Label = new DateTime(from.Year, m, 1).ToString("MMM"),
                    Total = pays.Where(p => p.PaidOn.Month == m).Sum(p => (long)p.Amount)
                });
        }
        else
        {
            for (var d = from; d <= to; d = d.AddDays(1))
            {
                var day = d;
                r.Series.Add(new PeriodTotal
                {
                    Label = period == "Week" ? day.ToString("ddd dd") : day.Day.ToString(),
                    Total = pays.Where(p => p.PaidOn == day).Sum(p => (long)p.Amount)
                });
            }
        }
        return r;
    }

    public AnalyticsData BuildAnalytics(int? churchId)
    {
        int? church = Scope(churchId);
        var today = DateTime.Today;
        var monthStart = new DateTime(today.Year, today.Month, 1);
        var trendStart = monthStart.AddMonths(-11);

        var pays = _payments.GetInRange(trendStart, today, church);
        var members = _users.SearchMembers(church, "");
        var memberIds = members.Select(m => m.Id).ToHashSet();
        var thisYear = pays.Where(p => p.PaidOn.Year == today.Year).ToList();

        var a = new AnalyticsData
        {
            YearTotal = thisYear.Sum(p => (long)p.Amount),
            MonthTotal = pays.Where(p => p.PaidOn >= monthStart).Sum(p => (long)p.Amount),
            LastMonthTotal = pays.Where(p => p.PaidOn >= monthStart.AddMonths(-1) && p.PaidOn < monthStart)
                                 .Sum(p => (long)p.Amount),
            MemberCount = members.Count
        };

        a.ActiveGivers = pays.Where(p => p.PaidOn >= monthStart && memberIds.Contains(p.MemberId))
                             .Select(p => p.MemberId).Distinct().Count();
        a.Participation = a.MemberCount == 0 ? 0 : a.ActiveGivers * 100.0 / a.MemberCount;

        var recent = pays.Where(p => p.PaidOn >= today.AddDays(-60)).Select(p => p.MemberId).ToHashSet();
        a.Inactive = members.Where(m => !recent.Contains(m.Id)).Select(m => m.FullName).OrderBy(n => n).ToList();

        long memberYear = thisYear.Where(p => memberIds.Contains(p.MemberId)).Sum(p => (long)p.Amount);
        a.AvgPerMember = a.MemberCount == 0 ? 0 : (double)memberYear / a.MemberCount;

        a.Trend = Enumerable.Range(0, 12).Select(i =>
        {
            var s = trendStart.AddMonths(i);
            return new PeriodTotal
            {
                Label = s.ToString("MMM yy"),
                Total = pays.Where(p => p.PaidOn.Year == s.Year && p.PaidOn.Month == s.Month)
                            .Sum(p => (long)p.Amount)
            };
        }).ToList();

        a.Methods = thisYear.GroupBy(p => p.Method)
            .Select(g => new MethodTotal { Method = g.Key, Count = g.Count(), Total = g.Sum(p => (long)p.Amount) })
            .OrderByDescending(x => x.Total).ToList();

        // Ranking of all churches by this year's total.
        var allYear = _payments.GetInRange(new DateTime(today.Year, 1, 1), today, null);
        a.Ranking = _churches.GetAll()
            .Select(c => new ChurchRank
            {
                Church = c.Name,
                Total = allYear.Where(p => p.ChurchId == c.Id).Sum(p => (long)p.Amount)
            })
            .OrderByDescending(x => x.Total).ToList();

        return a;
    }
}