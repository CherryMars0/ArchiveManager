using System;
using System.Data;
using System.Windows.Forms;

namespace StudentManager.Controller.major
{
    class Controller_AddMajor
    {
        string AcademyID;
        string DepartmentID;
        public Controller_AddMajor()
        {

        }

        public void FindAcademy(ComboBox Academy)
        {
            DataSet academy = MysqlUtils.GetHead().Select("Academy");
            for (int i = 0; i < academy.Tables[0].Rows.Count; i++)
            {
                Academy.Items.Add(academy.Tables[0].Rows[i]["AcademyName"].ToString());
            }
            Academy.SelectedIndex = 0;
        }

        public void FindDepartment(string Academy, ComboBox Department)
        {
            Department.Items.Clear();
            AcademyID = MysqlUtils.GetHead().Select("Academy", "AcademyName", Academy).Tables[0].Rows[0]["ID"].ToString();
            DataSet Departments = MysqlUtils.GetHead().Select("Department", "AcademyID", AcademyID);
            if(Departments.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < Departments.Tables[0].Rows.Count; i++)
                {
                    Department.Items.Add(Departments.Tables[0].Rows[i]["DepartmentName"].ToString());
                }
                Department.SelectedIndex = 0;
            }
        }

        public void FindMajor(string Department)
        {
            DepartmentID = MysqlUtils.GetHead().Select("Department", "DepartmentName", Department, "AcademyID", AcademyID).Tables[0].Rows[0]["ID"].ToString();
        }


        public void Add(string majorName)
        {
            if(majorName.Length != 0)
            {
                if(MysqlUtils.GetHead().Select("Major", "MajorName", majorName).Tables[0].Rows.Count == 0)
                {
                    int MajorCount = Convert.ToInt32(MysqlUtils.GetHead().Count("Major", "DepartmentID", "DepartmentID", DepartmentID)) + 2;
                    string MajorID = DepartmentID + MajorCount;
                    string key = "ID,MajorName,DepartmentID";
                    string value = string.Format(
                        "'{0}','{1}','{2}'",
                        MajorID, majorName, DepartmentID
                    );
                    if(MysqlUtils.GetHead().Insert("major", key, value))
                    {
                        MessageBox.Show("专业添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("专业添加失败，请联系管理员！");
                    }
                }
                else
                {
                    MessageBox.Show("专业已存在！");
                }
                
            }
            else
            {
                MessageBox.Show("请输入专业名称！");
            }
        }
    }
}
