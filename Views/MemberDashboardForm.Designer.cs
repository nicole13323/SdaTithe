namespace SdaTithe.Views
{
    partial class MemberDashboardForm
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
            lblYear = new Label();
            lblTotal = new Label();
            lblCount = new Label();
            label5 = new Label();
            label6 = new Label();
            lblError = new Label();
            btnPay = new Button();
            btnReceipt = new Button();
            btnLogout = new Button();
            dgvHistory = new DataGridView();
            cmbMethod = new ComboBox();
            txtAmount = new TextBox();
            cmbLanguage = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(251, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(93, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(12, 76);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(29, 15);
            lblYear.TabIndex = 1;
            lblYear.Text = "Year";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 138);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(32, 15);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(12, 197);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(40, 15);
            lblCount.TabIndex = 3;
            lblCount.Text = "Count";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 260);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 4;
            label5.Text = "Amount (RWF)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 306);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 5;
            label6.Text = "Method";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(12, 359);
            lblError.Name = "lblError";
            lblError.Size = new Size(41, 15);
            lblError.TabIndex = 6;
            lblError.Text = "empty";
            // 
            // btnPay
            // 
            btnPay.Font = new Font("Segoe UI", 9.75F);
            btnPay.Location = new Point(169, 397);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(96, 34);
            btnPay.TabIndex = 7;
            btnPay.Text = "Pay tithe";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // btnReceipt
            // 
            btnReceipt.Font = new Font("Segoe UI", 9.75F);
            btnReceipt.Location = new Point(389, 397);
            btnReceipt.Name = "btnReceipt";
            btnReceipt.Size = new Size(94, 34);
            btnReceipt.TabIndex = 8;
            btnReceipt.Text = "View receipt";
            btnReceipt.UseVisualStyleBackColor = true;
            btnReceipt.Click += btnReceipt_Click;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 9.75F);
            btnLogout.Location = new Point(644, 397);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(83, 34);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // dgvHistory
            // 
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(314, 60);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.Size = new Size(474, 284);
            dgvHistory.TabIndex = 10;
            // 
            // cmbMethod
            // 
            cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMethod.FormattingEnabled = true;
            cmbMethod.Location = new Point(144, 298);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(121, 23);
            cmbMethod.TabIndex = 11;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(144, 257);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 12;
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(667, 9);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(121, 23);
            cmbLanguage.TabIndex = 13;
            // 
            // MemberDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbLanguage);
            Controls.Add(txtAmount);
            Controls.Add(cmbMethod);
            Controls.Add(dgvHistory);
            Controls.Add(btnLogout);
            Controls.Add(btnReceipt);
            Controls.Add(btnPay);
            Controls.Add(lblError);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lblCount);
            Controls.Add(lblTotal);
            Controls.Add(lblYear);
            Controls.Add(lblWelcome);
            Name = "MemberDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Dashboard";
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblYear;
        private Label lblTotal;
        private Label lblCount;
        private Label label5;
        private Label label6;
        private Label lblError;
        private Button btnPay;
        private Button btnReceipt;
        private Button btnLogout;
        private DataGridView dgvHistory;
        private ComboBox cmbMethod;
        private TextBox txtAmount;
        private ComboBox cmbLanguage;
    }
}