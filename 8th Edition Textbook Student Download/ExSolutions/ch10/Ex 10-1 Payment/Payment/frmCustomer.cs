namespace Payment;

public partial class frmCustomer : Form
{
    public frmCustomer()
    {
        InitializeComponent();
    }

    bool isDataSaved = true;

    private void frmCustomer_Load(object sender, EventArgs e)
    {
        cboNames.Items.Add("Mike Smith");
        cboNames.Items.Add("Nancy Jones");
    }

    private void lblPayment_TextChanged(object sender, EventArgs e)
    {
        isDataSaved = false;
    }

    private void cboNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        isDataSaved = false;
        lblPayment.Text = "";
    }

    private void btnSelectPayment_Click(object sender, EventArgs e)
    {
        Form paymentForm = new frmPayment();
        DialogResult selectedButton = paymentForm.ShowDialog();

        if (selectedButton == DialogResult.OK)
        {
            lblPayment.Text = paymentForm.Tag?.ToString();
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (IsValidData())
        {
            SaveData();
        }
    }

    private void SaveData()
    {
        cboNames.SelectedIndex = -1;
        lblPayment.Text = "";
        isDataSaved = true;
        cboNames.Focus();
    }

    private bool IsValidData()
    {
        bool success = true;
        string errorMessage = "";

        if (cboNames.SelectedIndex == -1) 
        {
            errorMessage += "You must select a customer.\n";
        }
        if (lblPayment.Text == "") 
        {
            errorMessage += "You must enter a payment.\n";
        }

        if (errorMessage != "") 
        {
            success = false;
            MessageBox.Show(errorMessage, "Entry Error");
        }
        return success;
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (isDataSaved == false)
        {
            string message =
                "This form contains unsaved data.\n\n" +
                "Do you want to save it?";

            DialogResult button =
                MessageBox.Show(message, "Customer",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (button == DialogResult.Yes)
            {
                if (IsValidData())
                    SaveData();
                else
                    e.Cancel = true;
            }
            if (button == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
