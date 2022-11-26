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
    public partial class View_AllDepartment : Form
    {
        readonly Controller_AllDepartment Controller_AllDepartment;
        public View_AllDepartment()
        {
            InitializeComponent();
            Controller_AllDepartment = new Controller_AllDepartment();
        }

        private void View_AllDepartment_Load(object sender, EventArgs e)
        {
            Controller_AllDepartment.GetDepartment(listView1);
        }
    }
}
