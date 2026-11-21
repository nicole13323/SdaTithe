namespace SdaTithe.Views
{
    partial class ReceiptForm
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
            lblReceipt = new Label();
            btnClose = new Button();
            btnPrint = new Button();
            SuspendLayout();
            // 
            // lblReceipt
            // 
            lblReceipt.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReceipt.Location = new Point(195, 48);
            lblReceipt.Name = "lblReceipt";
            lblReceipt.Size = new Size(360, 220);
            lblReceipt.TabIndex = 0;
            lblReceipt.Text = "Receipt";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 11.25F);
            btnClose.Location = new Point(491, 322);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 35);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.Font = new Font("Segoe UI", 11.25F);
            btnPrint.Location = new Point(205, 322);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(128, 35);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "Print / Save as PDF";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPrint);
            Controls.Add(btnClose);
            Controls.Add(lblReceipt);
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receipt";
            ResumeLayout(false);
        }

        #endregion

        private Label lblReceipt;
        private Button btnClose;
        private Button btnPrint;
    }
}