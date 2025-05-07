namespace ProductMaintenance;

public partial class frmAddModify : Form
{
    public frmAddModify()
    {
        InitializeComponent();
    }

    // add public property for a Product entity 

    public bool IsAdd { get; set; }

    private void frmAddModify_Load(object sender, EventArgs e)
    {
        if (IsAdd)
        {
            Text = "Add Product";
            txtProductCode.ReadOnly = false;  // allow entry of new product code

            // initialize form level Product property
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
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
