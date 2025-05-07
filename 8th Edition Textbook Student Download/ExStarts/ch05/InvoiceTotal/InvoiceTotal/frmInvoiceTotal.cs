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
            decimal discountPct = 0m;

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

            decimal discountAmt = subtotal * discountPct;
            decimal invoiceTotal = subtotal - discountAmt;

            txtDiscountPct.Text = discountPct.ToString("p1");
            txtDiscountAmt.Text = discountAmt.ToString("c");
            txtTotal.Text = invoiceTotal.ToString("c");

            txtCustomerType.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}