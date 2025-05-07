namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        private void frmFutureValue_Load(object sender, EventArgs e)
        {
            // add numbers 1 through 20 to the combo box
            for (int i = 1; i < 21; i++)
            {
                cboYears.Items.Add(i);
            } 

            // select index 2 (3 years) as the default value
            cboYears.SelectedIndex = 2;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                    decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                    int years = Convert.ToInt32(cboYears.Text);

                    int months = years * 12;
                    decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

                    lstFutureValues.Items.Clear();
                    decimal futureValue = 0m;
                    for (int i = 0; i < months; i++)
                    {
                        futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
                        if ((i + 1) % 12 == 0) // every 12 months
                        {
                            int year = (i + 1) / 12; // get int for year
                            lstFutureValues.Items.Add(
                                "Year " + year + ": " + futureValue.ToString("c"));
                        }
                    }
                    txtMonthlyInvestment.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
            }
        }

        public bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            // Validate the Monthly Investment text box
            errorMessage += IsDecimal(txtMonthlyInvestment.Text, "Monthly Investment");
            errorMessage += IsWithinRange(txtMonthlyInvestment.Text, "Monthly Investment", 1, 1000);

            // Validate the Yearly Interest Rate text box
            errorMessage += IsDecimal(txtInterestRate.Text, "Yearly Interest Rate");
            errorMessage += IsWithinRange(txtInterestRate.Text, "Yearly Interest Rate", 1, 20);

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

        public static string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg = name + " must be a valid decimal value.\n";
            }
            return msg;
        }

        public static string IsInt32(string value, string name)
        {
            string msg = "";
            if (!Int32.TryParse(value, out _))
            {
                msg = name + " must be a valid integer value.\n";
            }
            return msg;
        }

        public static string IsWithinRange(string value, string name, decimal min, decimal max)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}