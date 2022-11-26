using StudentManager.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManager
{
    public partial class View_DelClass : Form
    {
        Controller_DelClass Controller_DelClass;
        public View_DelClass()
        {
            InitializeComponent();
            Controller_DelClass = new Controller_DelClass();
        }

        private void View_DelClass_Load(object sender, EventArgs e)
        {
            Controller_DelClass.FindAcademy(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_DelClass.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_DelClass.FindMajor(comboBox2.Text, comboBox3);
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            Controller_DelClass.FindClass(comboBox3.Text, comboBox4);
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            Controller_DelClass.GetClass(comboBox4.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_DelClass.Delete(comboBox4.Text);
        }

       
    }
}
