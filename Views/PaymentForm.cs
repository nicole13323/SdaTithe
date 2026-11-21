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
    public partial class PaymentForm : Form
    {
        private readonly LeaderController _ctrl = new();
        private readonly User? _member;      // null = paying own tithe
        private readonly int? _churchId;
        public Payment? Result { get; private set; }
        public PaymentForm(User? member, int? churchId)
        {
            InitializeComponent();
            _member = member;
            _churchId = churchId;

            cmbMethod.Items.AddRange(new object[] { "MTN MoMo", "Airtel Money", "Card" });
            cmbMethod.SelectedIndex = 0;
            dtpDate.MaxDate = DateTime.Today;
            dtpDate.Value = DateTime.Today;

            bool cash = member != null;
            lblTarget.Text = cash ? "Cash payment for: " + member!.FullName : "Pay your own tithe";
            lblDate.Visible = dtpDate.Visible = cash;
            lblMethod.Visible = cmbMethod.Visible = !cash;
            Localizer.Apply(this);

            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var (payment, error) = _member != null
           ? _ctrl.RecordCash(_member.Id, txtAmount.Text, dtpDate.Value.Date)
           : _ctrl.PayOwn(txtAmount.Text, cmbMethod.Text, _churchId);

            if (error != null)
            {
                lblError.Text = error;
                return;
            }

            Result = payment;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void lblMethod_Click(object sender, EventArgs e)
        {

        }
    }
}
