using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudentManager.Poco_Model;

namespace StudentManager.Controller
{
    class Controller_ChangeUser
    {
        public Controller_ChangeUser()
        {

        }

        public void FindPermissons(ComboBox permissions)
        {
            DataSet permission = MysqlUtils.GetHead().Select("admin");
            for (int i = 0; i < permission.Tables[0].Rows.Count; i++)
            {
                permissions.Items.Add(Permissions_Model.Permissions(Convert.ToInt32(permission.Tables[0].Rows[i]["Permissions"].ToString())));
            }
            permissions.SelectedIndex = 0;
        }

        public void FindAdmin(string permissions,ComboBox admin)
        {
            admin.Items.Clear();
            DataSet Admins = MysqlUtils.GetHead().Select("admin", "Permissions", Convert.ToString(Permissions_Model.ToPermissions(permissions)));
            for (int i = 0; i < Admins.Tables[0].Rows.Count; i++)
            {
                admin.Items.Add(Admins.Tables[0].Rows[i]["Name"].ToString());
            }
            admin.SelectedIndex = 0;
        }

        public int SearchAdmin(string adminName)
        {
            string ID = MysqlUtils.GetHead().Select("admin", "name", adminName).Tables[0].Rows[0]["ID"].ToString();
            return Convert.ToInt32(ID);
        }

        public void PullPermissions(ComboBox permissions)
        {
            DataSet permission = MysqlUtils.GetHead().Select("admin");
            for (int i = 0; i < permission.Tables[0].Rows.Count; i++)
            {
                permissions.Items.Add(Permissions_Model.Permissions(Convert.ToInt32(permission.Tables[0].Rows[i]["Permissions"].ToString())));
            }
            permissions.SelectedIndex = 0;
        }

        public void Change(Admin admin,string oldPassword)
        {

            string password = MysqlUtils.GetHead().Select("admin", "ID", Convert.ToString(admin.ID)).Tables[0].Rows[0]["Password"].ToString();
            if(oldPassword == password)
            {
                MessageBox.Show(admin.ToString());
                string props = string.Format(
                "Name='{0}',Password='{1}',Permissions='{2}'",
                admin.AdminName,admin.AdminPassword,admin.AdminPermissions
                );
                string condition = "ID='" + admin.ID + "'";
                if(MysqlUtils.GetHead().UpdateMixd("admin", props, condition))
                {
                    MessageBox.Show("修改成功！");
                }
            }
            else
            {
                MessageBox.Show("旧密码错误！");
            }
            
        }
    }
}
