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
    public partial class View_ChangeClass : Form
    {
        Controller_ChangeClass Controller_ChangeClass;
        public View_ChangeClass()
        {
            InitializeComponent();
            Controller_ChangeClass = new Controller_ChangeClass();
        }

        private void View_ChangeClass_Load(object sender, EventArgs e)
        {
            Controller_ChangeClass.FindAcademy(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeClass.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeClass.FindMajor(comboBox2.Text, comboBox3);
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeClass.FindClass(comboBox3.Text, comboBox4);
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox4.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller_ChangeClass.Change(textBox1.Text,comboBox4.Text);
            comboBox1.Items.Clear();
            Controller_ChangeClass.FindAcademy(comboBox1);
        }
    }
}
