using CustomerMaintenance.Models.DataLayer;

namespace CustomerMaintenance;

public partial class frmAddModifyCustomer : Form
{
    public frmAddModifyCustomer()
    {
        InitializeComponent();
    }

    public Customer Customer { get; set; } = null!;
    public List<State> States { get; set; } = null!;

    private void frmAddModifyCustomer_Load(object sender, EventArgs e)
    {
        LoadStatesComboBox();
        if (Customer == null)
        {
            Text = "Add Customer";
            cboStates.SelectedIndex = -1;
            Customer = new();
        }
        else
        {
            Text = "Modify Customer";
            DisplayCustomerData();
        }
    }

    private void LoadStatesComboBox()
    {
        cboStates.DataSource = States;
        cboStates.DisplayMember = "StateName";
        cboStates.ValueMember = "StateCode";
    }

    private void DisplayCustomerData()
    {
        txtName.Text = Customer.Name;
        txtAddress.Text = Customer.Address;
        txtCity.Text = Customer.City;
        cboStates.SelectedValue = Customer.State;
        txtZipCode.Text = Customer.ZipCode;
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        if (IsValidData())
        {
            LoadCustomerData();
            DialogResult = DialogResult.OK;
        }
    }

    private bool IsValidData()
    {
        bool success = true;
        string errorMessage = "";

        errorMessage += Validator.IsPresent(txtName.Text, "Name");
        errorMessage += Validator.IsPresent(txtAddress.Text, "Address");
        errorMessage += Validator.IsPresent(txtCity.Text, "City");
        errorMessage += Validator.IsPresent(cboStates.Text, "State");
        errorMessage += Validator.IsPresent(txtZipCode.Text, "Zip Code");

        if (errorMessage != "")
        {
            success = false;
            MessageBox.Show(errorMessage, "Entry Error");
        }
        return success;
    }

    private void LoadCustomerData()
    {
        Customer.Name = txtName.Text;
        Customer.Address = txtAddress.Text;
        Customer.City = txtCity.Text;
        Customer.State = cboStates.SelectedValue?.ToString() ?? "";
        Customer.ZipCode = txtZipCode.Text;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    
}