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

            //if (customerType == "R" || customerType == "r")
            //{
            //    if (subtotal < 100)
            //        discountPct = .0m;
            //    else if (subtotal >= 100 && subtotal < 250)
            //        discountPct = .1m;
            //    else if (subtotal >= 250 && subtotal < 500)
            //        discountPct = .25m;
            //    else if (subtotal >= 500)
            //        discountPct = .3m;
            //}
            //else if (customerType == "C" || customerType == "c")
            //{
            //    discountPct = .2m;
            //}
            //else if (customerType == "T" || customerType == "t")
            //{
            //    if (subtotal < 500)
            //        discountPct = .4m;
            //    else
            //        discountPct = .5m;
            //}
            //else
            //{
            //    discountPct = .1m;
            //}

            //switch (customerType)
            //{
            //    case "R":
            //        if (subtotal < 100)
            //            discountPct = .0m;
            //        else if (subtotal >= 100 && subtotal < 250)
            //            discountPct = .1m;
            //        else if (subtotal >= 250 && subtotal < 500)
            //            discountPct = .25m;
            //        else if (subtotal >= 500)
            //            discountPct = .3m;
            //        break;
            //    case "C":
            //        discountPct = .2m;
            //        break;
            //    case "T":
            //        if (subtotal < 500)
            //            discountPct = .4m;
            //        else
            //            discountPct = .5m;
            //        break;
            //    default:
            //        discountPct = .1m;
            //        break;
            //}

            discountPct = customerType switch
            {
                "R" => .3m,
                "C" => .2m,
                "T" => .5m,
                _ => .1m
            };

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