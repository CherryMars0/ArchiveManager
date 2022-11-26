using System;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class View_AllUser : Form
    {
        readonly Controller_AllUser Controller_AllUser;
        public View_AllUser()
        {
            InitializeComponent();
            Controller_AllUser = new Controller_AllUser();
        }

        private void View_AllUser_Load(object sender, EventArgs e)
        {
            Controller_AllUser.GetUser(listView1);
        }
    }
}
