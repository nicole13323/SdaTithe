using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SdaTithe.Controllers;
using SdaTithe.Models;
using SdaTithe.Services;

namespace SdaTithe.Views
{
    public partial class AnalyticsForm : Form
    {
        private readonly ReportController _ctrl = new();
        private readonly BarChart _trend = new() { Dock = DockStyle.Fill, ChartTitle = "Last 12 months (RWF)" };
        private readonly BarChart _methods = new()
        {
            Dock = DockStyle.Fill,
            ChartTitle = "Payment method shares (this year)",
            ShowPercent = true
        };
        private bool _loading = true;

        public AnalyticsForm()
        {
            InitializeComponent();
            pnlTrend.Controls.Add(_trend);
            pnlMethods.Controls.Add(_methods);
            _trend.ChartTitle = Localizer.T("Last 12 months (RWF)");
            _methods.ChartTitle = Localizer.T("Payment method shares (this year)");

            var choices = _ctrl.GetChurchChoices();
            if (_ctrl.IsAdmin) choices.Insert(0, new Church { Id = 0, Name = Localizer.T("All churches") });
            cmbChurch.DisplayMember = "Name";
            cmbChurch.ValueMember = "Id";
            cmbChurch.DataSource = choices;
            cmbChurch.Visible = lblChurch.Visible = _ctrl.IsAdmin;

            dgvRanking.ReadOnly = true;
            dgvRanking.AllowUserToAddRows = false;
            dgvRanking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbChurch.SelectedIndexChanged += (s, e) => Reload();
            btnClose.Click += (s, e) => Close();
            Localizer.Apply(this);

            _loading = false;
            Reload();
        }
        private void Reload()
        {
            if (_loading) return;
            string T(string s) => Localizer.T(s);
            int? church = cmbChurch.SelectedValue is int id && id != 0 ? id : null;
            var a = _ctrl.BuildAnalytics(church);

            string change = a.LastMonthTotal == 0
                ? T("no data last month")
                : ((a.MonthTotal - a.LastMonthTotal) * 100.0 / a.LastMonthTotal).ToString("+0.#;-0.#;0")
                  + "% " + T("vs last month");

            lblYear.Text = T("Total collected this year") + ": " + Format.Rwf(a.YearTotal);
            lblMonth.Text = $"{T("Total this month")}: {Format.Rwf(a.MonthTotal)} " +
                            $"({T("last month")} {Format.Rwf(a.LastMonthTotal)}, {change})";
            lblMembers.Text = T("Number of members") + ": " + a.MemberCount;
            lblActive.Text = $"{T("Active givers this month")}: {a.ActiveGivers} " +
                             $"({a.Participation:0.#}% {T("participation")})";
            lblAvg.Text = T("Average given per member (this year)") + ": " +
                          Format.Rwf((long)Math.Round(a.AvgPerMember));
            lblInactive.Text = T("Members with no payment in 60 days") + ": " + a.Inactive.Count;
            lstInactive.DataSource = a.Inactive;

            _trend.SetData(a.Trend.Select(x => (x.Label, x.Total)));
            _methods.SetData(a.Methods.Select(x => (x.Method, x.Total)));

            dgvRanking.DataSource = a.Ranking.Select((c, i) => new
            {
                Rank = i + 1,
                Church = c.Church,
                Total = Format.Rwf(c.Total)
            }).ToList();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblMembers_Click(object sender, EventArgs e)
        {

        }

        private void lblAvg_Click(object sender, EventArgs e)
        {

        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {

        }

        private void lblActive_Click(object sender, EventArgs e)
        {

        }

        private void lblMonth_Click(object sender, EventArgs e)
        {

        }

        private void lblInactive_Click(object sender, EventArgs e)
        {

        }

        private void pnlMethods_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
