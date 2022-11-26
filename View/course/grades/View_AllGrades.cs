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
    public partial class View_AllGrades : Form
    {
        Controller_AllGrades Controller_AllGrades;
        public View_AllGrades()
        {
            InitializeComponent();
            Controller_AllGrades = new Controller_AllGrades();
        }

        private void View_AllGrades_Load(object sender, EventArgs e)
        {
            Controller_AllGrades.GetGrade(listView1);
        }
    }
}
