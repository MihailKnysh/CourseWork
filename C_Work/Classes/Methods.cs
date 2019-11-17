using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;


namespace C_Work
{
    static class Methods
    {
        public const string connectionString = @"Data Source=DESKTOP-8AL13S1;Initial Catalog=Testing_system;Integrated Security=True";
        public static string StringToColumn(string str)
        {
            var tmp = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                tmp.AppendLine(str[i].ToString());
            }
            return tmp.ToString();
        }

        private const string xy = "x  y\n" +
                                            "0  0\n" +
                                            "0  1\n" +
                                            "1  0\n" +
                                            "1  1";

        private const string xyz = "x  y  z\n" +
                                             "0  0  0\n" +
                                             "0  0  1\n" +
                                             "0  1  0\n" +
                                             "0  1  1\n" +
                                             "1  0  0\n" +
                                             "1  0  1\n" +
                                             "1  1  0\n" +
                                             "1  1  1\n";

        public static void ShowBinaryCodeInLabel(Label label, int length)
        {
            label.Text = length == 4 ? xy : xyz;
        }

        public static void ShowProgressInLabel(Label label, int current, int total)
        {
            //label.Text = current + 1 + " of " + total;
            label.Text = $"{current + 1} of {total}"; // interpolation
            //label.Text = String.Format("{0} of {1}", current + 1, total);
        }
        
        public static void FillPictureBox(Form form, string imagePath)
        {
            PictureBox imageWithTask = FM.CreatePictureBox(form);
            //byte[] arr = System.IO.File.ReadAllBytes(imagePath);
            //System.IO.MemoryStream ms = new System.IO.MemoryStream(arr);
            //Image img = Image.FromStream(ms);
            imageWithTask.Image = Image.FromFile(imagePath);
        }

        public static void GenerateFalseAnswers(RadioButton[] answerButtons, string trueAnswer, int numAnswers, out int randomPosition)
        {
            // trueAnswer = "11110000";
            randomPosition = FM.random.Next(numAnswers);
            answerButtons[randomPosition].Text = StringToColumn(trueAnswer);
            int[] arr = Enumerable.Range(0, trueAnswer.Length).RandomShuffle().Take(numAnswers - 1).ToArray();

            for (int i = 0, k = 0; i < numAnswers; i++)
            {
                if (i == randomPosition)
                    continue;
                var sb = new StringBuilder(trueAnswer);

                if (sb[arr[k]] == '0')
                    sb.Replace('0', '1', arr[k++], 1);
                else
                    sb.Replace('1', '0', arr[k++], 1);
                answerButtons[i].Text = StringToColumn(sb.ToString());
            }
        }

        //public static List<string> GetTrueAnswersFromDB()
        //{
        //    var trueAnswers = new List<string>();
        //    string sqlExpression = "SELECT Answer FROM TaskAnswer";
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        var command = new SqlCommand(sqlExpression, connection);
        //        var reader = command.ExecuteReader();

        //        if (reader.HasRows) // если есть данные
        //        {
        //            while (reader.Read()) // построчно считываем данные
        //            {
        //                object ans = reader.GetValue(0);

        //                trueAnswers.Add(ans.ToString());
        //            }
        //        }
        //        reader.Close();
        //    }
        //    return trueAnswers;
        //}

        //public static List<string> GetPathesToImgFromDB()
        //{
        //    var imagePathes = new List<string>();
        //    string sqlExpression = "SELECT PathToImg FROM TaskAnswer";
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        var command = new SqlCommand(sqlExpression, connection);
        //        var reader = command.ExecuteReader();

        //        if (reader.HasRows) // если есть данные
        //        {
        //            while (reader.Read()) // построчно считываем данные
        //            {
        //                object path = reader.GetValue(0);
        //                imagePathes.Add(path.ToString());
        //            }
        //        }
        //        reader.Close();
        //    }
        //    return imagePathes;
        //}









































        /*Methods.ShowBinaryCodeInLabel(label1, trueAnswers[parametr].Length);

            PictureBox picb = new PictureBox();
            picb.Size = new Size(500, 40);
            picb.Location = new Point(20, 20);
            picb.Visible = true;
            this.Controls.Add(picb);

            byte[] barr = System.IO.File.ReadAllBytes(imagePathes[1]);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(barr);
            Image img = System.Drawing.Image.FromStream(ms);
            picb.Image = img;

            Methods.ShowProgressInLabel(label2, parametr, trueAnswers.Count);//imagePathes[parametr].Length

            RadioButton[] radioButtons = new RadioButton[4];
            int stposX = 40;
            for (int i = 0, j = 4; i < 4; i++, j++)
            {
                stposX += 100;
                radioButtons[i] = new RadioButton();
                radioButtons[i].Location = new Point(stposX, 100);
                radioButtons[i].AutoSize = true;
                radioButtons[i].Visible = true;
                radioButtons[i].CheckAlign = ContentAlignment.TopCenter;
                radioButtons[i].Font = new Font("Microsoft Sans Serif", 12);
                //radioButtons[i].Text = Methods.stringToColumn(answers[j]);
                Controls.Add(radioButtons[i]);
            }
            stposX = 40;
            Methods.GenerateFalseAnswers(radioButtons, trueAnswers[parametr], numAnswers);*/

        /*string[,] xy = { { "x", "y" },
                             { "0", "0" },
                             { "0", "1" },
                             { "1", "0" },
                             { "1", "1" } };

        string[,] xyz = { { "x", "y", "z" },
                              { "0", "0", "0" },
                              { "0", "0", "1" },
                              { "0", "1", "0" },
                              { "0", "1", "1" },
                              { "1", "0", "0" },
                              { "1", "0", "1" },
                              { "1", "1", "0" },
                              { "1", "1", "1" } };


        bool[] TrueAnswers;
        public string GenerateBinaryElements(string TrueStr)
        {
            int i = 0;
            int[] NewInt = new int[TrueStr.Length];
            Random r = new Random();
            for (i = 0; i < TrueStr.Length; i++)
            {
                NewInt[i] = r.Next(0, 2);
            }
            //string NewStr = NewInt.ToString();
            char[] NewCh = new char[TrueStr.Length];

            for (i = 0; i < TrueStr.Length; i++)
            {
                NewCh[i] = Convert.ToChar(NewInt[i]);
            }
            string tmp = new string(NewCh);

            return tmp;
        }*/

        /*
                     int i = 0;
            int[] NewInt = new int[TrueStr.Length];
            Random r = new Random();
            for (i = 0; i < TrueStr.Length; i++) 
            {
                NewInt[i] = r.Next(0, 2);
               // MessageBox.Show(NewInt.ToString());
            }
            //MessageBox.Show(Convert.ToString(NewInt));
            int[] TrueInt = new int[TrueStr.Length];

            for (i = 0; i < TrueStr.Length; i++)
            {
                TrueInt[i] = Convert.ToInt32(TrueStr[i]);
            }

            string NewStr = TrueInt.ToString();

            return NewStr;

             */

        //string imagePath1 = @"C:\Users\M\Downloads\1.7\1.1.png";
        //string imagePath2 = @"C:\Users\M\Downloads\1.7\1.4.png";
        //string imagePath3 = @"C:\Users\M\Downloads\1.7\2.1.png";

    }
}
