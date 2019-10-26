using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace C_Work
{
    static class Data
    {
        private const string connectionString = @"Data Source=DESKTOP-8AL13S1;Initial Catalog=Testing_system;Integrated Security=True";

        public static List<string> GetTrueAnswersFromDB()
        {
            var trueAnswers = new List<string>();
            string sqlExpression = "SELECT Answer FROM TaskAnswer";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object ans = reader.GetValue(0);

                        trueAnswers.Add(ans.ToString());
                    }
                }
                reader.Close();
            }
            return trueAnswers;
        }

        public static List<string> GetPathesToImgFromDB()
        {
            var imagePathes = new List<string>();
            string sqlExpression = "SELECT PathToImg FROM TaskAnswer";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object path = reader.GetValue(0);
                        imagePathes.Add(path.ToString());
                    }
                }
                reader.Close();
            }
            return imagePathes;
        }
    }
}
