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
    public partial class View_ChangeAcademy : Form
    {
        Controller_ChangeAcademy Controller_ChangeAcademy;
        public View_ChangeAcademy()
        {
            InitializeComponent();
            Controller_ChangeAcademy = new Controller_ChangeAcademy();
        }

        private void View_ChangeAcademy_Load(object sender, EventArgs e)
        {
            Controller_ChangeAcademy.FindAcademy(comboBox2);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Controller_ChangeAcademy.Change(comboBox2.Text,textBox1.Text);
            Controller_ChangeAcademy.FindAcademy(comboBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox2.Text;
        }
    }
}
