using CustomerInvoiceDisplay.Models.DataLayer;

namespace CustomerInvoiceDisplay;

public partial class frmCustomerDisplay : Form
{
    public frmCustomerDisplay()
    {
        InitializeComponent();
    }

    private MMABooksDataAccess data = new();
    private const int MaxRows = 10;
    private int totalRows = 0;
    private int pages = 0;

    private void frmCustomerDisplay_Load(object sender, EventArgs e)
    {
        totalRows = data.CustomerCount;
        pages = totalRows / MaxRows;
        if (totalRows % MaxRows != 0)
        {
            pages += 1;
        }
        lblPages.Text = pages.ToString();

        DisplayCustomers(1);
    }

    private void DisplayCustomers(int pageNumber)
    {
        txtPage.Text = pageNumber.ToString();

        int skip = MaxRows * (pageNumber - 1);

        int take = MaxRows;
        if (pageNumber == pages)
        {
            take = totalRows - skip;
        }
        if (totalRows <= MaxRows)
        {
            take = totalRows;
        }

        dgvCustomers.DataSource = data.GetCustomers(skip, take);

        // select the first row of the page and display its invoices
        dgvCustomers.Rows[0].Selected = true;
        DisplayInvoices(0);

        // format the column headers
        dgvCustomers.EnableHeadersVisualStyles = false;
        dgvCustomers.ColumnHeadersDefaultCellStyle.Font =
            new Font("Arial", 9, FontStyle.Bold);
        dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
        dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        // format the odd numbered rows
        dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

        // format the columns
        dgvCustomers.Columns[0].Visible = false;  // hide id column
        dgvCustomers.Columns[1].Width = 150;
        dgvCustomers.Columns[2].Width = 180;
        dgvCustomers.Columns[3].Width = 110;
        dgvCustomers.Columns[4].Width = 60;
        dgvCustomers.Columns[5].HeaderText = "Zip Code";
        dgvCustomers.Columns[5].Width = 90;

        EnableDisableButtons(pageNumber);
    }

    private void EnableDisableButtons(int pageNumber)
    {
        // enable/disable buttons
        if (pageNumber == 1)
        {
            btnFirst.Enabled = false;
            btnPrev.Enabled = false;
        }
        else
        {
            btnFirst.Enabled = true;
            btnPrev.Enabled = true;
        }

        // enable/disable Next/Last buttons
        if (pageNumber == pages)
        {
            btnNext.Enabled = false;
            btnLast.Enabled = false;
        }
        else
        {
            btnNext.Enabled = true;
            btnLast.Enabled = true;
        }

        // if there's only one page, disable the Go To button 
        if (totalRows <= MaxRows)
        {
            btnGoTo.Enabled = false;
        }
    }

    private void btnFirst_Click(object sender, EventArgs e)
    {
        DisplayCustomers(1);
    }

    private void btnPrev_Click(object sender, EventArgs e)
    {
        int pageNumber = Convert.ToInt32(txtPage.Text);
        pageNumber -= 1;
        DisplayCustomers(pageNumber);
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        int pageNumber = Convert.ToInt32(txtPage.Text);
        pageNumber += 1;
        DisplayCustomers(pageNumber);
    }

    private void btnLast_Click(object sender, EventArgs e)
    {
        DisplayCustomers(pages);
    }

    private void btnGoTo_Click(object sender, EventArgs e)
    {
        if (IsValidData())
        {
            int pageNumber = Convert.ToInt32(txtPage.Text);
            DisplayCustomers(pageNumber);
        }
    }

    private bool IsValidData()
    {
        bool success = true;
        string errorMessage = "";
        string name = "Page Number";
        errorMessage += Validator.IsPresent(txtPage.Text, name);
        errorMessage += Validator.IsInt32(txtPage.Text, name);
        errorMessage += Validator.IsWithinRange(txtPage.Text, name, 1, pages);
        if (errorMessage != "")
        {
            success = false;
            MessageBox.Show(errorMessage, "Entry Error");
            txtPage.Focus();
        }
        return success;
    }

    private void dgvCustomers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        DisplayInvoices(e.RowIndex);
    }

    private void DisplayInvoices(int rowIndex)
    {
        DataGridViewRow row = dgvCustomers.Rows[rowIndex];
        int customerID = Convert.ToInt32(row.Cells[0].Value);

        dgvInvoices.DataSource = data.GetCustomerInvoices(customerID);

        // format the column headers
        dgvInvoices.EnableHeadersVisualStyles = false;
        dgvInvoices.ColumnHeadersDefaultCellStyle.Font =
            new Font("Arial", 9, FontStyle.Bold);
        dgvInvoices.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
        dgvInvoices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        // format the odd numbered rows
        dgvInvoices.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

        // format the columns
        dgvInvoices.Columns[0].HeaderText = "Invoice ID";
        dgvInvoices.Columns[0].Width = 85;
        dgvInvoices.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

        dgvInvoices.Columns[1].HeaderText = "Invoice Date";
        dgvInvoices.Columns[1].Width = 95;
        dgvInvoices.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

        dgvInvoices.Columns[2].HeaderText = "Product Total";
        dgvInvoices.Columns[2].Width = 105;
        dgvInvoices.Columns[2].DefaultCellStyle.Format = "c";
        dgvInvoices.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvInvoices.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvInvoices.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvInvoices.Columns[3].HeaderText = "Sales Tax";
        dgvInvoices.Columns[3].Width = 80;
        dgvInvoices.Columns[3].DefaultCellStyle.Format = "c";
        dgvInvoices.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvInvoices.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvInvoices.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvInvoices.Columns[4].HeaderText = "Shipping";
        dgvInvoices.Columns[4].Width = 80;
        dgvInvoices.Columns[4].DefaultCellStyle.Format = "c";
        dgvInvoices.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvInvoices.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvInvoices.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvInvoices.Columns[5].HeaderText = "Invoice Total";
        dgvInvoices.Columns[5].Width = 100;
        dgvInvoices.Columns[5].DefaultCellStyle.Format = "c";
        dgvInvoices.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvInvoices.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvInvoices.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
