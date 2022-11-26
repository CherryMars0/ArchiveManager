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
    public partial class View_AddAcademy : Form
    {
        Controller_AddAcademy Controller_AddAcademy;
        public View_AddAcademy()
        {
            InitializeComponent();
            Controller_AddAcademy = new Controller_AddAcademy();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller_AddAcademy.Add(textBox1.Text);
            textBox1.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
