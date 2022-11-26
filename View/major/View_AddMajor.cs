using StudentManager.Controller.major;
using System;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class View_AddMajor : Form
    {
        Controller_AddMajor Controller_AddMajor;
        public View_AddMajor()
        {
            InitializeComponent();
            Controller_AddMajor = new Controller_AddMajor();
        }

        private void View_AddMajor_Load(object sender, EventArgs e)
        {
            Controller_AddMajor.FindAcademy(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_AddMajor.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_AddMajor.FindMajor(comboBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller_AddMajor.Add(textBox1.Text);
            comboBox1.Items.Clear();
            Controller_AddMajor.FindAcademy(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
