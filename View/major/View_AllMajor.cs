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
    public partial class View_AllMajor : Form
    {
        Controller_AllMajor Controller_AllMajor;
        public View_AllMajor()
        {
            InitializeComponent();
            Controller_AllMajor = new Controller_AllMajor();
        }

        private void View_AllMajor_Load(object sender, EventArgs e)
        {
            Controller_AllMajor.GetMajor(listView1);
        }
    }
}
