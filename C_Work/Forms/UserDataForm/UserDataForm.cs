using System;
using System.Windows.Forms;

namespace C_Work
{
    public partial class UserDataForm : Form
    {
        public UserDataForm() => InitializeComponent();
        public UserDataForm(TestForm tForm) => InitializeComponent();

        private void Next_Button(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_FirstName.Text) || string.IsNullOrWhiteSpace(textBox_FirstName.Text) ||
                string.IsNullOrEmpty(textBox_SecondName.Text) || string.IsNullOrWhiteSpace(textBox_SecondName.Text) ||
                string.IsNullOrEmpty(textBox_Group.Text) || string.IsNullOrWhiteSpace(textBox_Group.Text))
            {
                label_ErrorMassage.Visible = true;
            }
            else
            {
                var resultForm = new ResultForm(this);

                resultForm.label_FirstName.Text = textBox_FirstName.Text;
                resultForm.label_SecondName.Text = textBox_SecondName.Text;
                resultForm.label_Group.Text = textBox_Group.Text;
                this.Hide();
                resultForm.Show();
            }
        }

        private void UserDataForm_Load(object sender, EventArgs e)
        {
            if (label_ErrorMassage.Visible)
                label_ErrorMassage.Visible = false;
        }
    }
}
