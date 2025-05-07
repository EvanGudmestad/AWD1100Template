namespace OrderOptionsMaintenance
{
    public partial class frmOptionsMaint : Form
    {
        public frmOptionsMaint()
        {
            InitializeComponent();
        }

        private void frmOptionsMaint_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {

            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtSalesTax.Text, "Sales tax rate");
            errorMessage += Validator.IsDecimal(txtSalesTax.Text, "Sales tax rate");
            errorMessage += Validator.IsPresent(txtShipFirstBook.Text, "First book shipping charge");
            errorMessage += Validator.IsDecimal(txtShipFirstBook.Text, "First book shipping charge");
            errorMessage += Validator.IsPresent(txtShipAddlBook.Text, "Add\'l book shipping charge");
            errorMessage += Validator.IsDecimal(txtShipAddlBook.Text, "Add\'l book shipping charge");

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}