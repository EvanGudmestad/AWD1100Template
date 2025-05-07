using CustomerMaintenance.Models.DataLayer;

namespace CustomerMaintenance;

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
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        frmAddModifyCustomer addModifyForm = new() 
        {
            States = data.GetStates()
        };

        DialogResult result = addModifyForm.ShowDialog();
        if (result == DialogResult.OK)
        {
            selectedCustomer = addModifyForm.Customer;
            data.AddCustomer(selectedCustomer);
            DisplayCustomer();
        }
    }

    private void btnModify_Click(object sender, EventArgs e)
    {
        frmAddModifyCustomer addModifyForm = new() 
        {
            Customer = selectedCustomer,
            States = data.GetStates()
        };

        DialogResult result = addModifyForm.ShowDialog();
        if (result == DialogResult.OK)
        {
            selectedCustomer = addModifyForm.Customer;
            data.UpdateCustomer(selectedCustomer);
            DisplayCustomer();
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
            data.RemoveCustomer(selectedCustomer);
            ClearControls();
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

    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }

}