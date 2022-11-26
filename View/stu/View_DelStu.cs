using StudentManager;
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
    public partial class View_DelStu : Form
    {
        Controller_DeleteStu Controller_DeleteStu;
        public View_DelStu()
        {
            InitializeComponent();
            Controller_DeleteStu = new Controller_DeleteStu();
        }

        private void View_DelStu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_DeleteStu.delete(textBox1.Text);
        }
    }
}
