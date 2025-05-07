using ProductMaintenance.Models.DataLayer;

namespace ProductMaintenance;

public partial class frmProductMaintenance : Form
{
    public frmProductMaintenance()
    {
        InitializeComponent();
    }

    private MMABooksDataAccess data = new();
    private Product selectedProduct = null!;

    private void frmProductMaintenance_Load(object sender, EventArgs e)
    {
        DisplayProducts();
    }

    private void DisplayProducts()
    {
        dgvProducts.Columns.Clear();
        dgvProducts.DataSource = data.GetAllProducts();

        // add column for modify button
        DataGridViewButtonColumn modifyColumn = new()
        {
            UseColumnTextForButtonValue = true,
            HeaderText = "",
            Text = "Modify"
        };
        dgvProducts.Columns.Add(modifyColumn);

        // add column for delete button
        DataGridViewButtonColumn deleteColumn = new()
        {
            UseColumnTextForButtonValue = true,
            HeaderText = "",
            Text = "Delete"
        };
        dgvProducts.Columns.Add(deleteColumn);

        // format the column header
        dgvProducts.EnableHeadersVisualStyles = false;
        dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
        dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
        dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        // format the odd numbered rows
        dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

        // format the first column
        dgvProducts.Columns[0].HeaderText = "Product Code";
        dgvProducts.Columns[0].Width = 110;

        // format the second column
        dgvProducts.Columns[1].Width = 220;

        // format the third column
        dgvProducts.Columns[2].HeaderText = "Unit Price";
        dgvProducts.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvProducts.Columns[2].Width = 90;
        dgvProducts.Columns[2].DefaultCellStyle.Format = "c";
        dgvProducts.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvProducts.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // index values for Modify and Delete button columns
        const int ModifyIndex = 3;
        const int DeleteIndex = 4;

        if (e.RowIndex > -1)  // make sure header row wasn't clicked
        {
            if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
            {
                DataGridViewCell cell = dgvProducts.Rows[e.RowIndex].Cells[0];
                string productCode = cell.Value?.ToString()?.Trim() ?? "";
                selectedProduct = data.FindProduct(productCode)!;
            }

            if (selectedProduct != null)
            {
                if (e.ColumnIndex == ModifyIndex)
                {
                    ModifyProduct();
                }
                else if (e.ColumnIndex == DeleteIndex)
                {
                    DeleteProduct();
                }
            }
        }
    }

    private void ModifyProduct()
    {
        frmAddModify addModifyForm = new()
        {
            Product = selectedProduct 
        };
        DialogResult result = addModifyForm.ShowDialog();

        if (result == DialogResult.OK)
        {
            try
            {
                selectedProduct = addModifyForm.Product;
                data.UpdateProduct(selectedProduct);
                DisplayProducts();
            }
            catch (DataAccessException ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void DeleteProduct()
    {
        DialogResult result =
            MessageBox.Show($"Delete {selectedProduct.ProductCode.Trim()}?", 
            "Confirm Delete", MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                data.RemoveProduct(selectedProduct);
                DisplayProducts();
            }
            catch (DataAccessException ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        frmAddModify addModifyForm = new();
        DialogResult result = addModifyForm.ShowDialog();  

        if (result == DialogResult.OK)
        {
            try
            {
                selectedProduct = addModifyForm.Product;
                data.AddProduct(selectedProduct);
                DisplayProducts();
            }
            catch (DataAccessException ex)
            {
                HandleDataAccessError(ex);
            }
        }
    }

    private void HandleDataAccessError(DataAccessException ex)
    {
        // if concurrency conflict, re-display products
        if (ex.IsConcurrencyError)
        {
            DisplayProducts();
        }

        // display error message in dialog with error type as title
        MessageBox.Show(ex.Message, ex.ErrorType);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    
}
