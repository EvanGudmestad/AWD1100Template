namespace FinancialCalculations
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnInvestment_Click(object sender, EventArgs e)
        {
            frmInvestment form = new frmInvestment();
            form.Show();
        }

        private void btnDepreciation_Click(object sender, EventArgs e)
        {
            frmDepreciation form = new frmDepreciation();
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}