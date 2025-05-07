namespace InvoiceTotal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const decimal SalesTaxPct = 7.75m;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                decimal productTotal = Convert.ToDecimal(txtProductTotal.Text);
                decimal discountPercent = productTotal switch
                {
                    >= 100 and < 250 => .1m,
                    >= 250 => .25m,
                    _ => .0m,
                };

                decimal discountAmount = productTotal * discountPercent;
                decimal subtotal = productTotal - discountAmount;
                decimal tax = subtotal * SalesTaxPct / 100;
                decimal total = subtotal + tax;

                txtDiscountAmount.Text = discountAmount.ToString("c");
                txtSubtotal.Text = subtotal.ToString("c");
                txtTax.Text = tax.ToString("c");
                txtTotal.Text = total.ToString("c");

                txtProductTotal.Focus();
            }
        }

        public bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += IsPresent(txtProductTotal.Text, "Subtotal");
            errorMessage += IsDecimal(txtProductTotal.Text, "Subtotal");
            errorMessage += IsWithinRange(txtProductTotal.Text, "Subtotal", 0, 1000000);

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        public string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg = $"{name} is a required field.\n";
            }
            return msg;
        }

        public string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg = $"{name} must be a valid decimal value.\n";
            }
            return msg;
        }

        public string IsWithinRange(string value, string name, decimal min,
        decimal max)
        {
            string msg = "";
            if (Decimal.TryParse(value, out decimal number))
            {
                if (number < min || number > max)
                {
                    msg = $"{name} must be between {min} and {max}.\n";
                }
            }
            return msg;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}