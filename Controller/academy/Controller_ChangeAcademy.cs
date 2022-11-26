using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
     class Controller_ChangeAcademy
    {
        public Controller_ChangeAcademy()
        {

        }

        public void FindAcademy(ComboBox Academy)
        {
            Academy.Items.Clear();
            DataSet academy = MysqlUtils.GetHead().Select("Academy");
            for (int i = 0; i < academy.Tables[0].Rows.Count; i++)
            {
                Academy.Items.Add(academy.Tables[0].Rows[i]["AcademyName"].ToString());
            }
            Academy.SelectedIndex = 0;
        }

        public void Change(string oldAcademyName, string newAcademyName)
        {
            if(newAcademyName.Length != 0)
            {
                if (MysqlUtils.GetHead().Select("academy","AcademyName", newAcademyName).Tables[0].Rows.Count == 0)
                {
                    if(MysqlUtils.GetHead().Update("academy", "AcademyName", newAcademyName, "AcademyName", oldAcademyName))
                    {
                        MessageBox.Show("学院修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("学院修改失败，请联系管理员！");
                    }
                }
                else
                {
                    MessageBox.Show("该学院名已存在！");
                }
            }
            else
            {
                MessageBox.Show("请输入学院名称！");
            }
        }
    }
}
