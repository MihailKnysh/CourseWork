using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace C_Work
{
    static class FM
    {
        public static Random random = new Random();

        public static IList<T> RandomShuffle<T>(this IEnumerable<T> list)
        {
            var shuffle = new List<T>(list);

            for (var i = shuffle.Count - 1; i >= 1; i--)
            {
                var nextRand = random.Next(i + 1);
                var temp = shuffle[i];

                shuffle[i] = shuffle[nextRand];
                shuffle[nextRand] = temp;
            }

            return shuffle;
        }

        public static PictureBox CreatePictureBox(Form form)
        {
            var pictureBox = new PictureBox
            {
                Size = new Size(500, 40),
                Location = new Point(20, 20),
                Visible = true
            };

            form.Controls.Add(pictureBox);

            return pictureBox;
        }

        public static RadioButton[] CreateRadioButtons(Form form, int numberOfAnswers, int xPoint = 40)
        {
            var radioButtons = new RadioButton[numberOfAnswers];

            for (int i = 0; i < numberOfAnswers; i++)
            {
                xPoint += 100;
                radioButtons[i] = new RadioButton
                {
                    Location = new Point(xPoint, 100),
                    AutoSize = true,
                    Visible = true,
                    CheckAlign = ContentAlignment.TopCenter,
                    Font = new Font("Microsoft Sans Serif", 12)
                };

                form.Controls.Add(radioButtons[i]);
            }

            return radioButtons;
        }
    }
}
