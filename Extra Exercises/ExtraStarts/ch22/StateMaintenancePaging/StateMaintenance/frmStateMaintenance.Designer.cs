namespace StateMaintenance
{
    partial class frmStateMaintenance
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
            btnAdd = new Button();
            btnExit = new Button();
            dgvStates = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvStates).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 310);
            btnAdd.Margin = new Padding(2, 2, 2, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(407, 310);
            btnExit.Margin = new Padding(2, 2, 2, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 2;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // dgvStates
            // 
            dgvStates.AllowUserToAddRows = false;
            dgvStates.AllowUserToDeleteRows = false;
            dgvStates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStates.Location = new Point(20, 19);
            dgvStates.Margin = new Padding(2, 2, 2, 2);
            dgvStates.Name = "dgvStates";
            dgvStates.ReadOnly = true;
            dgvStates.RowHeadersWidth = 62;
            dgvStates.RowTemplate.Height = 25;
            dgvStates.Size = new Size(462, 272);
            dgvStates.TabIndex = 0;
            dgvStates.CellContentClick += dgvStates_CellContentClick;
            // 
            // frmStateMaintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(504, 350);
            Controls.Add(dgvStates);
            Controls.Add(btnExit);
            Controls.Add(btnAdd);
            Margin = new Padding(2, 2, 2, 2);
            Name = "frmStateMaintenance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "State Maintenance";
            Load += frmStateMaintenance_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStates).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private Button btnExit;
        private DataGridView dgvStates;
    }
}