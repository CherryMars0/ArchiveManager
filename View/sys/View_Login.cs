using StudentManager.Controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static StudentManager.Poco_Model;

namespace StudentManager
{
    public partial class View_Login : Form
    {
        const int LOGIN_SUCCESS = 1000;
        const int ACCOUNT_ERROR = 1001;
        const int INPUT_EMPTY = 1002;

        readonly Controller_Login login;

        public View_Login()
        {
            InitializeComponent();
            login = new Controller_Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<object> res = login.UserLogin(textBox1,textBox2);
            switch (res[0])
            {
                case LOGIN_SUCCESS:
                    MessageBox.Show("登录成功！");
                    Hide();
                    View_Main View_Main = new View_Main((Admin)res[1]);
                    View_Main.ShowDialog();
                    break;
                case ACCOUNT_ERROR:
                    MessageBox.Show("用户名或密码错误！");
                    break;
                case INPUT_EMPTY:
                    MessageBox.Show("请输入用户名和密码！");
                    break;
            }
        }

        private void View_Login_Load(object sender, EventArgs e)
        {
            MysqlUtils.GetHead().TestConn();
        }
    }
}
