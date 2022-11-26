using System;
using System.Data;
using System.Windows.Forms;

namespace StudentManager.Controller
{
    class Controller_AddUser
    {
        public Controller_AddUser()
        {

        }

        public void GetPermissions(ComboBox permissions)
        {
            DataSet permission = MysqlUtils.GetHead().Select("admin");
            for (int i = 0; i < permission.Tables[0].Rows.Count; i++)
            {
                permissions.Items.Add(Permissions_Model.Permissions(Convert.ToInt32(permission.Tables[0].Rows[i]["Permissions"].ToString())));
            }
            permissions.SelectedIndex = 0;
        }

        public void Create(string name ,string password ,string permissions)
        {
            if (name.Length != 0 && password.Length != 0)
            {
                if (MysqlUtils.GetHead().Select("admin", "name", name).Tables[0].Rows.Count == 0)
                {
                    string key = "Name,Password,Permissions";
                    string value = string.Format(
                        "'{0}','{1}','{2}'",
                        name, password, Permissions_Model.ToPermissions(permissions)
                    );
                    if (MysqlUtils.GetHead().Insert("admin",key,value))
                    {
                        MessageBox.Show("添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("添加失败，请联系管理员！");
                    }
                }
                else
                {
                    MessageBox.Show("用户名已存在！");
                }
            }
            else
            {
                MessageBox.Show("请输入用户名或密码！");
            }
            
        }
    }
}
