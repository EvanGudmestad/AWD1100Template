namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string customerType = txtCustomerType.Text;
            decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
            (decimal discountPct, decimal discountAmt, decimal invoiceTotal) = GetInvoiceAmounts(customerType, subtotal);

            txtDiscountPct.Text = discountPct.ToString("p1");
            txtDiscountAmt.Text = discountAmt.ToString("c");
            txtTotal.Text = invoiceTotal.ToString("c");

            txtCustomerType.Focus();
        }

        private static (decimal discountPct, decimal discountAmt, decimal invoiceTotal) GetInvoiceAmounts(string customerType, decimal subtotal)
        {
            decimal discountPct = 0m;
            decimal discountAmt = 0m;
            decimal invoiceTotal = 0m;

            if (customerType == "R")
            {
                if (subtotal < 100)
                    discountPct = .0m;
                else if (subtotal >= 100 && subtotal < 250)
                    discountPct = .1m;
                else if (subtotal >= 250)
                    discountPct = .25m;
            }
            else if (customerType == "C")
            {
                if (subtotal < 250)
                    discountPct = .2m;
                else
                    discountPct = .3m;
            }
            else
            {
                discountPct = .4m;
            }

            discountAmt = subtotal * discountPct;
            invoiceTotal = subtotal - discountAmt;

            return (discountPct, discountAmt, invoiceTotal);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}