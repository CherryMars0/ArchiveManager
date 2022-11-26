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
    public partial class View_ChangeCourse : Form
    {
        Controller_ChangeCourse Controller_ChangeCourse;
        public View_ChangeCourse()
        {
            InitializeComponent();
            Controller_ChangeCourse = new Controller_ChangeCourse();
        }

        private void View_ChangeCourse_Load(object sender, EventArgs e)
        {
            Controller_ChangeCourse.GetTeacher(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_ChangeCourse.Change(comboBox1.Text,comboBox2.Text,comboBox3.Text,textBox4.Text,textBox2.Text,textBox3.Text);
            comboBox2.Items.Clear();
            Controller_ChangeCourse.GetTeacher(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeCourse.FindCourse(comboBox1.Text, comboBox2);
            Controller_ChangeCourse.GetTeacher(comboBox3);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeCourse.SeaarchCourse(comboBox2.Text,comboBox1.Text,textBox4,textBox2,textBox3);
        }

    }
}
