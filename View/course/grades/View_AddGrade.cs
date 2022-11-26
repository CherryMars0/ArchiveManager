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
    public partial class View_AddGrade : Form
    {
        Controller_AddGrade Controller_AddGrade;
        public View_AddGrade()
        {
            InitializeComponent();
            Controller_AddGrade = new Controller_AddGrade();
        }

        private void View_AddGrade_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_AddGrade.addGrade(textBox1.Text, textBox2.Text, textBox3.Text);
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
    }
}
