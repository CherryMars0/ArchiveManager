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
    public partial class View_DeleteCourse : Form
    {
        Controller_DeleteCourse Controller_DeleteCourse;
        public View_DeleteCourse()
        {
            InitializeComponent();
            Controller_DeleteCourse = new Controller_DeleteCourse();
        }

        private void View_DeleteCourse_Load(object sender, EventArgs e)
        {
            Controller_DeleteCourse.GetCourse(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_DeleteCourse.Delete(comboBox1.Text,comboBox2.Text);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_DeleteCourse.SearchTeacher(comboBox1.Text,comboBox2);
        }
    }
}
