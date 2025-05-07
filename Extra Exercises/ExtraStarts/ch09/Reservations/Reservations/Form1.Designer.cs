namespace Reservations
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
            txtArrivalDate = new TextBox();
            txtDepartureDate = new TextBox();
            label2 = new Label();
            txtNights = new TextBox();
            label3 = new Label();
            txtTotalPrice = new TextBox();
            label4 = new Label();
            txtAvgPrice = new TextBox();
            label5 = new Label();
            btnCalculate = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 28);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Arrival date:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtArrivalDate
            // 
            txtArrivalDate.Location = new Point(165, 26);
            txtArrivalDate.Margin = new Padding(2, 2, 2, 2);
            txtArrivalDate.Name = "txtArrivalDate";
            txtArrivalDate.Size = new Size(106, 23);
            txtArrivalDate.TabIndex = 1;
            // 
            // txtDepartureDate
            // 
            txtDepartureDate.Location = new Point(165, 57);
            txtDepartureDate.Margin = new Padding(2, 2, 2, 2);
            txtDepartureDate.Name = "txtDepartureDate";
            txtDepartureDate.Size = new Size(106, 23);
            txtDepartureDate.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 59);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 2;
            label2.Text = "Departure date:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNights
            // 
            txtNights.Location = new Point(165, 88);
            txtNights.Margin = new Padding(2, 2, 2, 2);
            txtNights.Name = "txtNights";
            txtNights.ReadOnly = true;
            txtNights.Size = new Size(106, 23);
            txtNights.TabIndex = 5;
            txtNights.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 90);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 4;
            label3.Text = "Number of nights:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(165, 119);
            txtTotalPrice.Margin = new Padding(2, 2, 2, 2);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.ReadOnly = true;
            txtTotalPrice.Size = new Size(106, 23);
            txtTotalPrice.TabIndex = 7;
            txtTotalPrice.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 120);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 6;
            label4.Text = "Total price:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAvgPrice
            // 
            txtAvgPrice.Location = new Point(165, 151);
            txtAvgPrice.Margin = new Padding(2, 2, 2, 2);
            txtAvgPrice.Name = "txtAvgPrice";
            txtAvgPrice.ReadOnly = true;
            txtAvgPrice.Size = new Size(106, 23);
            txtAvgPrice.TabIndex = 9;
            txtAvgPrice.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 152);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(111, 15);
            label5.TabIndex = 8;
            label5.Text = "Avg price per night:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(37, 193);
            btnCalculate.Margin = new Padding(2, 2, 2, 2);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(75, 23);
            btnCalculate.TabIndex = 3;
            btnCalculate.Text = "&Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(196, 193);
            btnExit.Margin = new Padding(2, 2, 2, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 4;
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
            ClientSize = new Size(311, 242);
            Controls.Add(btnExit);
            Controls.Add(btnCalculate);
            Controls.Add(txtAvgPrice);
            Controls.Add(label5);
            Controls.Add(txtTotalPrice);
            Controls.Add(label4);
            Controls.Add(txtNights);
            Controls.Add(label3);
            Controls.Add(txtDepartureDate);
            Controls.Add(label2);
            Controls.Add(txtArrivalDate);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reservations";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtArrivalDate;
        private TextBox txtDepartureDate;
        private Label label2;
        private TextBox txtNights;
        private Label label3;
        private TextBox txtTotalPrice;
        private Label label4;
        private TextBox txtAvgPrice;
        private Label label5;
        private Button btnCalculate;
        private Button btnExit;
    }
}