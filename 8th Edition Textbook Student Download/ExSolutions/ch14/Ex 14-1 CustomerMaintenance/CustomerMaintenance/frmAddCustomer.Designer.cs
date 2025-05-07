namespace CustomerMaintenance
{
    partial class frmAddCustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCompanyOrPhone = new System.Windows.Forms.TextBox();
            this.lblCompanyOrPhone = new System.Windows.Forms.Label();
            this.rbWholesale = new System.Windows.Forms.RadioButton();
            this.rbRetail = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(106, 35);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFirstName.MaxLength = 30;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(176, 23);
            this.txtFirstName.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(106, 65);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastName.MaxLength = 30;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(176, 23);
            this.txtLastName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(106, 96);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.MaxLength = 30;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(176, 23);
            this.txtEmail.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(106, 158);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(207, 158);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCompanyOrPhone
            // 
            this.txtCompanyOrPhone.Location = new System.Drawing.Point(106, 127);
            this.txtCompanyOrPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompanyOrPhone.MaxLength = 30;
            this.txtCompanyOrPhone.Name = "txtCompanyOrPhone";
            this.txtCompanyOrPhone.Size = new System.Drawing.Size(176, 23);
            this.txtCompanyOrPhone.TabIndex = 9;
            // 
            // lblCompanyOrPhone
            // 
            this.lblCompanyOrPhone.AutoSize = true;
            this.lblCompanyOrPhone.Location = new System.Drawing.Point(22, 130);
            this.lblCompanyOrPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyOrPhone.Name = "lblCompanyOrPhone";
            this.lblCompanyOrPhone.Size = new System.Drawing.Size(62, 15);
            this.lblCompanyOrPhone.TabIndex = 8;
            this.lblCompanyOrPhone.Text = "Company:";
            // 
            // rbWholesale
            // 
            this.rbWholesale.AutoSize = true;
            this.rbWholesale.Checked = true;
            this.rbWholesale.Location = new System.Drawing.Point(106, 8);
            this.rbWholesale.Margin = new System.Windows.Forms.Padding(2);
            this.rbWholesale.Name = "rbWholesale";
            this.rbWholesale.Size = new System.Drawing.Size(79, 19);
            this.rbWholesale.TabIndex = 0;
            this.rbWholesale.TabStop = true;
            this.rbWholesale.Text = "Wholesale";
            this.rbWholesale.UseVisualStyleBackColor = true;
            this.rbWholesale.CheckedChanged += new System.EventHandler(this.rdoWholesale_CheckedChanged);
            // 
            // rbRetail
            // 
            this.rbRetail.AutoSize = true;
            this.rbRetail.Location = new System.Drawing.Point(225, 8);
            this.rbRetail.Margin = new System.Windows.Forms.Padding(2);
            this.rbRetail.Name = "rbRetail";
            this.rbRetail.Size = new System.Drawing.Size(54, 19);
            this.rbRetail.TabIndex = 1;
            this.rbRetail.Text = "Retail";
            this.rbRetail.UseVisualStyleBackColor = true;
            // 
            // frmAddCustomer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 195);
            this.ControlBox = false;
            this.Controls.Add(this.rbRetail);
            this.Controls.Add(this.rbWholesale);
            this.Controls.Add(this.txtCompanyOrPhone);
            this.Controls.Add(this.lblCompanyOrPhone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmAddCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtCompanyOrPhone;
        private Label lblCompanyOrPhone;
        private RadioButton rbWholesale;
        private RadioButton rbRetail;
    }
}