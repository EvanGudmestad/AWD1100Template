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

    // private constants for the index values of the Modify and Delete button columns

    private void frmCustomerDisplay_Load(object sender, EventArgs e)
    {
        DisplayCustomers();
    }

    private void DisplayCustomers()
    {
        // get customers and bind grid
        

        // format grid
        
    }

    private void ModifyCustomer()
    {
        frmAddModifyCustomer addModifyCustomerForm = new()
        {
            Customer = selectedCustomer,
            States = data.GetStates()
        };

        DialogResult result = addModifyCustomerForm.ShowDialog();
        if (result == DialogResult.OK)
        {
            try
            {
                selectedCustomer = addModifyCustomerForm.Customer;
                data.UpdateCustomer(selectedCustomer);
                DisplayCustomers();
            }
            catch (DataAccessException ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void DeleteCustomer()
    {
        DialogResult result =
            MessageBox.Show($"Delete {selectedCustomer.Name}?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                data.RemoveCustomer(selectedCustomer);
                DisplayCustomers();
            }
            catch (DataAccessException ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        frmAddModifyCustomer addModifyCustomerForm = new()
        {
            States = data.GetStates()
        };
        DialogResult result = addModifyCustomerForm.ShowDialog();
        if (result == DialogResult.OK)
        {
            try
            {
                selectedCustomer = addModifyCustomerForm.Customer;
                data.AddCustomer(selectedCustomer);
                DisplayCustomers();
            }
            catch (DataAccessException ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void HandleDataAccessError(DataAccessException ex)
    {
        // if concurrency conflict, re-display products
        if (ex.IsConcurrencyError)
        {
            DisplayCustomers();
        }

        // display error message in dialog with error type as title
        MessageBox.Show(ex.Message, ex.ErrorType);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    
}
