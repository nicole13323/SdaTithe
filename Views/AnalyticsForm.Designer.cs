namespace SdaTithe.Views
{
    partial class AnalyticsForm
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
            lblChurch = new Label();
            label2 = new Label();
            lblInactive = new Label();
            lblAvg = new Label();
            lblMembers = new Label();
            lblMonth = new Label();
            lblYear = new Label();
            cmbChurch = new ComboBox();
            lstInactive = new ListBox();
            pnlTrend = new Panel();
            pnlMethods = new Panel();
            dgvRanking = new DataGridView();
            btnClose = new Button();
            lblActive = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRanking).BeginInit();
            SuspendLayout();
            // 
            // lblChurch
            // 
            lblChurch.AutoSize = true;
            lblChurch.Location = new Point(26, 181);
            lblChurch.Name = "lblChurch";
            lblChurch.Size = new Size(46, 15);
            lblChurch.TabIndex = 0;
            lblChurch.Text = "Church";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(560, 9);
            label2.Name = "label2";
            label2.Size = new Size(144, 15);
            label2.TabIndex = 1;
            label2.Text = "Church ranking (this year)";
            // 
            // lblInactive
            // 
            lblInactive.AutoSize = true;
            lblInactive.Location = new Point(83, 9);
            lblInactive.Name = "lblInactive";
            lblInactive.Size = new Size(38, 15);
            lblInactive.TabIndex = 2;
            lblInactive.Text = "label3";
            lblInactive.Click += lblInactive_Click;
            // 
            // lblAvg
            // 
            lblAvg.AutoSize = true;
            lblAvg.Location = new Point(26, 363);
            lblAvg.Name = "lblAvg";
            lblAvg.Size = new Size(38, 15);
            lblAvg.TabIndex = 3;
            lblAvg.Text = "label4";
            lblAvg.Click += lblAvg_Click;
            // 
            // lblMembers
            // 
            lblMembers.AutoSize = true;
            lblMembers.Location = new Point(26, 298);
            lblMembers.Name = "lblMembers";
            lblMembers.Size = new Size(38, 15);
            lblMembers.TabIndex = 5;
            lblMembers.Text = "label6";
            lblMembers.Click += lblMembers_Click;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(26, 259);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(38, 15);
            lblMonth.TabIndex = 6;
            lblMonth.Text = "label7";
            lblMonth.Click += lblMonth_Click;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYear.Location = new Point(26, 225);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(40, 15);
            lblYear.TabIndex = 7;
            lblYear.Text = "label8";
            // 
            // cmbChurch
            // 
            cmbChurch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChurch.FormattingEnabled = true;
            cmbChurch.Location = new Point(96, 173);
            cmbChurch.Name = "cmbChurch";
            cmbChurch.Size = new Size(156, 23);
            cmbChurch.TabIndex = 8;
            // 
            // lstInactive
            // 
            lstInactive.FormattingEnabled = true;
            lstInactive.Location = new Point(50, 36);
            lstInactive.Name = "lstInactive";
            lstInactive.Size = new Size(250, 94);
            lstInactive.TabIndex = 9;
            // 
            // pnlTrend
            // 
            pnlTrend.Location = new Point(12, 349);
            pnlTrend.Name = "pnlTrend";
            pnlTrend.Size = new Size(557, 271);
            pnlTrend.TabIndex = 10;
            // 
            // pnlMethods
            // 
            pnlMethods.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMethods.Location = new Point(595, 349);
            pnlMethods.Name = "pnlMethods";
            pnlMethods.Size = new Size(327, 271);
            pnlMethods.TabIndex = 11;
            pnlMethods.Paint += pnlMethods_Paint;
            // 
            // dgvRanking
            // 
            dgvRanking.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRanking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRanking.Location = new Point(362, 36);
            dgvRanking.Name = "dgvRanking";
            dgvRanking.Size = new Size(560, 210);
            dgvRanking.TabIndex = 12;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(429, 626);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 13;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageAboveText;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Location = new Point(26, 331);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(38, 15);
            lblActive.TabIndex = 14;
            lblActive.Text = "label5";
            lblActive.Click += lblActive_Click;
            // 
            // AnalyticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 661);
            Controls.Add(lblActive);
            Controls.Add(btnClose);
            Controls.Add(dgvRanking);
            Controls.Add(pnlMethods);
            Controls.Add(pnlTrend);
            Controls.Add(lstInactive);
            Controls.Add(cmbChurch);
            Controls.Add(lblYear);
            Controls.Add(lblMonth);
            Controls.Add(lblMembers);
            Controls.Add(lblAvg);
            Controls.Add(lblInactive);
            Controls.Add(label2);
            Controls.Add(lblChurch);
            Name = "AnalyticsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Analytics";
            Load += AnalyticsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRanking).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChurch;
        private Label label2;
        private Label lblInactive;
        private Label lblAvg;
        private Label lblMembers;
        private Label lblMonth;
        private Label lblYear;
        private ComboBox cmbChurch;
        private ListBox lstInactive;
        private Panel pnlTrend;
        private Panel pnlMethods;
        private DataGridView dgvRanking;
        private Button btnClose;
        private Label lblActive;
    }
}