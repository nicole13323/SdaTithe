using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SdaTithe.Models;
using SdaTithe.Services;
namespace SdaTithe.Views;

public partial class ReceiptForm : Form
{
    private readonly List<string> _lines = new();

    public ReceiptForm(Payment p)
    {
        InitializeComponent();

        _lines.Add(Localizer.T("Receipt no: " + p.ReceiptNo));
        _lines.Add(Localizer.T("Member: " + p.MemberName));
        _lines.Add(Localizer.T("Church: " + p.ChurchName));
        _lines.Add(Localizer.T("Date: " + p.PaidOn.ToString("yyyy-MM-dd")));
        _lines.Add(Localizer.T("Method: " + p.Method));
        _lines.Add(Localizer.T("Amount: " + Format.Rwf(p.Amount)));
        if (p.Method == "Cash" && p.ReceivedBy != null)
            _lines.Add(Localizer.T("Received by: " + p.ReceivedBy));

        lblReceipt.Text = string.Join(Environment.NewLine + Environment.NewLine, _lines);
        Localizer.Apply(this);
        btnPrint.Click += btnPrint_Click;
        btnClose.Click += (s, e) => Close();
    }

    private void btnPrint_Click(object? sender, EventArgs e)
    {
        var doc = new System.Drawing.Printing.PrintDocument();
        doc.PrintPage += (s, ev) =>
        {
            var g = ev.Graphics!;
            using var titleFont = new Font("Segoe UI", 18, FontStyle.Bold);
            using var font = new Font("Segoe UI", 12);
            float y = 60;
            g.DrawString(Localizer.T("SDA Tithe Receipt"), titleFont, Brushes.Black, 60, y);
            y += 60;
            foreach (var line in _lines)
            {
                g.DrawString(line, font, Brushes.Black, 60, y);
                y += 32;
            }
        };

        using var preview = new PrintPreviewDialog { Document = doc, Width = 900, Height = 700 };
        preview.ShowDialog();
    }
}
