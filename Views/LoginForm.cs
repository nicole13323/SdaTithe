using SdaTithe.Controllers;
using SdaTithe.Models;
using SdaTithe.Services;
namespace SdaTithe.Views;

public partial class LoginForm : Form
{
    private readonly AuthController _auth = new();

    public LoginForm()
    {
        cmbRole.DataSource = Enum.GetValues(typeof(Role));
        btnLogin.Click += btnLogin_Click;
        AcceptButton = btnLogin;
        lnkRegister.Click += (s, e) => new RegisterForm().ShowDialog();

        Localizer.BindSelector(cmbLanguage, () => Localizer.Apply(this));
        Localizer.Apply(this);
    }

    private void lblId_Click(object sender, EventArgs e)
    {

    }

    private void lblPass_Click(object sender, EventArgs e)
    {

    }

    private void lblRole_Click(object sender, EventArgs e)
    {

    }

    private void lblError_Click(object sender, EventArgs e)
    {

    }

    private void txtId_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {

    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        var (user, error) = _auth.Login(txtId.Text, txtPassword.Text, (Role)cmbRole.SelectedItem!);
        if (error != null)
        {
            lblError.Text = error;
            return;
        }

        lblError.Text = "";
        Hide();
        Form dashboard = user!.Role == Role.Member
            ? new MemberDashboardForm()
            : new ManagerDashboardForm();
        dashboard.ShowDialog();
        txtPassword.Clear();
        Localizer.Apply(this);
        Localizer.SyncSelector(cmbLanguage);
        Show();
    }

    private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {

    }
}