namespace LengthConversions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[,] conversionTable = {
        {"Miles to kilometers", "Miles:", "Kilometers:", "1.6093"},
        {"Kilometers to miles", "Kilometers:", "Miles:", "0.6214"},
        {"Feet to meters", "Feet:", "Meters:", "0.3048"},
        {"Meters to feet", "Meters:", "Feet:", "3.2808"},
        {"Inches to centimeters", "Inches:", "Centimeters:", "2.54"},
        {"Centimeters to inches", "Centimeters:", "Inches:", "0.3937"}
    };

        public string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg = name + " is a required field.\n";
            }
            return msg;
        }

        public string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg = name + " must be a valid decimal value.\n";
            }
            return msg;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}