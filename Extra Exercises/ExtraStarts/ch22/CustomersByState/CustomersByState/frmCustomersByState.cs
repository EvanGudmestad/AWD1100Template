using CustomersByState.Models.DataLayer;

namespace CustomersByState
{
    public partial class frmCustomersByState : Form
    {
        public frmCustomersByState()
        {
            InitializeComponent();
        }

        MMABooksDataAccess data = new();

        // private constants and variables for paging
        private const int MaxRows = 5;
        private int totalRows = 0;
        private int pages = 0;
        private int pageNumber = 1;

        private void frmCustomersByState_Load(object sender, EventArgs e)
        {
            totalRows = data.StateCount;
            pages = totalRows / MaxRows;
            if (totalRows % MaxRows != 0)
            {
                pages += 1;
            }

            pageNumber = 1;

            DisplayStates();
        }

        private void DisplayStates()
        {
            dgvStates.Columns.Clear();

            int skip = MaxRows * (pageNumber - 1);

            totalRows = data.StateCount;
            int take = MaxRows;
            if (pageNumber == pages)
            {
                take = totalRows - skip;
            }
            if (totalRows <= MaxRows)
            {
                take = totalRows;
            }

            dgvStates.DataSource = data.GetStates(skip, take);

            // do general formatting
            FormatGrid(dgvStates);

            // format the first column
            dgvStates.Columns[0].HeaderText = "Code";
            dgvStates.Columns[0].Width = 60;

            // format the second column
            dgvStates.Columns[1].HeaderText = "State Name";
            dgvStates.Columns[1].Width = 120;

            EnableDisableButtons();
        }

        private void FormatGrid(DataGridView grid)
        {
            // format the column headers
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font("Arial", 9, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            grid.AlternatingRowsDefaultCellStyle.BackColor =
                Color.PaleGoldenrod;
        }

        private void EnableDisableButtons()
        {
            if (pageNumber == 1)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }

            if (pageNumber == pages)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            DisplayStates();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pageNumber -= 1;
            DisplayStates();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pageNumber += 1;
            DisplayStates();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pageNumber = pages;
            DisplayStates();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}