using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

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
            label.Text = $"{current + 1} of {total}";
        }
        
        public static void FillPictureBox(Form form, string imagePath)
        {
            PictureBox imageWithTask = FM.CreatePictureBox(form);
            imageWithTask.Image = Image.FromFile(imagePath);
        }

        public static void GenerateFalseAnswers(RadioButton[] answerButtons, string trueAnswer, int numAnswers, out int randomPosition)
        {
            randomPosition = FM.random.Next(numAnswers);
            answerButtons[randomPosition].Text = StringToColumn(trueAnswer);
            int[] arr = Enumerable.Range(0, trueAnswer.Length).RandomShuffle().Take(numAnswers - 1).ToArray();

            for (int i = 0, k = 0; i < numAnswers; i++)
            {
                if (i == randomPosition)
                {
                    continue;
                }

                var sb = new StringBuilder(trueAnswer);

                if (sb[arr[k]] == '0')
                {
                    sb.Replace('0', '1', arr[k++], 1);
                }
                else
                {
                    sb.Replace('1', '0', arr[k++], 1);
                }

                answerButtons[i].Text = StringToColumn(sb.ToString());
            }
        }
    }
}