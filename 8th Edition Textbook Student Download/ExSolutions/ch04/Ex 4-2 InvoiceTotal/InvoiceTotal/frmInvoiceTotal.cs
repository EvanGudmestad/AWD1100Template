namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        int numberOfInvoices = 0;
        decimal totalOfInvoices = 0m;
        decimal avgOfInvoices = 0m;
        decimal largestInvoice = 0m;
        decimal smallestInvoice = Decimal.MaxValue;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal subtotal = Decimal.Parse(txtEnterSubtotal.Text);
            decimal discountPct = .25m;
            decimal discountAmt = Math.Round(subtotal * discountPct, 2);
            decimal invoiceTotal = Math.Round(subtotal - discountAmt, 2);

            txtSubtotal.Text = subtotal.ToString("c");
            txtDiscountPct.Text = discountPct.ToString("p1");
            txtDiscountAmt.Text = discountAmt.ToString("c");
            txtTotal.Text = invoiceTotal.ToString("c");

            numberOfInvoices++;
            totalOfInvoices += invoiceTotal;
            avgOfInvoices = totalOfInvoices / numberOfInvoices;
            largestInvoice = Math.Max(largestInvoice, invoiceTotal);
            smallestInvoice = Math.Min(smallestInvoice, invoiceTotal);

            txtNumberOfInvoices.Text = numberOfInvoices.ToString();
            txtTotalOfInvoices.Text = totalOfInvoices.ToString("c");
            txtAvgOfInvoices.Text = avgOfInvoices.ToString("c");
            txtLargestInvoice.Text = largestInvoice.ToString("c");
            txtSmallestInvoice.Text = smallestInvoice.ToString("c");

            txtEnterSubtotal.Text = "";
            txtEnterSubtotal.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            numberOfInvoices = 0;
            totalOfInvoices = 0m;
            avgOfInvoices = 0m;
            largestInvoice = 0m;
            smallestInvoice = Decimal.MaxValue;

            txtNumberOfInvoices.Text = "";
            txtTotalOfInvoices.Text = "";
            txtAvgOfInvoices.Text = "";
            txtLargestInvoice.Text = "";
            txtSmallestInvoice.Text = "";

            txtEnterSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}