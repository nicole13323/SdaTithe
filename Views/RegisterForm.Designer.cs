namespace SdaTithe.Views
{
    partial class RegisterForm
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
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            lblName = new Label();
            lblPhone = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnCancel = new Button();
            btnRegister = new Button();
            txtPhone = new TextBox();
            txtPassword = new TextBox();
            txtConfirm = new TextBox();
            txtName = new TextBox();
            cmbChurch = new ComboBox();
            lblError = new Label();
            SuspendLayout();
            // 
            // sqliteCommand1
            // 
            sqliteCommand1.CommandTimeout = 30;
            sqliteCommand1.Connection = null;
            sqliteCommand1.Transaction = null;
            sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.75F);
            lblName.Location = new Point(28, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(63, 17);
            lblName.TabIndex = 0;
            lblName.Text = "Full name";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9.75F);
            lblPhone.Location = new Point(28, 86);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(93, 17);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "Phone number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(28, 152);
            label3.Name = "label3";
            label3.Size = new Size(48, 17);
            label3.TabIndex = 2;
            label3.Text = "Church";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(28, 225);
            label4.Name = "label4";
            label4.Size = new Size(64, 17);
            label4.TabIndex = 3;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(28, 300);
            label5.Name = "label5";
            label5.Size = new Size(115, 17);
            label5.TabIndex = 4;
            label5.Text = "Confirm password";
            label5.Click += label5_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 11.25F);
            btnCancel.Location = new Point(553, 446);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 40);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 11.25F);
            btnRegister.Location = new Point(249, 446);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(89, 40);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(181, 78);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(157, 25);
            txtPhone.TabIndex = 8;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(181, 222);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(157, 25);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(181, 297);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(157, 25);
            txtConfirm.TabIndex = 10;
            txtConfirm.UseSystemPasswordChar = true;
            txtConfirm.TextChanged += txtConfirm_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(181, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(157, 25);
            txtName.TabIndex = 11;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // cmbChurch
            // 
            cmbChurch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChurch.FormattingEnabled = true;
            cmbChurch.Location = new Point(181, 149);
            cmbChurch.Name = "cmbChurch";
            cmbChurch.Size = new Size(157, 25);
            cmbChurch.TabIndex = 12;
            cmbChurch.SelectedIndexChanged += cmbChurch_SelectedIndexChanged;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.BackColor = Color.Red;
            lblError.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.Location = new Point(28, 390);
            lblError.Name = "lblError";
            lblError.Size = new Size(51, 20);
            lblError.TabIndex = 13;
            lblError.Text = "empty";
            lblError.Click += lblError_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 510);
            Controls.Add(lblError);
            Controls.Add(cmbChurch);
            Controls.Add(txtName);
            Controls.Add(txtConfirm);
            Controls.Add(txtPassword);
            Controls.Add(txtPhone);
            Controls.Add(btnRegister);
            Controls.Add(btnCancel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblPhone);
            Controls.Add(lblName);
            Font = new Font("Segoe UI", 9.75F);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private Label lblName;
        private Label lblPhone;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnCancel;
        private Button btnRegister;
        private TextBox txtPhone;
        private TextBox txtPassword;
        private TextBox txtConfirm;
        private TextBox txtName;
        private ComboBox cmbChurch;
        private Label lblError;
    }
}