namespace ScoreCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count = 0;
        int[] scores = new int[10];

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int score = Convert.ToInt32(txtScore.Text);

                scores[count] = score;
                count++;

                int total = 0;
                foreach (int s in scores)
                {
                    total += s;
                }
                int average = total / count;

                txtScoreTotal.Text = total.ToString();
                txtScoreCount.Text = count.ToString();
                txtAverage.Text = average.ToString();

                txtScore.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            count = 0;
            scores = new int[10]; // replace current array with new empty array

            txtScore.Text = "";
            txtScoreTotal.Text = "";
            txtScoreCount.Text = "";
            txtAverage.Text = "";

            txtScore.Focus();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string scoresString = "";

            Array.Sort(scores);
            foreach (int s in scores)
            {
                if (s != 0)
                {
                    scoresString += s.ToString() + "\n";
                }
            }
            MessageBox.Show(scoresString, "Sorted Scores");
            txtScore.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}