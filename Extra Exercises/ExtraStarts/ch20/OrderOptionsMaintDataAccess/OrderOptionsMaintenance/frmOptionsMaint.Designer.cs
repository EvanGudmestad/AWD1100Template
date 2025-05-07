namespace OrderOptionsMaintenance
{
    partial class frmOptionsMaint
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
            txtSalesTax = new TextBox();
            txtShipFirstBook = new TextBox();
            label2 = new Label();
            txtShipAddlBook = new TextBox();
            label3 = new Label();
            btnSave = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "Sales tax rate:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSalesTax
            // 
            txtSalesTax.Location = new Point(234, 21);
            txtSalesTax.Margin = new Padding(2, 2, 2, 2);
            txtSalesTax.Name = "txtSalesTax";
            txtSalesTax.Size = new Size(106, 23);
            txtSalesTax.TabIndex = 1;
            // 
            // txtShipFirstBook
            // 
            txtShipFirstBook.Location = new Point(234, 53);
            txtShipFirstBook.Margin = new Padding(2, 2, 2, 2);
            txtShipFirstBook.Name = "txtShipFirstBook";
            txtShipFirstBook.Size = new Size(106, 23);
            txtShipFirstBook.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 55);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(157, 15);
            label2.TabIndex = 2;
            label2.Text = "Shipping charge - first book:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtShipAddlBook
            // 
            txtShipAddlBook.Location = new Point(234, 85);
            txtShipAddlBook.Margin = new Padding(2, 2, 2, 2);
            txtShipAddlBook.Name = "txtShipAddlBook";
            txtShipAddlBook.Size = new Size(106, 23);
            txtShipAddlBook.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 86);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(191, 15);
            label3.TabIndex = 4;
            label3.Text = "Shipping charge - each add'l book:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 124);
            btnSave.Margin = new Padding(2, 2, 2, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(234, 124);
            btnExit.Margin = new Padding(2, 2, 2, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 7;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmOptionsMaint
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(368, 170);
            Controls.Add(btnExit);
            Controls.Add(btnSave);
            Controls.Add(txtShipAddlBook);
            Controls.Add(label3);
            Controls.Add(txtShipFirstBook);
            Controls.Add(label2);
            Controls.Add(txtSalesTax);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "frmOptionsMaint";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order Options Maintenance";
            Load += frmOptionsMaint_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSalesTax;
        private TextBox txtShipFirstBook;
        private Label label2;
        private TextBox txtShipAddlBook;
        private Label label3;
        private Button btnSave;
        private Button btnExit;
    }
}