using CustomerMaintenance.Models.DataLayer;

namespace CustomerMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        private MMABooksDataAccess data = new();
        private Customer selectedCustomer = null!;

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                int customerID = Convert.ToInt32(txtCustomerID.Text);
                try
                {
                    selectedCustomer = data.FindCustomer(customerID)!;
                    if (selectedCustomer == null)
                    {
                        MessageBox.Show("No customer found with this ID. " +
                        "Please try again.", "Customer Not Found");
                        ClearControls();
                    }
                    else
                    {
                        DisplayCustomer();
                    }
                }
                catch (DataAccessException ex)
                {
                    HandleDataAccessException(ex);
                } 
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addModifyForm = new frmAddModifyCustomer
            {
                States = data.GetStates()
            };
            DialogResult result = addModifyForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                selectedCustomer = addModifyForm.Customer;
                try
                {
                    data.AddCustomer(selectedCustomer);
                    DisplayCustomer();
                }
                catch (DataAccessException ex)
                {
                    HandleDataAccessException(ex);
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            var addModifyForm = new frmAddModifyCustomer
            {
                Customer = selectedCustomer,
                States = data.GetStates()
            };
            DialogResult result = addModifyForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedCustomer = addModifyForm.Customer;
                try
                {
                    data.UpdateCustomer(selectedCustomer);
                    DisplayCustomer();
                }
                catch (DataAccessException ex)
                {
                    HandleDataAccessException(ex);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                $"Delete {selectedCustomer.Name}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    data.RemoveCustomer(selectedCustomer);
                    ClearControls();
                }
                catch (DataAccessException ex)
                {
                    HandleDataAccessException(ex);
                }
            }
        }
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";
            errorMessage = Validator.IsInt32(txtCustomerID.Text, "CustomerID");
            if (!String.IsNullOrEmpty(errorMessage))
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
                txtCustomerID.Focus();
            }
            return success;
        }

        private void DisplayCustomer()
        {
            txtCustomerID.Text = selectedCustomer.CustomerId.ToString();
            txtName.Text = selectedCustomer.Name;
            txtAddress.Text = selectedCustomer.Address;
            txtCity.Text = selectedCustomer.City;
            txtState.Text = selectedCustomer.StateNavigation.StateName;
            txtZipCode.Text = selectedCustomer.ZipCode;
            btnModify.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void ClearControls()
        {
            txtCustomerID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            txtCustomerID.Focus();
        }

        private void HandleDataAccessException(DataAccessException ex)
        {
            // if it's a concurrency error, clear controls or display updated data 
            if (ex.IsConcurrencyError)
            {
                if (ex.IsDeleted)
                    ClearControls();
                else
                    DisplayCustomer();
            }

            // for all errors, display error message and error type
            MessageBox.Show(ex.Message, ex.ErrorType);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}