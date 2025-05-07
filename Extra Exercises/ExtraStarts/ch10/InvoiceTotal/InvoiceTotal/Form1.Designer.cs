namespace InvoiceTotal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtProductTotal = new TextBox();
            txtDiscountAmount = new TextBox();
            label2 = new Label();
            txtSubtotal = new TextBox();
            label3 = new Label();
            txtTax = new TextBox();
            label4 = new Label();
            txtTotal = new TextBox();
            label5 = new Label();
            btnCalculate = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 19);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Product total:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtProductTotal
            // 
            txtProductTotal.Location = new Point(130, 18);
            txtProductTotal.Margin = new Padding(2);
            txtProductTotal.Name = "txtProductTotal";
            txtProductTotal.Size = new Size(106, 23);
            txtProductTotal.TabIndex = 1;
            // 
            // txtDiscountAmount
            // 
            txtDiscountAmount.Location = new Point(130, 44);
            txtDiscountAmount.Margin = new Padding(2);
            txtDiscountAmount.Name = "txtDiscountAmount";
            txtDiscountAmount.ReadOnly = true;
            txtDiscountAmount.Size = new Size(106, 23);
            txtDiscountAmount.TabIndex = 3;
            txtDiscountAmount.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 46);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 2;
            label2.Text = "Discount amount:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(130, 70);
            txtSubtotal.Margin = new Padding(2);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(106, 23);
            txtSubtotal.TabIndex = 5;
            txtSubtotal.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 72);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 4;
            label3.Text = "Subtotal:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTax
            // 
            txtTax.Location = new Point(130, 97);
            txtTax.Margin = new Padding(2);
            txtTax.Name = "txtTax";
            txtTax.ReadOnly = true;
            txtTax.Size = new Size(106, 23);
            txtTax.TabIndex = 7;
            txtTax.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 100);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 6;
            label4.Text = "Tax (7.75%):";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(130, 124);
            txtTotal.Margin = new Padding(2);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(106, 23);
            txtTotal.TabIndex = 9;
            txtTotal.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 127);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 8;
            label5.Text = "Total:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(24, 161);
            btnCalculate.Margin = new Padding(2);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(75, 23);
            btnCalculate.TabIndex = 10;
            btnCalculate.Text = "&Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(161, 161);
            btnExit.Margin = new Padding(2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 11;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AcceptButton = btnCalculate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(366, 199);
            Controls.Add(btnExit);
            Controls.Add(btnCalculate);
            Controls.Add(txtTotal);
            Controls.Add(label5);
            Controls.Add(txtTax);
            Controls.Add(label4);
            Controls.Add(txtSubtotal);
            Controls.Add(label3);
            Controls.Add(txtDiscountAmount);
            Controls.Add(label2);
            Controls.Add(txtProductTotal);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Invoice Total";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProductTotal;
        private TextBox txtDiscountAmount;
        private Label label2;
        private TextBox txtSubtotal;
        private Label label3;
        private TextBox txtTax;
        private Label label4;
        private TextBox txtTotal;
        private Label label5;
        private Button btnCalculate;
        private Button btnExit;
    }
}