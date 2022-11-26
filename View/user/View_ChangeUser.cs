
using StudentManager.Controller;
using System;
using System.Windows.Forms;
using static StudentManager.Poco_Model;

namespace StudentManager
{
    public partial class View_ChangeUser : Form
    {
        readonly Controller_ChangeUser Controller_ChangeUser;
        int AdminID;
        int AdminPermissions;
        public View_ChangeUser()
        {
            InitializeComponent();
            Controller_ChangeUser = new Controller_ChangeUser();
        }

        private void View_ChangeUser_Load(object sender, EventArgs e)
        {
            Controller_ChangeUser.PullPermissions(comboBox3);
            Controller_ChangeUser.FindPermissons(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           Controller_ChangeUser.FindAdmin(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            AdminID = Controller_ChangeUser.SearchAdmin(comboBox2.Text);
            textBox1.Text = comboBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length >=1 && textBox2.Text.Length >= 3 && textBox3.Text.Length >= 3 && comboBox3.Text.Length >= 0)
            {
                Admin admin = new Admin(AdminID, textBox1.Text, textBox2.Text, AdminPermissions);
                Controller_ChangeUser.Change(admin,textBox3.Text);
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("用户信息不符合规则！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            AdminPermissions = Permissions_Model.ToPermissions(comboBox3.Text);
        }
    }
}
