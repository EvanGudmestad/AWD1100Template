namespace InventoryMaintenance
{
    public partial class frmNewItem : Form
    {
        public frmNewItem()
        {
            InitializeComponent();
        }

        private InventoryItem item = null!;

        public InventoryItem GetNewItem()
        {
            rdoPlant.Checked = true;
            this.ShowDialog();
            return item;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (rdoPlant.Checked)
                {
                    item = new Plant(
                        Convert.ToInt32(txtItemNo.Text),
                        txtDescription.Text,
                        Convert.ToDecimal(txtPrice.Text),
                        cboSizeOrManufacturer.SelectedItem.ToString()!
                    );
                }
                else
                {
                    item = new Supply(
                        Convert.ToInt32(txtItemNo.Text),
                        txtDescription.Text,
                        Convert.ToDecimal(txtPrice.Text),
                        cboSizeOrManufacturer.SelectedItem.ToString()!
                    );
                }

                Close();
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtItemNo.Text, "Item no");
            errorMessage += Validator.IsInt32(txtItemNo.Text, "Item no");
            errorMessage += Validator.IsPresent(txtDescription.Text, "Description");
            errorMessage += Validator.IsPresent(txtPrice.Text, "Price");
            errorMessage += Validator.IsDecimal(txtPrice.Text, "Price");

            // Validate combo box - use label text for name - remove ending colon
            string name = lblSizeOrManufacturer.Text.Substring(0, lblSizeOrManufacturer.Text.Length - 1);
            errorMessage += Validator.IsSelected(cboSizeOrManufacturer.SelectedIndex, name);

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private void rdoPlant_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPlant.Checked)
                lblSizeOrManufacturer.Text = "Size:";
            else
                lblSizeOrManufacturer.Text = "Manufacturer:";

            LoadComboBox();
        }

        private void LoadComboBox()
        {
            cboSizeOrManufacturer.Items.Clear();
            if (rdoPlant.Checked)
            {
                cboSizeOrManufacturer.Items.Add("1 gallon");
                cboSizeOrManufacturer.Items.Add("5 gallon");
                cboSizeOrManufacturer.Items.Add("15 gallon");
                cboSizeOrManufacturer.Items.Add("24-inch box");
                cboSizeOrManufacturer.Items.Add("36-inch box");
            }
            else
            {
                cboSizeOrManufacturer.Items.Add("Bayer");
                cboSizeOrManufacturer.Items.Add("Jobe's");
                cboSizeOrManufacturer.Items.Add("Ortho");
                cboSizeOrManufacturer.Items.Add("Roundup");
                cboSizeOrManufacturer.Items.Add("Scotts");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}