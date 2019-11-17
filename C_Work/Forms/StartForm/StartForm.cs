using System;
using System.Windows.Forms;

namespace C_Work
{
    public partial class StartForm : Form
    {
        public StartForm() => InitializeComponent();
        public StartForm(ResultForm resultForm) => InitializeComponent();
        public StartForm(HistoryForm historyForm) => InitializeComponent();

        private void Start_Button(object sender, EventArgs e)
        {
            var testForm = new TestForm(this);
            this.Hide();
            testForm.Show();
        }

        private void History_Button(object sender, EventArgs e)
        {
            var hForm = new HistoryForm(this);
            hForm.Show();
            this.Hide();
        }

        private void Exit_Button(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
