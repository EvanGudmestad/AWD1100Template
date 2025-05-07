namespace ProductMaintenance
{
    public partial class frmNewProduct : Form
    {
        public frmNewProduct()
        {
            InitializeComponent();
        }

        private Product product = null!;

        public Product GetNewProduct()
        {
            this.ShowDialog();
            return product;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                product = new()
                {
                    Code = txtCode.Text,
                    Description = txtDescription.Text,
                    Price = Convert.ToDecimal(txtPrice.Text)
                };
                this.Close();
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtCode.Text, nameof(Product.Code));
            errorMessage += Validator.IsPresent(txtDescription.Text, nameof(Product.Description));
            errorMessage += Validator.IsDecimal(txtPrice.Text, nameof(Product.Price));

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
