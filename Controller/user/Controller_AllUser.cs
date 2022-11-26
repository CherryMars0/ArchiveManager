using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace StudentManager
{
    class Controller_AllUser
    {
        public Controller_AllUser()
        {

        }

        public void GetUser(ListView table)
        {
            table.Items.Clear();
            List<Poco_Model.Admin> admins;
            DataSet admin = MysqlUtils.GetHead().Select("admin");
            admins = Poco_Model.ModelManager.LoadAdmin(admin);
            LoadUserInfo(admins,table);
        }

        private void LoadUserInfo(List<Poco_Model.Admin> admins,ListView table)
        {
            for (int i = 0; i < admins.Count; i++)
            {
                ListViewItem row = new ListViewItem();
                row.SubItems[0].Text = Convert.ToString(admins[i].ID);
                row.SubItems.Add(admins[i].AdminName);
                row.SubItems.Add(admins[i].AdminPassword);
                row.SubItems.Add(Permissions_Model.Permissions(admins[i].AdminPermissions));
                table.Items.Add(row);
            }
        }
    }
}
