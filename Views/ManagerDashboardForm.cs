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
    public partial class ManagerDashboardForm : Form
    {
        private readonly LeaderController _ctrl = new();
        private readonly AuthController _auth = new();
        private List<User> _members = new();
        public ManagerDashboardForm()
        {
            InitializeComponent();
            var me = Session.Current!;
            lblWelcome.Text = "Welcome, " + me.FullName + " (" + me.Role + ")";

            var choices = _ctrl.GetChurchChoices();
            if (_ctrl.IsAdmin) choices.Insert(0, new Church { Id = 0, Name = Localizer.T("All churches") });
            cmbChurch.DisplayMember = "Name";
            cmbChurch.ValueMember = "Id";
            cmbChurch.DataSource = choices;
            cmbChurch.Visible = lblChurch.Visible = _ctrl.IsAdmin;
            if (!_ctrl.IsAdmin && choices.Count > 0)
                lblWelcome.Text += " - " + choices[0].Name;

            dgvMembers.ReadOnly = true;
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.MultiSelect = false;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbChurch.SelectedIndexChanged += (s, e) => LoadMembers();
            txtSearch.TextChanged += (s, e) => LoadMembers();
            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
            btnCash.Click += btnCash_Click;
            btnPayOwn.Click += btnPayOwn_Click;
            btnReports.Click += (s, e) => { using var f = new ReportForm(); f.ShowDialog(); };
            btnAnalytics.Click += (s, e) => { using var f = new AnalyticsForm(); f.ShowDialog(); };
            btnLogout.Click += (s, e) => { _auth.Logout(); Close(); };

            LoadMembers();
            Localizer.BindSelector(cmbLanguage, () => { Localizer.Apply(this); LoadMembers(); });
            Localizer.Apply(this);
        }
        private int? SelectedChurchId() =>
        cmbChurch.SelectedValue is int id && id != 0 ? id : null;

        private void LoadMembers()
        {
            _members = _ctrl.GetMembers(SelectedChurchId(), txtSearch.Text);

            dgvMembers.DataSource = _members.Select(m => new
            {
                m.Id,
                Name = m.FullName,
                Phone = m.Phone,
                Church = m.ChurchName,
                Account = m.HasAccount ? Localizer.T("Yes") : Localizer.T("Cash only")
            }).ToList();

            if (dgvMembers.Columns["Id"] != null) dgvMembers.Columns["Id"]!.Visible = false;
        }

        private User? SelectedMember()
        {
            if (dgvMembers.CurrentRow == null) return null;
            int id = (int)dgvMembers.CurrentRow.Cells["Id"].Value;
            return _members.FirstOrDefault(m => m.Id == id);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            var member = SelectedMember();
            if (member == null) { lblError.Text = "Select a member first."; return; }

            var answer = MessageBox.Show(
             member.FullName + " - " + Localizer.T("Delete this member and all their payments?"),
             Localizer.T("Confirm delete"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer != DialogResult.Yes) return;

            var error = _ctrl.DeleteMember(member.Id);
            lblError.Text = error ?? "";
            LoadMembers();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var error = _ctrl.AddMember(txtNewName.Text, txtNewPhone.Text, SelectedChurchId());
            if (error != null) { lblError.Text = error; return; }

            lblError.Text = "";
            txtNewName.Clear();
            txtNewPhone.Clear();
            LoadMembers();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            var member = SelectedMember();
            if (member == null) { lblError.Text = "Select a member first."; return; }

            lblError.Text = "";
            using var dlg = new PaymentForm(member, member.ChurchId);
            if (dlg.ShowDialog() == DialogResult.OK && dlg.Result != null)
                new ReceiptForm(dlg.Result).ShowDialog();
        }

        private void btnPayOwn_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            using var dlg = new PaymentForm(null, SelectedChurchId());
            if (dlg.ShowDialog() == DialogResult.OK && dlg.Result != null)
                new ReceiptForm(dlg.Result).ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}
