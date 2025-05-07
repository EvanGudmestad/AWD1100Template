namespace ProductMaintenance;

public partial class frmProductMaintenance : Form
{
    public frmProductMaintenance()
    {
        InitializeComponent();
    }

    // add class variables for the DB context and Product entity 

    private void btnGetProduct_Click(object sender, EventArgs e)
    {
        if (IsValidData())
        {
            try
            {
                string productCode = txtProductCode.Text;

                // get product from database by product code and display; 
                // notify user and clear controls if no product is returned 

            }
            catch (Exception ex)
            {
                this.HandleDataAccessError(ex);
            }
        }
    }

    private bool IsValidData()
    {
        bool success = true;
        string errorMessage = "";

        errorMessage = Validator.IsPresent(txtProductCode.Text, "Product Code");
        if (!string.IsNullOrEmpty(errorMessage))
        {
            success = false;
            MessageBox.Show(errorMessage, "Entry Error");
            txtProductCode.Focus();
        }
        return success;
    }

    private void DisplayProduct()
    {
        // display the product information

        txtProductCode.Focus();
    }

    private void ClearControls()
    {
        txtProductCode.Text = "";
        txtDescription.Text = "";
        txtUnitPrice.Text = "";
        txtOnHand.Text = "";
        txtProductCode.Focus();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        frmAddModify addModifyForm = new()
        {
            IsAdd = true
        };
        DialogResult result = addModifyForm.ShowDialog();  

        if (result == DialogResult.OK)
        {
            try
            {
                // get new product, add to database, display product
            }
            catch (Exception ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void btnModify_Click(object sender, EventArgs e)
    {
        frmAddModify addModifyForm = new()
        {
            IsAdd = false
            // assign class variable to Product property
        };

        DialogResult result = addModifyForm.ShowDialog();

        if (result == DialogResult.OK)
        {
            try
            {
                // get modified product, update database, display product
            }
            catch (Exception ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var desc = ""; // get description from class variable
        DialogResult result =
            MessageBox.Show($"Delete {desc}?", "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                // delete product from database, clear controls

            }
            catch (Exception ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void HandleDataAccessError(Exception ex)
    {
        // if concurrency error, clear controls if deleted, otherwise display current data

        // display error message in dialog with error type as title
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
