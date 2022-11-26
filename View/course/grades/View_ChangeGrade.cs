using System;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class View_ChangeGrade : Form
    {
        Controller_ChangeGrade Controller_ChangeGrade;
        public View_ChangeGrade()
        {
            InitializeComponent();
            Controller_ChangeGrade = new Controller_ChangeGrade();
        }

        private void View_ChangeGrade_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_ChangeGrade.Change(textBox1.Text,textBox2.Text,textBox3.Text);
        }
    }
}
