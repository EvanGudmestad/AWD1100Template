using InvoiceLineItemDisplay.Models.DataLayer;

namespace InvoiceLineItemDisplay;

public partial class frmInvoiceLineItems : Form
{
    public frmInvoiceLineItems()
    {
        InitializeComponent();
    }

    private MMABooksDataAccess data = new();

    private void frmInvoiceLineItems_Load(object sender, EventArgs e)
    {
        // display the invoices, display the line items for the first invoice
        // and select the first invoice
        DisplayInvoices();
        DisplayLineItems(0);
        dgvInvoices.Rows[0].Selected = true;
    }

    private void DisplayInvoices()
    {
        // get the invoices and bind the invoices grid
        dgvInvoices.DataSource = data.GetInvoices();

        // format the column headers
        dgvInvoices.EnableHeadersVisualStyles = false;
        dgvInvoices.ColumnHeadersDefaultCellStyle.Font =
            new Font("Arial", 9, FontStyle.Bold);
        dgvInvoices.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
        dgvInvoices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        // format the odd numbered rows
        dgvInvoices.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

        // format the columns
        dgvInvoices.Columns[0].Visible = false;

        dgvInvoices.Columns[1].HeaderText = "Invoice Date";
        dgvInvoices.Columns[1].Width = 105;
        dgvInvoices.Columns[1].DefaultCellStyle.Format = "d";

        dgvInvoices.Columns[2].HeaderText = "Product Total";
        dgvInvoices.Columns[2].Width = 115;
        dgvInvoices.Columns[2].DefaultCellStyle.Format = "c";
        dgvInvoices.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvInvoices.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvInvoices.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvInvoices.Columns[3].HeaderText = "Sales Tax";
        dgvInvoices.Columns[3].Width = 90;
        dgvInvoices.Columns[3].DefaultCellStyle.Format = "c";
        dgvInvoices.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvInvoices.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvInvoices.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvInvoices.Columns[4].Width = 90;
        dgvInvoices.Columns[4].DefaultCellStyle.Format = "c";
        dgvInvoices.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvInvoices.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvInvoices.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvInvoices.Columns[5].HeaderText = "Invoice Total";
        dgvInvoices.Columns[5].Width = 115;
        dgvInvoices.Columns[5].DefaultCellStyle.Format = "c";
        dgvInvoices.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvInvoices.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvInvoices.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void dgvInvoices_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        // display the line items for the invoice that was clicked
        DisplayLineItems(e.RowIndex);
    }

    private void DisplayLineItems(int rowIndex)
    {
        // get the row that was clicked and the invoice ID for that row
        DataGridViewRow row = dgvInvoices.Rows[rowIndex];
        int invoiceID = Convert.ToInt32(row.Cells[0].Value);

        // get the line items for the invoice and bind the line items grid
        dgvLineItems.DataSource = data.GetInvoiceLineItems(invoiceID);

        // format the column headers
        dgvLineItems.EnableHeadersVisualStyles = false;
        dgvLineItems.ColumnHeadersDefaultCellStyle.Font =
            new Font("Arial", 9, FontStyle.Bold);
        dgvLineItems.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
        dgvLineItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        // format the odd numbered rows
        dgvLineItems.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

        // format the columns
        dgvLineItems.Columns[0].HeaderText = "Product Code";
        dgvLineItems.Columns[0].Width = 115;

        dgvLineItems.Columns[1].Width = 85;
        dgvLineItems.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvLineItems.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvLineItems.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvLineItems.Columns[2].HeaderText = "Unit Price";
        dgvLineItems.Columns[2].Width = 85;
        dgvLineItems.Columns[2].DefaultCellStyle.Format = "c";
        dgvLineItems.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvLineItems.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvLineItems.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvLineItems.Columns[3].HeaderText = "Item Total";
        dgvLineItems.Columns[3].Width = 90;
        dgvLineItems.Columns[3].DefaultCellStyle.Format = "c";
        dgvLineItems.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvLineItems.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvLineItems.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
