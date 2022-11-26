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
     class Controller_AddDepartment
    {
        string AcademyID;
        public Controller_AddDepartment()
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

        public void GetAademyID(string AcademyName)
        {
            AcademyID = MysqlUtils.GetHead().Select("academy", "AcademyName", AcademyName).Tables[0].Rows[0]["ID"].ToString();
        }

        public void Add(string departmentName)
        {
           if(departmentName.Length != 0)
            {
                if (MysqlUtils.GetHead().Select("department", "DepartmentName", departmentName).Tables[0].Rows.Count == 0)
                {
                    int DepartmentCount = Convert.ToInt32(MysqlUtils.GetHead().Count("department", "AcademyID", "AcademyID", AcademyID)) + 1;
                    string DepartmentID = AcademyID + DepartmentCount;
                    string key = "ID,DepartmentName,AcademyID";
                    string value = string.Format(
                        "'{0}','{1}','{2}'",
                        DepartmentID, departmentName, AcademyID
                    );
                    if (MysqlUtils.GetHead().Insert("department", key, value))
                    {
                        MessageBox.Show("系部添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("系部添加失败，请联系管理员！");
                    }
                }
                else
                {
                    MessageBox.Show("该系部已存在！");
                }
            }
            else
            {
                MessageBox.Show("请输入系部名称！");   
            }
        }
    }
}
