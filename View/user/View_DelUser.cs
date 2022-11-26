using System;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class View_DelUser : Form
    {
        readonly Controller_DeleteUser Controller_DeleteUser;
        public View_DelUser()
        {
            InitializeComponent();
            Controller_DeleteUser = new Controller_DeleteUser();
        }

        private void View_DelUser_Load(object sender, EventArgs e)
        {
            Controller_DeleteUser.GetUser(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           Controller_DeleteUser.GerUserID(comboBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_DeleteUser.DelUser(textBox1.Text);
            comboBox1.Items.Clear();
            Controller_DeleteUser.GetUser(comboBox1);
            textBox1.Text = string.Empty;
        }
    }
}
