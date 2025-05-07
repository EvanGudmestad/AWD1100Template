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

        private void rbBook_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBook.Checked)
                lblAuthorOrVersion.Text = "Author: ";
            else
                lblAuthorOrVersion.Text = "Version: ";

            txtCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (rbBook.Checked)
                    product = new Book(txtCode.Text, txtDescription.Text, 
                        Convert.ToDecimal(txtPrice.Text), txtAuthorOrVersion.Text);
                else
                    product = new Software(txtCode.Text, txtDescription.Text, 
                        Convert.ToDecimal(txtPrice.Text), txtAuthorOrVersion.Text);

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
            if (rbBook.Checked)
                errorMessage += Validator.IsPresent(txtAuthorOrVersion.Text, nameof(Book.Author));
            else
                errorMessage += Validator.IsPresent(txtAuthorOrVersion.Text, nameof(Software.Version));

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
