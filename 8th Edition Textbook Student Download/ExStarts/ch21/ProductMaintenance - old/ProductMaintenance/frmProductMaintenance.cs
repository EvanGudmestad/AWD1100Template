using ProductMaintenance.Models.DataLayer;

namespace ProductMaintenance;

public partial class frmProductMaintenance : Form
{
    public frmProductMaintenance()
    {
        InitializeComponent();
    }

    MMABooksDataAccess data = new();
    Product selectedProduct = null!;

    private void btnGetProduct_Click(object sender, EventArgs e)
    {
        if (IsValidData())
        {
            try
            {
                string productCode = txtProductCode.Text;

                // get product from database by product code and display; 
                // notify user and clear controls if no product is returned 
                selectedProduct = data.FindProduct(productCode)!;
                if (selectedProduct == null)
                {
                    MessageBox.Show("No product found with this code. " +
                            "Please try again.", "Product Not Found");
                    ClearControls();
                }
                else
                {
                    DisplayProduct();
                }
            }
            catch (DataAccessException ex)
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
        txtProductCode.Text = selectedProduct.ProductCode;
        txtDescription.Text = selectedProduct.Description;
        txtUnitPrice.Text = selectedProduct.UnitPrice.ToString("c");
        txtOnHand.Text = selectedProduct.OnHandQuantity.ToString();

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
                selectedProduct = addModifyForm.Product;
                data.AddProduct(selectedProduct);
                DisplayProduct();
            }
            catch (DataAccessException ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void btnModify_Click(object sender, EventArgs e)
    {
        frmAddModify addModifyForm = new()
        {
            IsAdd = false,
            Product = selectedProduct, // assign class variable to Product property
        };
        DialogResult result = addModifyForm.ShowDialog();

        if (result == DialogResult.OK)
        {
            try
            {
                // get modified product, update database, display product
                selectedProduct = addModifyForm.Product;
                data.UpdateProduct(selectedProduct);
                DisplayProduct();
            }
            catch (DataAccessException ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var desc = selectedProduct.Description; // get description from class variable
        DialogResult result =
            MessageBox.Show($"Delete {desc}?", "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                // delete product from database, clear controls
                data.RemoveProduct(selectedProduct);
                ClearControls();
            }
            catch (DataAccessException ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void HandleDataAccessError(DataAccessException ex)
    {
        // if concurrency, clear controls if deleted, otherwise display current data
        if (ex.IsConcurrencyError)
        {
            if (ex.IsDeleted)
                ClearControls();
            else
                DisplayProduct();
        }

        // display error message in dialog with error type as title
        MessageBox.Show(ex.Message, ex.ErrorType);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }
}
