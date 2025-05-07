using StateMaintenance.Models.DataLayer;

namespace StateMaintenance
{
    public partial class frmStateMaintenance : Form
    {
        public frmStateMaintenance()
        {
            InitializeComponent();
        }

        MMABooksDataAccess data = new();
        State selectedState = null!;

        private const int ModifyIndex = 2;
        private const int DeleteIndex = 3;

        private void frmStateMaintenance_Load(object sender, EventArgs e)
        {
            DisplayStates();
        }

        private void DisplayStates()
        {
            dgvStates.Columns.Clear();

            dgvStates.DataSource = data.GetStates();

            // add column for modify button
            DataGridViewButtonColumn modifyColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dgvStates.Columns.Insert(ModifyIndex, modifyColumn);

            // add column for delete button
            DataGridViewButtonColumn deleteColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvStates.Columns.Insert(DeleteIndex, deleteColumn);

            // format the column headers
            dgvStates.EnableHeadersVisualStyles = false;
            dgvStates.ColumnHeadersDefaultCellStyle.Font =
                new Font("Arial", 9, FontStyle.Bold);
            dgvStates.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dgvStates.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            dgvStates.AlternatingRowsDefaultCellStyle.BackColor =
                Color.PaleGoldenrod;

            // format the first column
            dgvStates.Columns[0].HeaderText = "Code";
            dgvStates.Columns[0].Width = 60;

            // format the second column
            dgvStates.Columns[1].HeaderText = "State Name";
            dgvStates.Columns[1].Width = 120;
        }

        private void dgvStates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
            {
                string code = dgvStates.Rows[e.RowIndex].Cells[0].Value.ToString()?.Trim()!;
                selectedState = data.GetState(code);
            }
            if (e.ColumnIndex == ModifyIndex)
                ModifyState();
            else if (e.ColumnIndex == DeleteIndex)
                DeleteState();
        }

        private void ModifyState()
        {
            frmAddModify modifyForm = new()
            {
                State = selectedState
            };
            DialogResult result = modifyForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    selectedState = modifyForm.State;
                    data.UpdateState(selectedState);
                    DisplayStates();
                }
                catch (DataAccessException ex)
                {
                    MessageBox.Show(ex.Message, ex.ErrorType);
                }
            }
        }

        private void DeleteState()
        {
            DialogResult result =
                MessageBox.Show($"Delete {selectedState.StateName.Trim()}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    data.RemoveState(selectedState);
                    DisplayStates();
                }
                catch (DataAccessException ex)
                {
                    MessageBox.Show(ex.Message, ex.ErrorType);
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModify addForm = new();
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedState = addForm.State;
                    data.AddState(selectedState);
                    DisplayStates();
                }
                catch (DataAccessException ex)
                {
                    MessageBox.Show(ex.Message, ex.ErrorType);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}