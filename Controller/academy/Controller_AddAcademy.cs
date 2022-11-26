using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudentManager.Poco_Model;

namespace StudentManager
{
     class Controller_AddAcademy
    {
        public Controller_AddAcademy()
        {

        }

        public void Add(string AcademyName)
        {
            if (AcademyName.Length != 0)
            {
                if (MysqlUtils.GetHead().Select("academy", "AcademyName", AcademyName).Tables[0].Rows.Count == 0)
                {
                    int AcademyCount = Convert.ToInt32(MysqlUtils.GetHead().Count("academy", "*")) + 1;
                    string parentUniversityCode = "201920";
                    string AcademyID = parentUniversityCode + AcademyCount;
                    string key = "ID,AcademyName";
                    string value = string.Format(
                        "'{0}','{1}'",
                        AcademyID, AcademyName
                    );
                    if (MysqlUtils.GetHead().Insert("academy", key, value))
                    {
                        MessageBox.Show("学院添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("学院添加失败，请联系管理员！");
                    }
                }
                else
                {
                    MessageBox.Show("该学院已存在！");
                }
            }
            else
            {
                MessageBox.Show("请输入学院名称！");
            }
        }
    }
}
