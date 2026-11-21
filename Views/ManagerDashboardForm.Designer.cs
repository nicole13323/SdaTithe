namespace SdaTithe.Views
{
    partial class ManagerDashboardForm
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
            lblWelcome = new Label();
            btnLogout = new Button();
            lblChurch = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAdd = new Button();
            btnPayOwn = new Button();
            btnDelete = new Button();
            btnCash = new Button();
            dgvMembers = new DataGridView();
            cmbChurch = new ComboBox();
            txtNewName = new TextBox();
            txtSearch = new TextBox();
            txtNewPhone = new TextBox();
            lblError = new Label();
            btnReports = new Button();
            btnAnalytics = new Button();
            cmbLanguage = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(310, -2);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(126, 46);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "WELCOME";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(771, 404);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(101, 30);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblChurch
            // 
            lblChurch.AutoSize = true;
            lblChurch.Font = new Font("Segoe UI", 9.75F);
            lblChurch.Location = new Point(29, 73);
            lblChurch.Name = "lblChurch";
            lblChurch.Size = new Size(48, 17);
            lblChurch.TabIndex = 2;
            lblChurch.Text = "Church";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(29, 124);
            label2.Name = "label2";
            label2.Size = new Size(47, 17);
            label2.TabIndex = 3;
            label2.Text = "Search";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(29, 197);
            label3.Name = "label3";
            label3.Size = new Size(87, 17);
            label3.TabIndex = 4;
            label3.Text = "New member";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(29, 273);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 5;
            label4.Text = "Phone";
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 11.25F);
            btnAdd.Location = new Point(12, 408);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 30);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add member";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnPayOwn
            // 
            btnPayOwn.Font = new Font("Segoe UI", 11.25F);
            btnPayOwn.Location = new Point(391, 405);
            btnPayOwn.Name = "btnPayOwn";
            btnPayOwn.Size = new Size(82, 33);
            btnPayOwn.TabIndex = 7;
            btnPayOwn.Text = "Pay";
            btnPayOwn.UseVisualStyleBackColor = true;
            btnPayOwn.Click += btnPayOwn_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11.25F);
            btnDelete.Location = new Point(122, 408);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 30);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete selected";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCash
            // 
            btnCash.Font = new Font("Segoe UI", 11.25F);
            btnCash.Location = new Point(235, 405);
            btnCash.Name = "btnCash";
            btnCash.Size = new Size(104, 33);
            btnCash.TabIndex = 9;
            btnCash.Text = "Record cash";
            btnCash.UseVisualStyleBackColor = true;
            btnCash.Click += btnCash_Click;
            // 
            // dgvMembers
            // 
            dgvMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Location = new Point(361, 70);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.Size = new Size(486, 243);
            dgvMembers.TabIndex = 10;
            // 
            // cmbChurch
            // 
            cmbChurch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChurch.FormattingEnabled = true;
            cmbChurch.Location = new Point(169, 70);
            cmbChurch.Name = "cmbChurch";
            cmbChurch.Size = new Size(129, 23);
            cmbChurch.TabIndex = 11;
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(169, 189);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(129, 23);
            txtNewName.TabIndex = 12;
            txtNewName.Text = "name";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(169, 116);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(129, 23);
            txtSearch.TabIndex = 13;
            // 
            // txtNewPhone
            // 
            txtNewPhone.Location = new Point(169, 267);
            txtNewPhone.Name = "txtNewPhone";
            txtNewPhone.Size = new Size(129, 23);
            txtNewPhone.TabIndex = 14;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.BackColor = Color.Red;
            lblError.Font = new Font("Segoe UI", 9.75F);
            lblError.Location = new Point(46, 356);
            lblError.Name = "lblError";
            lblError.Size = new Size(44, 17);
            lblError.TabIndex = 15;
            lblError.Text = "Empty";
            // 
            // btnReports
            // 
            btnReports.Font = new Font("Segoe UI", 11.25F);
            btnReports.Location = new Point(531, 407);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(82, 33);
            btnReports.TabIndex = 16;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            // 
            // btnAnalytics
            // 
            btnAnalytics.Font = new Font("Segoe UI", 11.25F);
            btnAnalytics.Location = new Point(660, 408);
            btnAnalytics.Name = "btnAnalytics";
            btnAnalytics.Size = new Size(82, 33);
            btnAnalytics.TabIndex = 17;
            btnAnalytics.Text = "Analytics";
            btnAnalytics.UseVisualStyleBackColor = true;
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(751, 14);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(121, 23);
            cmbLanguage.TabIndex = 18;
            // 
            // ManagerDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 450);
            Controls.Add(cmbLanguage);
            Controls.Add(btnAnalytics);
            Controls.Add(btnReports);
            Controls.Add(lblError);
            Controls.Add(txtNewPhone);
            Controls.Add(txtSearch);
            Controls.Add(txtNewName);
            Controls.Add(cmbChurch);
            Controls.Add(dgvMembers);
            Controls.Add(btnCash);
            Controls.Add(btnDelete);
            Controls.Add(btnPayOwn);
            Controls.Add(btnAdd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblChurch);
            Controls.Add(btnLogout);
            Controls.Add(lblWelcome);
            Name = "ManagerDashboardForm";
            Text = "ManagerDashboardForm";
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnLogout;
        private Label lblChurch;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnAdd;
        private Button btnPayOwn;
        private Button btnDelete;
        private Button btnCash;
        private DataGridView dgvMembers;
        private ComboBox cmbChurch;
        private TextBox txtNewName;
        private TextBox txtSearch;
        private TextBox txtNewPhone;
        private Label lblError;
        private Button btnReports;
        private Button btnAnalytics;
        private ComboBox cmbLanguage;
    }
}