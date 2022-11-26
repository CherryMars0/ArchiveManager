using StudentManager.Controller;
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
    public partial class View_AllAcademy : Form
    {
        Controller_AllAcademy Controller_AllAcademy;
        public View_AllAcademy()
        {
            InitializeComponent();
            Controller_AllAcademy = new Controller_AllAcademy();
        }

        private void View_AllAcademy_Load(object sender, EventArgs e)
        {
            Controller_AllAcademy.GetAcademy(listView1);
        }
    }
}
