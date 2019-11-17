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

            string sqlExpression = "INSERT INTO History (FirstName, SecondName, CorrectAnswers, Mark) " +
                "VALUES (@firstName, @secondName, @num, @mark)";

            var connection = new SqlConnection(Methods.connectionString);
            
                connection.Open();
            var command = new SqlCommand(sqlExpression, connection);

            command.Parameters.AddWithValue("firstName", firstName);
            command.Parameters.AddWithValue("secondName", secondName);
            command.Parameters.AddWithValue("num", numOfTrueAnswers);
            command.Parameters.AddWithValue("mark", mark);
            //SqlParameter firstNameParameter = new SqlParameter("@firstName", firstName);
            //command.Parameters.Add(firstNameParameter);

            //SqlParameter secondNameParameter = new SqlParameter("@secondName", secondName);
            //command.Parameters.Add(secondNameParameter);

            //SqlParameter numTrueAnswersParameter = new SqlParameter("@num", numOfTrueAnswers);
            //command.Parameters.Add(numTrueAnswersParameter);

            //SqlParameter markParameter = new SqlParameter("@mark", mark);
            //command.Parameters.Add(markParameter);


            //Fill DB

            var startForm = new StartForm(this);
            startForm.Show();
            this.Hide();
        }
    }
}
