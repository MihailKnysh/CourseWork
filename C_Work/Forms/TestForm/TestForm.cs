using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C_Work
{
    public partial class TestForm : Form
    {
        public static int counterOfTrueAnswers = 0;
        public static int numTasks = 10;
        public static DateTime DurationOfTest;
        public static string progressOfBaseOperations = String.Empty;
        public StringBuilder stringBuilder = new StringBuilder(21);
        private DateTime stopWatch;
        private static int parametr = 0;//Counter of questions
        private const int numAnswers = 4;//Number of radio buttons
        private int positionOfTrueAnswer;

        private List<string> imagePathes = Data.GetPathesToImgFromDB();
        private List<string> trueAnswers = Data.GetTrueAnswersFromDB();

        public TestForm()
        {
            InitializeComponent();
            //Data data = new Data();
            //imagePathes = data.GetPathesToImgFromDB(); //Methods.GetPathesToImgFromDB();
            //trueAnswers = data.GetTrueAnswersFromDB();
        }

        public TestForm(StartForm usForm) => InitializeComponent();

        /*   For testing
        private List<string> imagePathes = new List<string>() { "Pictures\\1.6.png",
                                                            "Pictures\\2.1.png",
                                                            "Pictures\\2.8.png",
                                                            "Pictures\\2.14.png"};

        private List<string> trueAnswers = new List<string>() { "0110", "00101000", "0001", "11101110" };
        */

        private void timer1_Tick(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - stopWatch.Ticks;
            DurationOfTest = new DateTime();

            DurationOfTest = DurationOfTest.AddTicks(tick);
            label_StopWatch.Text = $"{DurationOfTest:HH:mm:ss}";
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            if (label_ErrorMassage.Visible)
                label_ErrorMassage.Visible = false;

            stopWatch = DateTime.Now;

            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();


            RadioButton[] answerButtons = { answer1, answer2, answer3, answer4 };

            Methods.ShowBinaryCodeInLabel(label_BinaryXYZ, trueAnswers[parametr].Length);
            Methods.ShowProgressInLabel(label_Progress, parametr, numTasks/*trueAnswers.Count*/);
            Methods.GenerateFalseAnswers(answerButtons,
                trueAnswers[parametr], numAnswers, out positionOfTrueAnswer);

            imageWithTask.Image = Image.FromFile(imagePathes[parametr]);

            parametr++;
        }

        private void Next_Button(object sender, EventArgs e)
        {
            if (label_ErrorMassage.Visible)
                label_ErrorMassage.Visible = false;

            if (!answer1.Checked && !answer2.Checked && !answer3.Checked && !answer4.Checked)
            {
                label_ErrorMassage.Visible = true;
                return;
            }
            else
            {
                label_ErrorMassage.Visible = false;
            }
            
            //else if (parametr != imagePathes.Count)
            //{
            RadioButton[] answerButtons = { answer1, answer2, answer3, answer4 };

            if (answerButtons[positionOfTrueAnswer].Checked)
            {
                counterOfTrueAnswers++;

                //progressOfBaseOperations += "+";

                stringBuilder.Append("+ ");

                //MessageBox.Show(progressOfBaseOperations);
                MessageBox.Show(stringBuilder.ToString());
            }
            else
            {
                stringBuilder.Append("- ");

                //progressOfBaseOperations += "-";

                //MessageBox.Show(progressOfBaseOperations);
                MessageBox.Show(stringBuilder.ToString());
            }
            

            if (parametr != numTasks/*imagePathes.Count*/)
            {
                Methods.ShowBinaryCodeInLabel(label_BinaryXYZ, trueAnswers[parametr].Length);
                Methods.ShowProgressInLabel(label_Progress, parametr, numTasks/*trueAnswers.Count*/);
                Methods.GenerateFalseAnswers(answerButtons,
                    trueAnswers[parametr], numAnswers, out positionOfTrueAnswer);

                imageWithTask.Image = Image.FromFile(imagePathes[parametr]);
                
                parametr++;
            }
            //}
            else
            {
                var resultForm = new UserDataForm(this);
                this.Hide();
                resultForm.Show();
                //resultForm.label10.Text = counterOfTrueAnswers.ToString();
                //resultForm.label7.Text = this.label4.Text;
                //resultForm.label8.Text = this.label5.Text;
                //resultForm.label9.Text = this.label6.Text;
                parametr = 0;
                progressOfBaseOperations = stringBuilder.ToString();

                //MessageBox.Show(stringBuilder.ToString());
            }
        }
    }
}
