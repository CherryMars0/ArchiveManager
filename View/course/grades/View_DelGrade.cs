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
    public partial class View_DelGrade : Form
    {
        Controller_DelGrade Controller_DelGrade;
        public View_DelGrade()
        {
            InitializeComponent();
            Controller_DelGrade = new Controller_DelGrade();
        }

        private void View_DelGrade_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_DelGrade.Delete(textBox2.Text,textBox1.Text);
        }
    }
}
