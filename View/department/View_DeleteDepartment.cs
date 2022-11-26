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
    public partial class View_DeleteDepartment : Form
    {
        Controller_DeleteDepartment Controller_DeleteDepartment;
        public View_DeleteDepartment()
        {
            InitializeComponent();
            Controller_DeleteDepartment = new Controller_DeleteDepartment();
        }

        private void View_DeleteDepartment_Load(object sender, EventArgs e)
        {
            Controller_DeleteDepartment.FindAcademy(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_DeleteDepartment.Delete(comboBox1.Text,comboBox2.Text);
            Controller_DeleteDepartment.FindAcademy(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_DeleteDepartment.FindDepartment(comboBox1.Text, comboBox2);
            
        }
    }
}
