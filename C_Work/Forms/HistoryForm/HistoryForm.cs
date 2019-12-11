using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C_Work
{
    public partial class HistoryForm : Form
    {
        public HistoryForm() => InitializeComponent();

        public HistoryForm(StartForm sForm) => InitializeComponent();

        private void button1_Click(object sender, EventArgs e)
        {
            var startForm = new StartForm(this);
            this.Hide();
            startForm.Show();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testing_systemDataSet.History". При необходимости она может быть перемещена или удалена.
            this.historyTableAdapter.Fill(this.testing_systemDataSet.History);
            string sql = "SELECT * FROM History";

            using (var connection = new SqlConnection(Methods.connectionString))
            {
                connection.Open();

                var adapter = new SqlDataAdapter(sql, connection);
                var ds = new DataSet();

                adapter.Fill(ds);

                // Visualisation data
                dataGridView1.DataSource = ds.Tables[0];
                //dataGridView1.Columns["Duration"].Visible = false;
                //dataGridView1.Columns["Date"].Visible = false;
                //dataGridView1.Columns["Time"].Visible = false;
            }
        }
    }
}
