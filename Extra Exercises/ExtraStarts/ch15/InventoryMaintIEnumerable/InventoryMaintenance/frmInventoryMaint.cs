namespace InventoryMaintenance
{
    public partial class frmInventoryMaint : Form
    {
        public frmInventoryMaint()
        {
            InitializeComponent();
        }

        private InventoryItemList items = new();

        private void frmInventoryMaint_Load(object sender, EventArgs e)
        {
            items.Changed += new InventoryItemList.ChangeHandler(HandleChange);
            items.Fill();
            FillItemListBox();
        }

        private void FillItemListBox()
        {
            IDisplayable item;
            lstItems.Items.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                item = items[i];
                lstItems.Items.Add(item.GetDisplayText());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewItem newItemForm = new();
            InventoryItem item = newItemForm.GetNewItem();

            if (item != null)
            {
                items += item;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;

            if (i == -1)
            {
                MessageBox.Show("Please select an item to delete.", "No item selected");
            }
            else
            {
                InventoryItem item = items[i];

                string message = $"Are you sure you want to delete {item.Description}?";
                DialogResult result =
                    MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    items -= item;
                }
            }
        }

        private void HandleChange(InventoryItemList invItems)
        {
            invItems.Save();
            FillItemListBox();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}