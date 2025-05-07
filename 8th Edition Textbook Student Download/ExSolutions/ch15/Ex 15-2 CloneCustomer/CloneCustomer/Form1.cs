namespace CloneCustomer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Customer customer = null!;

        private void Form1_Load(object sender, EventArgs e)
        {
            customer = new("John", "Mendez", "jmendez@msysco.com");
            lblCustomer.Text = customer.GetDisplayText();
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            string errorMessage = Validator.IsInt32(txtCopies.Text, "Copies");
            if (string.IsNullOrEmpty(errorMessage))
            {
                int count = Convert.ToInt16(txtCopies.Text);
                CustomList<IDisplayable> copies = MakeCopiesForDisplay(customer, count);

                lstCustomers.Items.Clear();
                foreach (IDisplayable copy in copies)
                {
                    lstCustomers.Items.Add(copy.GetDisplayText());
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "Entry Error");
            }
        }

        private CustomList<IDisplayable> MakeCopiesForDisplay(ICloneable obj, int numCopies)
        {
            CustomList<IDisplayable> list = new();

            for (int i = 0; i < numCopies; i++)
            {
                IDisplayable copy = (IDisplayable)obj.Clone();
                list.Add(copy);
            }

            return list;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}