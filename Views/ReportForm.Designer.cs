namespace SdaTithe.Views
{
    partial class ReportForm
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
            label3 = new Label();
            label5 = new Label();
            cmbView = new ComboBox();
            cmbChurch = new ComboBox();
            cmbPeriod = new ComboBox();
            dtpDate = new DateTimePicker();
            btnPrint = new Button();
            btnClose = new Button();
            dgvDetails = new DataGridView();
            lblSummary = new Label();
            pnlChart = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // lblChurch
            // 
            lblChurch.AutoSize = true;
            lblChurch.Location = new Point(12, 28);
            lblChurch.Name = "lblChurch";
            lblChurch.Size = new Size(46, 15);
            lblChurch.TabIndex = 0;
            lblChurch.Text = "Church";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Period";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 135);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 2;
            label3.Text = "Date in period";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 226);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 4;
            label5.Text = "Show";
            label5.Click += label5_Click;
            // 
            // cmbView
            // 
            cmbView.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbView.FormattingEnabled = true;
            cmbView.Location = new Point(163, 218);
            cmbView.Name = "cmbView";
            cmbView.Size = new Size(171, 23);
            cmbView.TabIndex = 5;
            // 
            // cmbChurch
            // 
            cmbChurch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChurch.FormattingEnabled = true;
            cmbChurch.Location = new Point(163, 25);
            cmbChurch.Name = "cmbChurch";
            cmbChurch.Size = new Size(160, 23);
            cmbChurch.TabIndex = 6;
            // 
            // cmbPeriod
            // 
            cmbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriod.FormattingEnabled = true;
            cmbPeriod.Location = new Point(163, 79);
            cmbPeriod.Name = "cmbPeriod";
            cmbPeriod.Size = new Size(160, 23);
            cmbPeriod.TabIndex = 7;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(163, 129);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(160, 23);
            dtpDate.TabIndex = 9;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(136, 569);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(101, 30);
            btnPrint.TabIndex = 11;
            btnPrint.Text = "Print / Save as PDF";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(572, 569);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(87, 30);
            btnClose.TabIndex = 12;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dgvDetails
            // 
            dgvDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Location = new Point(360, 28);
            dgvDetails.MaximumSize = new Size(800, 550);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.Size = new Size(467, 215);
            dgvDetails.TabIndex = 14;
            dgvDetails.CellContentClick += dgvDetails_CellContentClick;
            // 
            // lblSummary
            // 
            lblSummary.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSummary.Location = new Point(12, 167);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(108, 32);
            lblSummary.TabIndex = 15;
            lblSummary.Click += lblSummary_Click;
            // 
            // pnlChart
            // 
            pnlChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlChart.Location = new Point(47, 285);
            pnlChart.MaximumSize = new Size(800, 550);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(800, 254);
            pnlChart.TabIndex = 16;
            pnlChart.Paint += pnlChart_Paint;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 611);
            Controls.Add(pnlChart);
            Controls.Add(lblSummary);
            Controls.Add(dgvDetails);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(dtpDate);
            Controls.Add(cmbPeriod);
            Controls.Add(cmbChurch);
            Controls.Add(cmbView);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblChurch);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports";
            Load += ReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChurch;
        private Label label2;
        private Label label3;
        private Label label5;
        private ComboBox cmbView;
        private ComboBox cmbChurch;
        private ComboBox cmbPeriod;
        private DateTimePicker dtpDate;
        private Button btnPrint;
        private Button btnClose;
        private DataGridView dgvDetails;
        private Label lblSummary;
        private Panel pnlChart;
    }
}