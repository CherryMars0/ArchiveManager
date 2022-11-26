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
    public partial class View_AddUser : Form
    {
        readonly Controller_AddUser Controller_AddUser;
        public View_AddUser()
        {
            InitializeComponent();
            Controller_AddUser = new Controller_AddUser();
        }

        private void View_AddUser_Load(object sender, EventArgs e)
        {
            Controller_AddUser.GetPermissions(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_AddUser.Create(textBox1.Text,textBox2.Text,comboBox1.Text);
            textBox1.Text= string.Empty;
            textBox2.Text= string.Empty;
        }
    }
}
