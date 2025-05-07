namespace SimpleCalculator
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
            txtOperand1 = new TextBox();
            txtOperator = new TextBox();
            label2 = new Label();
            txtOperand2 = new TextBox();
            label3 = new Label();
            txtResult = new TextBox();
            label4 = new Label();
            btnCalculate = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 22);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Operand 1:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtOperand1
            // 
            txtOperand1.Location = new Point(130, 22);
            txtOperand1.Margin = new Padding(2, 2, 2, 2);
            txtOperand1.Name = "txtOperand1";
            txtOperand1.Size = new Size(106, 23);
            txtOperand1.TabIndex = 0;
            txtOperand1.TextChanged += ClearResult;
            // 
            // txtOperator
            // 
            txtOperator.Location = new Point(130, 51);
            txtOperator.Margin = new Padding(2, 2, 2, 2);
            txtOperator.Name = "txtOperator";
            txtOperator.Size = new Size(33, 23);
            txtOperator.TabIndex = 1;
            txtOperator.TextChanged += ClearResult;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 52);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Operator:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtOperand2
            // 
            txtOperand2.Location = new Point(130, 80);
            txtOperand2.Margin = new Padding(2, 2, 2, 2);
            txtOperand2.Name = "txtOperand2";
            txtOperand2.Size = new Size(106, 23);
            txtOperand2.TabIndex = 2;
            txtOperand2.TextChanged += ClearResult;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 83);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 4;
            label3.Text = "Operand 2:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(130, 109);
            txtResult.Margin = new Padding(2, 2, 2, 2);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(106, 23);
            txtResult.TabIndex = 4;
            txtResult.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 110);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 6;
            label4.Text = "Result:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(36, 148);
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
            btnExit.Location = new Point(161, 148);
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
            ClientSize = new Size(272, 189);
            Controls.Add(btnExit);
            Controls.Add(btnCalculate);
            Controls.Add(txtResult);
            Controls.Add(label4);
            Controls.Add(txtOperand2);
            Controls.Add(label3);
            Controls.Add(txtOperator);
            Controls.Add(label2);
            Controls.Add(txtOperand1);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simple Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtOperand1;
        private TextBox txtOperator;
        private Label label2;
        private TextBox txtOperand2;
        private Label label3;
        private TextBox txtResult;
        private Label label4;
        private Button btnCalculate;
        private Button btnExit;
    }
}