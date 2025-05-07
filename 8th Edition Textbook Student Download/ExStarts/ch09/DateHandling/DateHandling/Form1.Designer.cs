namespace DateHandling;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFutureDate = new System.Windows.Forms.TextBox();
            this.btnCalculateDays = new System.Windows.Forms.Button();
            this.btnCalculateAge = new System.Windows.Forms.Button();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter a future date:";
            // 
            // txtFutureDate
            // 
            this.txtFutureDate.Location = new System.Drawing.Point(155, 18);
            this.txtFutureDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFutureDate.Name = "txtFutureDate";
            this.txtFutureDate.Size = new System.Drawing.Size(106, 23);
            this.txtFutureDate.TabIndex = 1;
            this.txtFutureDate.Text = "12/31/2026";
            // 
            // btnCalculateDays
            // 
            this.btnCalculateDays.Location = new System.Drawing.Point(283, 17);
            this.btnCalculateDays.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCalculateDays.Name = "btnCalculateDays";
            this.btnCalculateDays.Size = new System.Drawing.Size(148, 23);
            this.btnCalculateDays.TabIndex = 2;
            this.btnCalculateDays.Text = "Calculate &Due Days ";
            this.btnCalculateDays.UseVisualStyleBackColor = true;
            this.btnCalculateDays.Click += new System.EventHandler(this.btnCalculateDays_Click);
            // 
            // btnCalculateAge
            // 
            this.btnCalculateAge.Location = new System.Drawing.Point(283, 50);
            this.btnCalculateAge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCalculateAge.Name = "btnCalculateAge";
            this.btnCalculateAge.Size = new System.Drawing.Size(148, 23);
            this.btnCalculateAge.TabIndex = 5;
            this.btnCalculateAge.Text = "Calculate &Age";
            this.btnCalculateAge.UseVisualStyleBackColor = true;
            this.btnCalculateAge.Click += new System.EventHandler(this.btnCalculateAge_Click);
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Location = new System.Drawing.Point(155, 51);
            this.txtBirthDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.Size = new System.Drawing.Size(106, 23);
            this.txtBirthDate.TabIndex = 4;
            this.txtBirthDate.Text = "10/24/1952";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter a birth date:";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(283, 83);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(148, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(469, 122);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCalculateAge);
            this.Controls.Add(this.txtBirthDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalculateDays);
            this.Controls.Add(this.txtFutureDate);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Date Handling";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Label label1;
    private TextBox txtFutureDate;
    private Button btnCalculateDays;
    private Button btnCalculateAge;
    private TextBox txtBirthDate;
    private Label label2;
    private Button btnExit;
}
