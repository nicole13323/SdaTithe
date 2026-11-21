namespace SdaTithe.Views
{
    partial class PaymentForm
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
            lblTarget = new Label();
            label2 = new Label();
            lblDate = new Label();
            lblMethod = new Label();
            lblError = new Label();
            txtAmount = new TextBox();
            dtpDate = new DateTimePicker();
            btnSave = new Button();
            cmbMethod = new ComboBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTarget
            // 
            lblTarget.AutoSize = true;
            lblTarget.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTarget.Location = new Point(366, 31);
            lblTarget.Name = "lblTarget";
            lblTarget.Size = new Size(68, 25);
            lblTarget.TabIndex = 0;
            lblTarget.Text = "Target";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(91, 17);
            label2.TabIndex = 1;
            label2.Text = "Amount (RWF)";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9.75F);
            lblDate.Location = new Point(12, 170);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(35, 17);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date";
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Font = new Font("Segoe UI", 9.75F);
            lblMethod.Location = new Point(12, 257);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(54, 17);
            lblMethod.TabIndex = 3;
            lblMethod.Text = "Method";
            lblMethod.Click += lblMethod_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.BackColor = Color.Red;
            lblError.Font = new Font("Segoe UI", 9.75F);
            lblError.Location = new Point(12, 345);
            lblError.Name = "lblError";
            lblError.Size = new Size(44, 17);
            lblError.TabIndex = 4;
            lblError.Text = "Empty";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(129, 71);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(136, 23);
            txtAmount.TabIndex = 5;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(129, 162);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(136, 23);
            dtpDate.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11.25F);
            btnSave.Location = new Point(262, 403);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 35);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbMethod
            // 
            cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMethod.FormattingEnabled = true;
            cmbMethod.Location = new Point(129, 249);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(136, 23);
            cmbMethod.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 11.25F);
            btnCancel.Location = new Point(547, 403);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(cmbMethod);
            Controls.Add(btnSave);
            Controls.Add(dtpDate);
            Controls.Add(txtAmount);
            Controls.Add(lblError);
            Controls.Add(lblMethod);
            Controls.Add(lblDate);
            Controls.Add(label2);
            Controls.Add(lblTarget);
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTarget;
        private Label label2;
        private Label lblDate;
        private Label lblMethod;
        private Label lblError;
        private TextBox txtAmount;
        private DateTimePicker dtpDate;
        private Button btnSave;
        private ComboBox cmbMethod;
        private Button btnCancel;
    }
}