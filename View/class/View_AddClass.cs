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
    public partial class View_AddClass : Form
    {

        Controller_AddClass Controller_AddClass;
        public View_AddClass()
        {
            InitializeComponent();
            Controller_AddClass = new Controller_AddClass();
        }

        private void View_AddClass_Load(object sender, EventArgs e)
        {
            Controller_AddClass.FindAcademy(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_AddClass.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_AddClass.FindMajor(comboBox2.Text, comboBox3);
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            Controller_AddClass.FindClass(comboBox3.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller_AddClass.Add(textBox1.Text);
            comboBox1.Items.Clear();
            Controller_AddClass.FindAcademy(comboBox1);
        }

        
    }
}
