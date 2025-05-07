namespace ScoreCalculator
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
            txtScore = new TextBox();
            btnAdd = new Button();
            txtScoreTotal = new TextBox();
            label2 = new Label();
            txtScoreCount = new TextBox();
            label3 = new Label();
            txtAverage = new TextBox();
            label4 = new Label();
            btnClear = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Score:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtScore
            // 
            txtScore.Location = new Point(106, 21);
            txtScore.Margin = new Padding(2, 2, 2, 2);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(47, 23);
            txtScore.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(170, 20);
            btnAdd.Margin = new Padding(2, 2, 2, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtScoreTotal
            // 
            txtScoreTotal.Location = new Point(106, 50);
            txtScoreTotal.Margin = new Padding(2, 2, 2, 2);
            txtScoreTotal.Name = "txtScoreTotal";
            txtScoreTotal.ReadOnly = true;
            txtScoreTotal.Size = new Size(47, 23);
            txtScoreTotal.TabIndex = 4;
            txtScoreTotal.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 52);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 3;
            label2.Text = "Score total:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtScoreCount
            // 
            txtScoreCount.Location = new Point(106, 79);
            txtScoreCount.Margin = new Padding(2, 2, 2, 2);
            txtScoreCount.Name = "txtScoreCount";
            txtScoreCount.ReadOnly = true;
            txtScoreCount.Size = new Size(47, 23);
            txtScoreCount.TabIndex = 6;
            txtScoreCount.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 80);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 5;
            label3.Text = "Score count:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAverage
            // 
            txtAverage.Location = new Point(106, 107);
            txtAverage.Margin = new Padding(2, 2, 2, 2);
            txtAverage.Name = "txtAverage";
            txtAverage.ReadOnly = true;
            txtAverage.Size = new Size(47, 23);
            txtAverage.TabIndex = 8;
            txtAverage.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 109);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 7;
            label4.Text = "Average:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(73, 143);
            btnClear.Margin = new Padding(2, 2, 2, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 2;
            btnClear.Text = "&Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(170, 143);
            btnExit.Margin = new Padding(2, 2, 2, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 3;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(273, 185);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(txtAverage);
            Controls.Add(label4);
            Controls.Add(txtScoreCount);
            Controls.Add(label3);
            Controls.Add(txtScoreTotal);
            Controls.Add(label2);
            Controls.Add(btnAdd);
            Controls.Add(txtScore);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Score Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtScore;
        private Button btnAdd;
        private TextBox txtScoreTotal;
        private Label label2;
        private TextBox txtScoreCount;
        private Label label3;
        private TextBox txtAverage;
        private Label label4;
        private Button btnClear;
        private Button btnExit;
    }
}