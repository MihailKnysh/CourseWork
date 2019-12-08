using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C_Work
{
    public partial class ResultForm : Form
    {
        private static int listSize = 21;
        private int numOfTrueAnswers = TestForm.counterOfTrueAnswers;
        private int mark;
        private DateTime date = DateTime.Now;
        private DateTime time = DateTime.Now;
        private DateTime duration = DateTime.Now;

        public ResultForm() => InitializeComponent();
        public ResultForm(UserDataForm testForm) => InitializeComponent();

        private void ResultForm_Load(object sender, EventArgs e)
        {
            label_Number.Text = numOfTrueAnswers.ToString();
            mark = numOfTrueAnswers * 100 / listSize;
            label_Mark.Text = mark.ToString();
            label_Duration.Text = TestForm.DurationOfTest.ToLongTimeString();//проверить, что вноситься в бд
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestForm.counterOfTrueAnswers = 0;

            string firstName = label_FirstName.Text;
            string secondName = label_SecondName.Text;
            string sGroup = label_Group.Text;

            string sqlExpression = "INSERT History VALUES " +
                "(@FirstName, @SecondName, @Date, @Time, @CorrectAnswers, @Mark, @Duration, @StudyGroup)";
            var connection = new SqlConnection(Methods.connectionString);

            connection.Open();

            var command = new SqlCommand(sqlExpression, connection);

            command.Parameters.AddWithValue("FirstName", firstName);
            command.Parameters.AddWithValue("SecondName", secondName);
            command.Parameters.AddWithValue("Date", date);
            command.Parameters.AddWithValue("Time", time);
            command.Parameters.AddWithValue("CorrectAnswers", numOfTrueAnswers);
            command.Parameters.AddWithValue("Mark", mark);
            command.Parameters.AddWithValue("Duration", label_Duration.Text/*duration*//*TestForm.DurationOfTest*/);
            command.Parameters.AddWithValue("StudyGroup", sGroup);

            command.ExecuteNonQuery();

            connection.Close();


            //command.Parameters.AddWithValue("firstName", firstName);
            //command.Parameters.AddWithValue("secondName", secondName);
            //command.Parameters.AddWithValue("num", numOfTrueAnswers);
            //command.Parameters.AddWithValue("mark", mark);



            //Fill DB

            var startForm = new StartForm(this);
            startForm.Show();
            this.Hide();
        }
    }
}
