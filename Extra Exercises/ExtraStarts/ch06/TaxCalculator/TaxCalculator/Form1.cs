namespace TaxCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal income = Convert.ToDecimal(txtIncome.Text);

            decimal tax = 0m;

            if (income <= 11000)
                tax = (int)(income * .10m);
            else if (income > 11000 && income <= 44725)
                tax = 1100m + (int)((income - 11000) * .12m);
            else if (income > 44725 && income <= 95375)
                tax = 5147m + (int)((income - 44725) * .22m);
            else if (income > 95375 && income <= 182100)
                tax = 16290m + (int)((income - 95375) * .24m);
            else if (income > 182100 && income <= 231250)
                tax = 37104m + (int)((income - 182100) * .32m);
            else if (income > 231250 && income <= 578125)
                tax = 52832m + (int)((income - 231250) * .35m);
            else if (income > 578125)
                tax = 174238.25m + (int)((income - 578125) * .37m);

            txtTax.Text = tax.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}