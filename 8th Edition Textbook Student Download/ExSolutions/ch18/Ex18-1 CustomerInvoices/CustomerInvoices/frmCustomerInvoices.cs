namespace CustomerInvoices;

public partial class frmCustomerInvoices : Form
{
    public frmCustomerInvoices()
    {
        InitializeComponent();
    }

    private void frmCustomerInvoices_Load(object sender, EventArgs e)
    {
        List<Invoice> invoiceList = InvoiceDB.GetInvoices();
        List<Customer> customerList = CustomerDB.GetCustomers();

        var invoices = from invoice in invoiceList
                       join customer in customerList
                       on invoice.CustomerID equals customer.CustomerID
                       orderby customer.Name,  invoice.InvoiceTotal descending
                       select new
                       {
                           customer.Name,
                           invoice.InvoiceID,
                           invoice.InvoiceDate,
                           invoice.InvoiceTotal
                       };

        int i = 0;
        foreach (var invoice in invoices)
        {
            lvInvoices.Items.Add(invoice.Name.ToString());
            lvInvoices.Items[i].SubItems.Add(invoice.InvoiceID.ToString());
            lvInvoices.Items[i].SubItems.Add(
                Convert.ToDateTime(invoice.InvoiceDate).ToShortDateString());
            lvInvoices.Items[i].SubItems.Add(invoice.InvoiceTotal.ToString("c"));
            i += 1;
        }
    }
}