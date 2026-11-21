using SdaTithe.Controllers;
using SdaTithe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SdaTithe.Services;

namespace SdaTithe.Views
{
    public partial class RegisterForm : Form
    {
        private readonly AuthController _auth = new();
        public RegisterForm()
        {
            InitializeComponent();
            cmbChurch.DataSource = new ChurchRepository().GetAll();
            cmbChurch.DisplayMember = "Name";
            cmbChurch.ValueMember = "Id";

            btnRegister.Click += btnRegister_Click;
            btnCancel.Click += (s, e) => Close();
            Localizer.Apply(this);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cmbChurch.SelectedValue == null)
            {
                lblError.Text = "Please choose a church.";
                return;
            }

            var error = _auth.Register(txtName.Text, txtPhone.Text,
                (int)cmbChurch.SelectedValue, txtPassword.Text, txtConfirm.Text);

            if (error != null)
            {
                lblError.Text = error;
                return;
            }

            MessageBox.Show(Localizer.T("Account created. You can now log in."));
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbChurch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
