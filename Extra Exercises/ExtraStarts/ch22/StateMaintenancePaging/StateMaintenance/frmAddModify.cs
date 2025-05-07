using StateMaintenance.Models.DataLayer;

namespace StateMaintenance
{
    public partial class frmAddModify : Form
    {
        public frmAddModify()
        {
            InitializeComponent();
        }

        public State State { get; set; } = null!;

        private void frmAddModify_Load(object sender, EventArgs e)
        {
            if (State == null)
            {
                Text = "Add State";
                txtStateCode.Enabled = true;
                State = new();
            }
            else
            {
                Text = "Modify State";
                txtStateCode.Enabled = false;   // don't modify existing primary key
                txtStateCode.Text = State.StateCode;
                txtStateName.Text = State.StateName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                State.StateCode = txtStateCode.Text;
                State.StateName = txtStateName.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtStateCode.Text, "State code");
            errorMessage += Validator.IsPresent(txtStateName.Text, "State name");

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
