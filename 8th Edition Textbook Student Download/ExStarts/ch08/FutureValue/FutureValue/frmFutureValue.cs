namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        // TODO: Declare the rectangular array and the row index here

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                    decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                    int years = Convert.ToInt32(txtYears.Text);

                    int months = years * 12;
                    decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

                    decimal futureValue = CalculateFutureValue(monthlyInvestment, months, monthlyInterestRate);

                    txtFutureValue.Text = futureValue.ToString("c");
                    txtMonthlyInvestment.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                                ex.GetType().ToString() + "\n" +
                                ex.StackTrace, "Exception");
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            // Validate the Monthly Investment text box
            errorMessage += IsDecimal(txtMonthlyInvestment.Text,
                                      "Monthly Investment");
            errorMessage += IsWithinRange(txtMonthlyInvestment.Text,
                                          "Monthly Investment",
                                          1, 1000);

            // Validate the Yearly Interest Rate text box
            errorMessage += IsDecimal(txtInterestRate.Text,
                                      "Yearly Interest Rate");
            errorMessage += IsWithinRange(txtInterestRate.Text,
                                          "Yearly Interest Rate", 1, 20);

            // Validate the Number of Years text box
            errorMessage += IsInt32(txtYears.Text, "Number of Years");
            errorMessage += IsWithinRange(txtYears.Text, "Number of Years",
                                          1, 40);

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg = name + " must be a valid decimal value.\n";
            }
            return msg;
        }

        private string IsInt32(string value, string name)
        {
            string msg = "";
            if (!Int32.TryParse(value, out _))
            {
                msg = name + " must be a valid integer value.\n";
            }
            return msg;
        }

        private string IsWithinRange(string value, string name, decimal min,
            decimal max)
        {
            string msg = "";
            if (Decimal.TryParse(value, out decimal number))
            {
                if (number < min || number > max)
                {
                    msg = name + " must be between " + min + " and " + max + ".\n";
                }
            }
            return msg;
        }

        private static decimal CalculateFutureValue(decimal monthlyInvestment, int months, decimal monthlyInterestRate)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
                //throw new Exception("An unknown exception occurred.");
            }

                return futureValue;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // TODO: Display the rectangular array in a dialog box here

            this.Close();
        }
    }
}