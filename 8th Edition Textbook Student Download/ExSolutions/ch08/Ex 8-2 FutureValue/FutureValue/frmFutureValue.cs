namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        // declare the rectangular array and the row index
        string[,] calculationsTable = new string[10, 4];
        int row = 0;

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

                    // add the calculation to the rectangular array
                    decimal interestRatePercent = yearlyInterestRate / 100;
                    calculationsTable[row, 0] = monthlyInvestment.ToString("c");
                    calculationsTable[row, 1] = interestRatePercent.ToString("p1");
                    calculationsTable[row, 2] = years.ToString();
                    calculationsTable[row, 3] = futureValue.ToString("c");
                    row++;
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
            // display the rectangular array in a dialog box
            string message = "Inv/Mo.\tRate\tYears\tFuture Value\n";
            for (int i = 0; i < calculationsTable.GetLength(0); i++)
            {
                if (calculationsTable[i, 0] != null)
                {
                    for (int j = 0; j < calculationsTable.GetLength(1); j++)
                    {
                        message += calculationsTable[i, j] + "\t";
                    }
                    message += "\n";
                }
            }
            MessageBox.Show(message, "Future Value Calculations");

            this.Close();
        }
    }
}