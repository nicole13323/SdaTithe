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
    public partial class ReportForm : Form
    {
        private readonly ReportController _ctrl = new();
        private readonly BarChart _chart = new() { Dock = DockStyle.Fill };
        private ReportData? _report;
        private bool _loading = true;
        private static readonly string[] Periods = { "Week", "Month", "Year" };
        public ReportForm()
        {
            InitializeComponent();
            pnlChart.Controls.Add(_chart);

            var choices = _ctrl.GetChurchChoices();
            if (_ctrl.IsAdmin) choices.Insert(0, new Church { Id = 0, Name = Localizer.T("All churches") });
            cmbChurch.DisplayMember = "Name";
            cmbChurch.ValueMember = "Id";
            cmbChurch.DataSource = choices;
            cmbChurch.Visible = lblChurch.Visible = _ctrl.IsAdmin;

            cmbPeriod.Items.AddRange(new object[] { Localizer.T("Week"), Localizer.T("Month"), Localizer.T("Year") });
            cmbPeriod.SelectedIndex = 1;
            cmbView.Items.AddRange(new object[] { Localizer.T("Totals by payment method"), Localizer.T("Totals by member"), Localizer.T("All payments") });
            cmbView.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;

            dgvDetails.ReadOnly = true;
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbChurch.SelectedIndexChanged += (s, e) => Reload();
            cmbPeriod.SelectedIndexChanged += (s, e) => Reload();
            dtpDate.ValueChanged += (s, e) => Reload();
            cmbView.SelectedIndexChanged += (s, e) => ShowDetails();
            btnPrint.Click += btnPrint_Click;
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
            _report = _ctrl.BuildReport(Periods[cmbPeriod.SelectedIndex], dtpDate.Value, church);

            string name = _report.ChurchName == "All churches" ? T("All churches") : _report.ChurchName;
            lblSummary.Text =
                $"{name} | {_report.From:yyyy-MM-dd} - {_report.To:yyyy-MM-dd} | " +
                $"{T("Total")}: {Format.Rwf(_report.Total)} | {T("Payments")}: {_report.Count} | " +
                $"{T("Average")}: {Format.Rwf((long)Math.Round(_report.Average))}";

            _chart.ChartTitle = T(_report.Period == "Year" ? "Collected per month (RWF)" : "Collected per day (RWF)");
            _chart.SetData(_report.Series.Select(x => (x.Label, x.Total)));
            ShowDetails();
        }

        private void ShowDetails()
        {
            if (_report == null) return;
            switch (cmbView.SelectedIndex)
            {
                case 0:
                    dgvDetails.DataSource = _report.ByMethod.Select(m => new
                    {
                        Method = m.Method,
                        Payments = m.Count,
                        Total = Format.Rwf(m.Total)
                    }).ToList();
                    break;
                case 1:
                    dgvDetails.DataSource = _report.ByMember.Select(m => new
                    {
                        Member = m.Name,
                        Phone = m.Phone,
                        Payments = m.Count,
                        Total = Format.Rwf(m.Total)
                    }).ToList();
                    break;
                default:
                    dgvDetails.DataSource = _report.Payments.Select(p => new
                    {
                        Date = p.PaidOn.ToString("yyyy-MM-dd"),
                        Receipt = p.ReceiptNo,
                        Member = p.MemberName,
                        Method = p.Method,
                        Amount = Format.Rwf(p.Amount)
                    }).ToList();
                    break;
            }
        }

        private static string Trunc(string s, int n) => s.Length <= n ? s : s[..n];

        private static List<string> BuildLines(ReportData r)
        {
            string T(string s) => Localizer.T(s);
            var L = new List<string>
        {
            T("Church") + ": " + (r.ChurchName == "All churches" ? T("All churches") : r.ChurchName),
            T("Period") + ": " + T(r.Period) + $" ({r.From:yyyy-MM-dd} - {r.To:yyyy-MM-dd})",
            "",
            T("Total collected") + ": " + Format.Rwf(r.Total),
            T("Payments") + ": " + r.Count,
            T("Average payment") + ": " + Format.Rwf((long)Math.Round(r.Average)),
            "",
            T("Totals by payment method").ToUpper()
        };
            foreach (var m in r.ByMethod)
                L.Add($"  {m.Method,-10}{m.Count,5}  {Format.Rwf(m.Total),15}");

            L.Add("");
            L.Add(T("Totals by member").ToUpper());
            foreach (var m in r.ByMember)
                L.Add($"  {Trunc(m.Name, 26),-26}{m.Count,5}  {Format.Rwf(m.Total),15}");

            L.Add("");
            L.Add(T("All payments").ToUpper());
            foreach (var p in r.Payments)
                L.Add($"  {p.PaidOn:yyyy-MM-dd}  {p.ReceiptNo,-20}{Trunc(p.MemberName, 22),-22}{p.Method,-8}{Format.Rwf(p.Amount),14}");
            return L;
        }
        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_report == null) return;
            var lines = BuildLines(_report);
            int index = 0;
            bool first = true;

            var doc = new System.Drawing.Printing.PrintDocument();
            doc.BeginPrint += (s, ev) => { index = 0; first = true; };
            doc.PrintPage += (s, ev) =>
            {
                var g = ev.Graphics!;
                using var titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
                using var font = new Font("Consolas", 9);
                float left = ev.MarginBounds.Left;
                float y = ev.MarginBounds.Top;
                float lineH = font.GetHeight(g) + 2;

                if (first)
                {
                    g.DrawString(Localizer.T("SDA Tithe Report"), titleFont, Brushes.Black, left, y);
                    y += 40;
                    _chart.Draw(g, new Rectangle((int)left, (int)y, ev.MarginBounds.Width, 220));
                    y += 235;
                    first = false;
                }

                while (index < lines.Count && y + lineH < ev.MarginBounds.Bottom)
                {
                    g.DrawString(lines[index++], font, Brushes.Black, left, y);
                    y += lineH;
                }
                ev.HasMorePages = index < lines.Count;
            };

            using var preview = new PrintPreviewDialog { Document = doc, Width = 1000, Height = 750 };
            preview.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblSummary_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
