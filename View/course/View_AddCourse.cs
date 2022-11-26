using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class View_AddCourse : Form
    {
        Controller_AddCourse Controller_AddCourse;
        public View_AddCourse()
        {
            InitializeComponent();
            Controller_AddCourse = new Controller_AddCourse();
        }

        private void View_AddCourse_Load(object sender, EventArgs e)
        {
            Controller_AddCourse.GetTeacher(comboBox4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_AddCourse.Add(textBox2.Text,textBox1.Text,textBox4.Text,textBox3.Text,comboBox4.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
