using OrderOptionsMaintenance.Models;

namespace OrderOptionsMaintenance
{
    public partial class frmOptionsMaint : Form
    {
        public frmOptionsMaint()
        {
            InitializeComponent();
        }

        MMABooksDataAccess data = new();
        OrderOption options = null!;

        private void frmOptionsMaint_Load(object sender, EventArgs e)
        {
            options = data.GetOrderOptions();

            txtSalesTax.Text = options.SalesTaxRate.ToString();
            txtShipFirstBook.Text = options.FirstBookShipCharge.ToString("n2");
            txtShipAddlBook.Text = options.AdditionalBookShipCharge.ToString("n2");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                try
                {
                    options.SalesTaxRate = Convert.ToDecimal(txtSalesTax.Text);
                    options.FirstBookShipCharge = Convert.ToDecimal(txtShipFirstBook.Text);
                    options.AdditionalBookShipCharge = Convert.ToDecimal(txtShipAddlBook.Text);

                    data.SaveOrderOptions(options);

                    MessageBox.Show("Options saved.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (DataAccessException ex)
                {
                    MessageBox.Show(ex.Message, ex.ErrorType);
                }
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