using ProductMaintenance.Models.DataLayer;

namespace ProductMaintenance;

public partial class frmAddModify : Form
{
    public frmAddModify()
    {
        InitializeComponent();
    }

    // add public property for a Product entity 
    public Product Product { get; set; } = null!;
    public bool IsAdd { get; set; }

    private void frmAddModify_Load(object sender, EventArgs e)
    {
        if(IsAdd)
        {
            Text = "Add Product";
            txtProductCode.ReadOnly = false;  // allow entry of new product code

            // initialize form level Product property
            Product = new();
        }
        else
        {
            Text = "Modify Product";
            txtProductCode.ReadOnly = true;   // can't change existing product code
            DisplayProduct();
        }
    }

    private void DisplayProduct()
    {
        // display the product information
        txtProductCode.Text = Product.ProductCode;
        txtDescription.Text = Product.Description;
        txtUnitPrice.Text = Product.UnitPrice.ToString();
        txtOnHand.Text = Product.OnHandQuantity.ToString();

        txtDescription.Focus();
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        if (IsValidData())
        {
            LoadProductData();
            DialogResult = DialogResult.OK;
        }
    }

    private bool IsValidData()
    {
        bool success = true;
        string errorMessage = "";

        errorMessage += Validator.IsPresent(txtProductCode.Text, "Product Code");
        errorMessage += Validator.IsPresent(txtDescription.Text, "Description");
        errorMessage += Validator.IsPresent(txtUnitPrice.Text, "Unit Price");
        errorMessage += Validator.IsDecimal(txtUnitPrice.Text, "Unit Price");
        errorMessage += Validator.IsPresent(txtOnHand.Text, "On Hand Quantity");
        errorMessage += Validator.IsInt32(txtOnHand.Text, "On Hand Quantity");

        if (!string.IsNullOrEmpty(errorMessage))
        {
            success = false;
            MessageBox.Show(errorMessage, "Entry Error");
        }
        return success;
    }

    private void LoadProductData()
    {
        // load user entries in Product property 
        Product.ProductCode = txtProductCode.Text;
        Product.Description = txtDescription.Text;
        Product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
        Product.OnHandQuantity = Convert.ToInt32(txtOnHand.Text);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}
