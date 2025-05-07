namespace StringHandling
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
            txtEmail = new TextBox();
            btnParse = new Button();
            txtCity = new TextBox();
            label2 = new Label();
            txtState = new TextBox();
            label3 = new Label();
            txtZipCode = new TextBox();
            label4 = new Label();
            btnFormat = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 28);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 25);
            txtEmail.Margin = new Padding(2, 2, 2, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(212, 23);
            txtEmail.TabIndex = 1;
            // 
            // btnParse
            // 
            btnParse.Location = new Point(335, 25);
            btnParse.Margin = new Padding(2, 2, 2, 2);
            btnParse.Name = "btnParse";
            btnParse.Size = new Size(75, 23);
            btnParse.TabIndex = 2;
            btnParse.Text = "&Parse";
            btnParse.UseVisualStyleBackColor = true;
            btnParse.Click += btnParse_Click;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(100, 95);
            txtCity.Margin = new Padding(2, 2, 2, 2);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(212, 23);
            txtCity.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 97);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 3;
            label2.Text = "City:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtState
            // 
            txtState.Location = new Point(100, 128);
            txtState.Margin = new Padding(2, 2, 2, 2);
            txtState.Name = "txtState";
            txtState.Size = new Size(40, 23);
            txtState.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 130);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 5;
            label3.Text = "State:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtZipCode
            // 
            txtZipCode.Location = new Point(100, 160);
            txtZipCode.Margin = new Padding(2, 2, 2, 2);
            txtZipCode.Name = "txtZipCode";
            txtZipCode.Size = new Size(106, 23);
            txtZipCode.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 162);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 7;
            label4.Text = "Zip code:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnFormat
            // 
            btnFormat.Location = new Point(335, 159);
            btnFormat.Margin = new Padding(2, 2, 2, 2);
            btnFormat.Name = "btnFormat";
            btnFormat.Size = new Size(75, 23);
            btnFormat.TabIndex = 9;
            btnFormat.Text = "&Format";
            btnFormat.UseVisualStyleBackColor = true;
            btnFormat.Click += btnFormat_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(335, 206);
            btnExit.Margin = new Padding(2, 2, 2, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 10;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(441, 247);
            Controls.Add(btnExit);
            Controls.Add(btnFormat);
            Controls.Add(txtZipCode);
            Controls.Add(label4);
            Controls.Add(txtState);
            Controls.Add(label3);
            Controls.Add(txtCity);
            Controls.Add(label2);
            Controls.Add(btnParse);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "String Handling";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEmail;
        private Button btnParse;
        private TextBox txtCity;
        private Label label2;
        private TextBox txtState;
        private Label label3;
        private TextBox txtZipCode;
        private Label label4;
        private Button btnFormat;
        private Button btnExit;
    }
}