namespace StringHandling;

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
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.btnParseName = new System.Windows.Forms.Button();
            this.btnEditPhoneNumber = new System.Windows.Forms.Button();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
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
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter full name:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(155, 18);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(106, 23);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.Text = "joel ray murach";
            // 
            // btnParseName
            // 
            this.btnParseName.Location = new System.Drawing.Point(283, 17);
            this.btnParseName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnParseName.Name = "btnParseName";
            this.btnParseName.Size = new System.Drawing.Size(148, 23);
            this.btnParseName.TabIndex = 2;
            this.btnParseName.Text = "Parse Name";
            this.btnParseName.UseVisualStyleBackColor = true;
            this.btnParseName.Click += new System.EventHandler(this.btnParseName_Click);
            // 
            // btnEditPhoneNumber
            // 
            this.btnEditPhoneNumber.Location = new System.Drawing.Point(283, 50);
            this.btnEditPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditPhoneNumber.Name = "btnEditPhoneNumber";
            this.btnEditPhoneNumber.Size = new System.Drawing.Size(148, 23);
            this.btnEditPhoneNumber.TabIndex = 5;
            this.btnEditPhoneNumber.Text = "Edit phone number";
            this.btnEditPhoneNumber.UseVisualStyleBackColor = true;
            this.btnEditPhoneNumber.Click += new System.EventHandler(this.btnEditPhoneNumber_Click);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(155, 51);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(106, 23);
            this.txtPhoneNumber.TabIndex = 4;
            this.txtPhoneNumber.Text = "(559) 440-9071";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter phone number:";
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
            this.Controls.Add(this.btnEditPhoneNumber);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnParseName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "String Handling";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Label label1;
    private TextBox txtFullName;
    private Button btnParseName;
    private Button btnEditPhoneNumber;
    private TextBox txtPhoneNumber;
    private Label label2;
    private Button btnExit;
}
