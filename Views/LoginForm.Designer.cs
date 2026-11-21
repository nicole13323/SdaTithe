namespace SdaTithe.Views
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblRole = new Label();
            lblId = new Label();
            lblPass = new Label();
            lblError = new Label();
            txtId = new TextBox();
            txtPassword = new TextBox();
            cmbRole = new ComboBox();
            btnLogin = new Button();
            lnkRegister = new LinkLabel();
            cmbLanguage = new ComboBox();
            SuspendLayout();
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9.75F);
            lblRole.Location = new Point(56, 63);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(34, 17);
            lblRole.TabIndex = 0;
            lblRole.Text = "Role";
            lblRole.Click += lblRole_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9.75F);
            lblId.Location = new Point(56, 157);
            lblId.Name = "lblId";
            lblId.Size = new Size(122, 17);
            lblId.TabIndex = 1;
            lblId.Text = "Phone or username";
            lblId.Click += lblId_Click;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 9.75F);
            lblPass.Location = new Point(56, 252);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(64, 17);
            lblPass.TabIndex = 2;
            lblPass.Text = "Password";
            lblPass.Click += lblPass_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.BackColor = Color.Red;
            lblError.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.Location = new Point(101, 329);
            lblError.Name = "lblError";
            lblError.Size = new Size(54, 21);
            lblError.TabIndex = 3;
            lblError.Text = "Empty";
            lblError.Click += lblError_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(217, 151);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 4;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(217, 246);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(217, 62);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(121, 23);
            cmbRole.TabIndex = 6;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(329, 359);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(87, 33);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkRegister
            // 
            lnkRegister.AutoSize = true;
            lnkRegister.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkRegister.Location = new Point(539, 369);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(151, 20);
            lnkRegister.TabIndex = 8;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Create a new account";
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(641, 12);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(121, 23);
            cmbLanguage.TabIndex = 9;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbLanguage);
            Controls.Add(lnkRegister);
            Controls.Add(btnLogin);
            Controls.Add(cmbRole);
            Controls.Add(txtPassword);
            Controls.Add(txtId);
            Controls.Add(lblError);
            Controls.Add(lblPass);
            Controls.Add(lblId);
            Controls.Add(lblRole);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SDA Tithe Management - Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRole;
        private Label lblId;
        private Label lblPass;
        private Label lblError;
        private TextBox txtId;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Button btnLogin;
        private LinkLabel lnkRegister;
        private ComboBox cmbLanguage;
    }
}