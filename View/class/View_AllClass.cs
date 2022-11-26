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
    public partial class View_AllClass : Form
    {
        Controller_AllClass Controller_AllClass;
        public View_AllClass()
        {
            InitializeComponent();
            Controller_AllClass = new Controller_AllClass();
        }

        private void View_AllClass_Load(object sender, EventArgs e)
        {
            Controller_AllClass.GetClass(listView1);
        }
    }
}
