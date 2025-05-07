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

        // private constants for the index values of the Modify and Delete button columns

        private void frmStateMaintenance_Load(object sender, EventArgs e)
        {
            DisplayStates();
        }

        private void DisplayStates()
        {
            // get states and bind grid

            // format grid

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