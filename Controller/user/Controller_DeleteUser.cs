using System;
using System.Data;
using System.Windows.Forms;
using static StudentManager.Poco_Model;


namespace StudentManager
{
    class Controller_DeleteUser
    {
        Admin admin;
        public Controller_DeleteUser()
        {

        }

        public void GetUser(ComboBox Admin)
        {
            DataSet data = MysqlUtils.GetHead().Select("admin");
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                Admin.Items.Add(data.Tables[0].Rows[i]["Name"].ToString());
            }
            Admin.SelectedIndex = 0;
        }
        public void GerUserID(string AdminName)
        {
            admin = new Admin(MysqlUtils.GetHead().Select("admin","Name", AdminName));
        }
        public void DelUser(string password)
        {
            if (admin.AdminPassword == password)
            {
                if(MysqlUtils.GetHead().Delete("admin", "ID", Convert.ToString(admin.ID)))
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败，请联系管理员！");
                }
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }
    }
}
