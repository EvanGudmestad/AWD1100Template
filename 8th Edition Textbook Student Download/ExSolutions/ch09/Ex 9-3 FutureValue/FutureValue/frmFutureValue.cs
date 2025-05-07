using System.Globalization;

namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    // TODO: use Parse() methods that check for formatting characters
                    decimal monthlyInvestment = Decimal.Parse(txtMonthlyInvestment.Text, NumberStyles.Currency);
                    decimal yearlyInterestRate = Decimal.Parse(txtInterestRate.Text, NumberStyles.Number);
                    int years = Int32.Parse(txtYears.Text, NumberStyles.None);

                    int months = years * 12;
                    decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

                    decimal futureValue = CalculateFutureValue(monthlyInvestment, months, monthlyInterestRate);

                    // TODO: format values displayed in each text box
                    decimal interestRatePercent = yearlyInterestRate / 100;
                    txtMonthlyInvestment.Text = monthlyInvestment.ToString("c");
                    txtInterestRate.Text = interestRatePercent.ToString("p");
                    txtYears.Text = years.ToString();
                    txtFutureValue.Text = futureValue.ToString("c");

                    txtMonthlyInvestment.Focus();
                }
            }
            // TODO: catch overflow exception
            catch (OverflowException)
            {
                MessageBox.Show(
                    "An overflow exception has occurred. Please enter smaller values.",
                    "Entry Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
            }
        }

        // TODO: check monthly investment amount for currency instead of decimal 
        public bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            // Validate the Monthly Investment text box
            errorMessage += IsCurrency(txtMonthlyInvestment.Text, "Monthly Investment");
            errorMessage += IsWithinRange(txtMonthlyInvestment.Text, "Monthly Investment", 1, 1000);

            // Validate the Yearly Interest Rate text box
            errorMessage += IsDecimal(txtInterestRate.Text, "Yearly Interest Rate");
            errorMessage += IsWithinRange(txtInterestRate.Text, "Yearly Interest Rate", 1, 20);

            // Validate the Number of Years text box
            errorMessage += IsInt32(txtYears.Text, "Number of Years");
            errorMessage += IsWithinRange(txtYears.Text, "Number of Years", 1, 40);

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        public static string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg = name + " is a required field.\n";
            }
            return msg;
        }

        // TODO: improve this IsDecimal() method
        public static string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out _))
            {
                msg = name + " must be a valid decimal value.\n";
            }
            return msg;
        }

        // TODO: add a new method to test for currency entries
        public static string IsCurrency(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, NumberStyles.Currency, CultureInfo.CurrentCulture, out _))
            {
                msg += name + " must be in currency format.\n";
            }
            return msg;
        }

        // TODO: improve this IsInt32() method
        public static string IsInt32(string value, string name)
        {
            string msg = "";
            if (!Int32.TryParse(value, NumberStyles.None, CultureInfo.CurrentCulture, out _))
            {
                msg = name + " must be a valid integer value.\n";
            }
            return msg;
        }

        // TODO: improve this IsWithinRange() method
        public static string IsWithinRange(string value, string name, decimal min, decimal max)
        {
            string msg = "";
            if (Decimal.TryParse(value, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal number))
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
            }

            return futureValue;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}