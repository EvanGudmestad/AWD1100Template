namespace CustomerMaintenance;

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

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (IsValidData())
        {
            customer = new Customer(txtFirstName.Text, txtLastName.Text, txtEmail.Text);
            this.Close();
        }
    }

    private bool IsValidData()
    {
        bool success = true;
        string errorMessage = "";

        errorMessage += Validator.IsPresent(txtFirstName.Text, nameof(Customer.FirstName));
        errorMessage += Validator.IsPresent(txtLastName.Text, nameof(Customer.LastName));
        errorMessage += Validator.IsValidEmail(txtEmail.Text, nameof(Customer.Email));

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