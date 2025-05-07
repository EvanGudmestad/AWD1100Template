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
    private const int ModifyIndex = 6;
    private const int DeleteIndex = 7;

    // private constants and variables for paging

    private void frmCustomerDisplay_Load(object sender, EventArgs e)
    {
        // get customer count, calculate pages, and set current page to 1

        DisplayCustomers();
    }

    private void DisplayCustomers()
    {
        // get customers and bind grid
        dgvCustomers.Columns.Clear();

        // declare and calculate skip and take variables

        dgvCustomers.DataSource = data.GetCustomers();

        // format grid

        // format the column headers
        dgvCustomers.EnableHeadersVisualStyles = false;
        dgvCustomers.ColumnHeadersDefaultCellStyle.Font =
            new Font("Arial", 9, FontStyle.Bold);
        dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
        dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        // format the odd numbered rows
        dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

        // format the columns
        dgvCustomers.Columns[0].Visible = false;  // hide customerID column
        dgvCustomers.Columns[1].Width = 150;
        dgvCustomers.Columns[2].Width = 180;
        dgvCustomers.Columns[3].Width = 110;
        dgvCustomers.Columns[4].Width = 60;
        dgvCustomers.Columns[5].Width = 90;
        dgvCustomers.Columns[5].HeaderText = "Zip Code";

        // add column for modify button
        DataGridViewButtonColumn modifyColumn = new()
        {
            UseColumnTextForButtonValue = true,
            HeaderText = "",
            Text = "Modify"
        };
        dgvCustomers.Columns.Insert(ModifyIndex, modifyColumn);

        // add column for delete button
        DataGridViewButtonColumn deleteColumn = new()
        {
            UseColumnTextForButtonValue = true,
            HeaderText = "",
            Text = "Delete"
        };
        dgvCustomers.Columns.Insert(DeleteIndex, deleteColumn);

        EnableDisableButtons();
    }

    private void EnableDisableButtons()
    {
        // add code that enables or disables the paging buttons
    }

    private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex > -1)
        {
            if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
            {
                int customerID = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells[0].Value);
                selectedCustomer = data.FindCustomer(customerID)!;
            }

            if (selectedCustomer != null)
            {
                if (e.ColumnIndex == ModifyIndex)
                {
                    ModifyCustomer();
                }
                else if (e.ColumnIndex == DeleteIndex)
                {
                    DeleteCustomer();
                }
            }
        }
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
