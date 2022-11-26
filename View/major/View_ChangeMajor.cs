using StudentManager.Controller.major;
using System;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class View_ChangeMajor : Form
    {
        Controller_ChangeMajor Controller_ChangeMajor;
        public View_ChangeMajor()
        {
            InitializeComponent();
            Controller_ChangeMajor = new Controller_ChangeMajor();
        }

        private void View_ChangeMajor_Load(object sender, EventArgs e)
        {
            Controller_ChangeMajor.FindAcademy(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeMajor.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeMajor.FindMajor(comboBox2.Text, comboBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller_ChangeMajor.Change(comboBox3.Text,textBox1.Text);
            comboBox1.Items.Clear();
            Controller_ChangeMajor.FindAcademy(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
