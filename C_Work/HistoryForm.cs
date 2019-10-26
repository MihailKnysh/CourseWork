using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string sql = "SELECT * FROM History";
            using (var connection = new SqlConnection(Methods.connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(sql, connection);

                var ds = new DataSet();

                adapter.Fill(ds);

                // Отображаем данные
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Duration"].Visible = false;
                dataGridView1.Columns["Date"].Visible = false;
                dataGridView1.Columns["Time"].Visible = false;
            }
        }
    }
}
