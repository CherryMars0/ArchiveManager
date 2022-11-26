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
    public partial class View_DeleteAcademy : Form
    {
        Controller_DeleteAcademy Controller_DeleteAcademy;
        public View_DeleteAcademy()
        {
            InitializeComponent();
            Controller_DeleteAcademy = new Controller_DeleteAcademy();
        }

        private void View_DeleteAcademy_Load(object sender, EventArgs e)
        {
            Controller_DeleteAcademy.FindAcademy(comboBox1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Controller_DeleteAcademy.Delete(comboBox1.Text);
            Controller_DeleteAcademy.FindAcademy(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
