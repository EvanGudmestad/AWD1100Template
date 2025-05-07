namespace LengthConversions
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
            cboConversions = new ComboBox();
            lblFromLength = new Label();
            txtLength = new TextBox();
            txtCalculatedLength = new TextBox();
            lblToLength = new Label();
            btnCalculate = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 19);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Conversion:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboConversions
            // 
            cboConversions.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConversions.FormattingEnabled = true;
            cboConversions.Location = new Point(108, 17);
            cboConversions.Margin = new Padding(2);
            cboConversions.Name = "cboConversions";
            cboConversions.Size = new Size(164, 23);
            cboConversions.TabIndex = 1;
            // 
            // lblFromLength
            // 
            lblFromLength.AutoSize = true;
            lblFromLength.Location = new Point(22, 53);
            lblFromLength.Margin = new Padding(2, 0, 2, 0);
            lblFromLength.Name = "lblFromLength";
            lblFromLength.Size = new Size(38, 15);
            lblFromLength.TabIndex = 2;
            lblFromLength.Text = "Miles:";
            lblFromLength.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLength
            // 
            txtLength.Location = new Point(108, 51);
            txtLength.Margin = new Padding(2);
            txtLength.Name = "txtLength";
            txtLength.Size = new Size(106, 23);
            txtLength.TabIndex = 3;
            // 
            // txtCalculatedLength
            // 
            txtCalculatedLength.Location = new Point(108, 83);
            txtCalculatedLength.Margin = new Padding(2);
            txtCalculatedLength.Name = "txtCalculatedLength";
            txtCalculatedLength.ReadOnly = true;
            txtCalculatedLength.Size = new Size(106, 23);
            txtCalculatedLength.TabIndex = 5;
            txtCalculatedLength.TabStop = false;
            // 
            // lblToLength
            // 
            lblToLength.AutoSize = true;
            lblToLength.Location = new Point(22, 85);
            lblToLength.Margin = new Padding(2, 0, 2, 0);
            lblToLength.Name = "lblToLength";
            lblToLength.Size = new Size(66, 15);
            lblToLength.TabIndex = 4;
            lblToLength.Text = "Kilometers:";
            lblToLength.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(22, 122);
            btnCalculate.Margin = new Padding(2);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(75, 23);
            btnCalculate.TabIndex = 6;
            btnCalculate.Text = "&Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(197, 122);
            btnExit.Margin = new Padding(2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 7;
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
            ClientSize = new Size(298, 160);
            Controls.Add(btnExit);
            Controls.Add(btnCalculate);
            Controls.Add(txtCalculatedLength);
            Controls.Add(lblToLength);
            Controls.Add(txtLength);
            Controls.Add(lblFromLength);
            Controls.Add(cboConversions);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conversions";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboConversions;
        private Label lblFromLength;
        private TextBox txtLength;
        private TextBox txtCalculatedLength;
        private Label lblToLength;
        private Button btnCalculate;
        private Button btnExit;
    }
}