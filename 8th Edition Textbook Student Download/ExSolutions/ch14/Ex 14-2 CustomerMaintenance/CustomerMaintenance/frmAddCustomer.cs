namespace CustomerMaintenance
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private Customer customer = null!;

        public Customer GetNewCustomer()
        {
            this.ShowDialog();
            return customer;
        }

        private void rdoWholesale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWholesale.Checked)
            {
                lblCompanyOrPhone.Text = "Company: ";
            }
            else
            {
                lblCompanyOrPhone.Text = "Home Phone: ";
            }
            txtFirstName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (rbWholesale.Checked)
                {
                    customer = new WholesaleCustomer(txtFirstName.Text, 
                        txtLastName.Text, txtEmail.Text, txtCompanyOrPhone.Text);
                }
                else
                {
                    customer = new RetailCustomer(txtFirstName.Text,
                        txtLastName.Text, txtEmail.Text, txtCompanyOrPhone.Text);
                }
                
                this.Close();
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtFirstName.Text, "First Name");
            errorMessage += Validator.IsPresent(txtLastName.Text, "Last Name");
            errorMessage += Validator.IsValidEmail(txtEmail.Text, "Email");
            if (rbWholesale.Checked )
            {
                errorMessage += Validator.IsPresent(txtCompanyOrPhone.Text, "Company");
            }
            else
            {
                errorMessage += Validator.IsPresent(txtCompanyOrPhone.Text, "Home Phone");
            }

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
