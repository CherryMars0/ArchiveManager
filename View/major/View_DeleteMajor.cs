using StudentManager.Controller.major;
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
    public partial class View_DeleteMajor : Form
    {
        Controller_DeleteMajor Controller_DeleteMajor;
        public View_DeleteMajor()
        {
            InitializeComponent();
            Controller_DeleteMajor = new Controller_DeleteMajor();
        }

        private void View_DeleteMajor_Load(object sender, EventArgs e)
        {
            Controller_DeleteMajor.FindAcademy(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_DeleteMajor.FindDepartment(comboBox1.Text, comboBox2);

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_DeleteMajor.FindMajor(comboBox2.Text, comboBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_DeleteMajor.Delete(comboBox1.Text,comboBox2.Text,comboBox3.Text);
            comboBox1.Items.Clear();
            Controller_DeleteMajor.FindAcademy(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
