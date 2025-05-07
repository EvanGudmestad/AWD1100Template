namespace FinancialCalculations
{
    partial class frmInvestment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoMonthlyInvestment = new System.Windows.Forms.RadioButton();
            this.rdoFutureValue = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.txtMonthlyInvestment = new System.Windows.Forms.TextBox();
            this.txtFutureValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoMonthlyInvestment);
            this.groupBox1.Controls.Add(this.rdoFutureValue);
            this.groupBox1.Location = new System.Drawing.Point(19, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(303, 58);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculate";
            // 
            // rdoMonthlyInvestment
            // 
            this.rdoMonthlyInvestment.Location = new System.Drawing.Point(149, 28);
            this.rdoMonthlyInvestment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rdoMonthlyInvestment.Name = "rdoMonthlyInvestment";
            this.rdoMonthlyInvestment.Size = new System.Drawing.Size(140, 24);
            this.rdoMonthlyInvestment.TabIndex = 1;
            this.rdoMonthlyInvestment.Text = "Monthly investment";
            this.rdoMonthlyInvestment.CheckedChanged += new System.EventHandler(this.rdoMonthlyInvestment_CheckedChanged);
            // 
            // rdoFutureValue
            // 
            this.rdoFutureValue.Checked = true;
            this.rdoFutureValue.Location = new System.Drawing.Point(19, 28);
            this.rdoFutureValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rdoFutureValue.Name = "rdoFutureValue";
            this.rdoFutureValue.Size = new System.Drawing.Size(110, 24);
            this.rdoFutureValue.TabIndex = 0;
            this.rdoFutureValue.TabStop = true;
            this.rdoFutureValue.Text = "Future value";
            this.rdoFutureValue.CheckedChanged += new System.EventHandler(this.rdoFutureValue_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(235, 200);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 27);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(130, 200);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(88, 27);
            this.btnCalculate.TabIndex = 26;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtYears
            // 
            this.txtYears.Location = new System.Drawing.Point(172, 135);
            this.txtYears.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtYears.Name = "txtYears";
            this.txtYears.Size = new System.Drawing.Size(131, 23);
            this.txtYears.TabIndex = 23;
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(172, 107);
            this.txtInterestRate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(131, 23);
            this.txtInterestRate.TabIndex = 20;
            // 
            // txtMonthlyInvestment
            // 
            this.txtMonthlyInvestment.Location = new System.Drawing.Point(172, 80);
            this.txtMonthlyInvestment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMonthlyInvestment.Name = "txtMonthlyInvestment";
            this.txtMonthlyInvestment.Size = new System.Drawing.Size(131, 23);
            this.txtMonthlyInvestment.TabIndex = 18;
            // 
            // txtFutureValue
            // 
            this.txtFutureValue.Location = new System.Drawing.Point(172, 163);
            this.txtFutureValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFutureValue.Name = "txtFutureValue";
            this.txtFutureValue.ReadOnly = true;
            this.txtFutureValue.Size = new System.Drawing.Size(131, 23);
            this.txtFutureValue.TabIndex = 25;
            this.txtFutureValue.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "Future value:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Number of years:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Yearly interest rate:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Monthly investment:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmInvestment
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(342, 241);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtYears);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.txtMonthlyInvestment);
            this.Controls.Add(this.txtFutureValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmInvestment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculate Investment";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rdoMonthlyInvestment;
        private RadioButton rdoFutureValue;
        private Button btnExit;
        private Button btnCalculate;
        private TextBox txtYears;
        private TextBox txtInterestRate;
        private TextBox txtMonthlyInvestment;
        private TextBox txtFutureValue;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}