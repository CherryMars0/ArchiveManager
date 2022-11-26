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
    public partial class View_AllEvent : Form
    {
        Controller_AllEvent Controller_AllEvent;
        public View_AllEvent()
        {
            InitializeComponent();
            Controller_AllEvent = new Controller_AllEvent();
        }

        private void View_AllEvent_Load(object sender, EventArgs e)
        {
            Controller_AllEvent.GetEvent(listView1);
        }
    }
}
