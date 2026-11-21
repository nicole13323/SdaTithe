using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SdaTithe.Controllers;
using SdaTithe.Services;


namespace SdaTithe.Views
{

    public partial class MemberDashboardForm : Form
    {
        private readonly MemberController _ctrl = new();
        private readonly AuthController _auth = new();
        public MemberDashboardForm()
        {
            InitializeComponent();
            lblWelcome.Text = "Welcome, " + Session.Current!.FullName;
            cmbMethod.Items.AddRange(new object[] { "MTN MoMo", "Airtel Money", "Card" });
            cmbMethod.SelectedIndex = 0;

            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.MultiSelect = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnPay.Click += btnPay_Click;
            btnReceipt.Click += btnReceipt_Click;
            btnLogout.Click += (s, e) => { _auth.Logout(); Close(); };

            RefreshData();
            Localizer.BindSelector(cmbLanguage, () => Localizer.Apply(this));
            Localizer.Apply(this);
        }
        private void RefreshData()
        {
            var s = _ctrl.GetSummary();
            lblYear.Text = "Total this year: " + Format.Rwf(s.year);
            lblTotal.Text = "Total overall: " + Format.Rwf(s.total);
            lblCount.Text = "Number of payments: " + s.count;

            var rows = _ctrl.GetHistory().Select(p => new
            {
                p.Id,
                Receipt = p.ReceiptNo,
                Date = p.PaidOn.ToString("yyyy-MM-dd"),
                Method = p.Method,
                Amount = Format.Rwf(p.Amount)
            }).ToList();

            dgvHistory.DataSource = rows;
            if (dgvHistory.Columns["Id"] != null) dgvHistory.Columns["Id"]!.Visible = false;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            var (payment, error) = _ctrl.Pay(txtAmount.Text, cmbMethod.Text);
            if (error != null)
            {
                lblError.Text = error;
                return;
            }

            lblError.Text = "";
            txtAmount.Clear();
            RefreshData();
            new ReceiptForm(payment!).ShowDialog();
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            if (dgvHistory.CurrentRow == null)
            {
                lblError.Text = "Select a payment first.";
                return;
            }

            int id = (int)dgvHistory.CurrentRow.Cells["Id"].Value;
            var p = _ctrl.GetReceipt(id);
            if (p == null)
            {
                lblError.Text = "Receipt not found.";
                return;
            }

            lblError.Text = "";
            new ReceiptForm(p).ShowDialog();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
