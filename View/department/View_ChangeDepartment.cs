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
    public partial class View_ChangeDepartment : Form
    {
        Controller_ChangeDepartment Controller_ChangeDepartment;
        public View_ChangeDepartment()
        {
            InitializeComponent();
            Controller_ChangeDepartment = new Controller_ChangeDepartment();
        }

        private void View_ChangeDepartment_Load(object sender, EventArgs e)
        {
            Controller_ChangeDepartment.FindAcademy(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller_ChangeDepartment.Change(comboBox2.Text,textBox1.Text);
            Controller_ChangeDepartment.FindAcademy(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeDepartment.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text =comboBox2.Text;
        }
    }
}
