using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudentManager.Poco_Model;

namespace StudentManager.Controller.major
{
     class Controller_ChangeMajor
    {
        string AcademyID;
        string DepartmentID;
        string MajorID;
        public Controller_ChangeMajor()
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
            for (int i = 0; i < Departments.Tables[0].Rows.Count; i++)
            {
                Department.Items.Add(Departments.Tables[0].Rows[i]["DepartmentName"].ToString());
            }
            Department.SelectedIndex = 0;
        }

        public void FindMajor(string Department, ComboBox Major)
        {
            Major.Items.Clear();
            DepartmentID = MysqlUtils.GetHead().Select("Department", "DepartmentName", Department, "AcademyID", AcademyID).Tables[0].Rows[0]["ID"].ToString();
            DataSet Majors = MysqlUtils.GetHead().Select("Major", "DepartmentID", DepartmentID);
            for (int i = 0; i < Majors.Tables[0].Rows.Count; i++)
            {
                Major.Items.Add(Majors.Tables[0].Rows[i]["MajorName"].ToString());
            }
            Major.SelectedIndex = 0;
        }

        public void FindClass(string Major, ComboBox Class)
        {
            Class.Items.Clear();
            MajorID = MysqlUtils.GetHead().Select("Major", "MajorName", Major, "DepartmentID", DepartmentID).Tables[0].Rows[0]["ID"].ToString();
            DataSet Majors = MysqlUtils.GetHead().Select("Class", "MajorID", MajorID);
            for (int i = 0; i < Majors.Tables[0].Rows.Count; i++)
            {
                Class.Items.Add(Majors.Tables[0].Rows[i]["ClassName"].ToString());
            }
            Class.SelectedIndex = 0;
        }

        public void Change(string oldMajorName,string newMajorName)
        {
            if(newMajorName.Length != 0)
            {
                if (MysqlUtils.GetHead().Select("major", "MajorName", newMajorName).Tables[0].Rows.Count == 0)
                {
                    if(MysqlUtils.GetHead().Update("Major", "MajorName", newMajorName, "MajorName", oldMajorName))
                    {
                        MessageBox.Show("专业名修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("专业名修改失败，请联系管理员！");
                    }
                }
                else
                {
                    MessageBox.Show("专业已存在！");
                }
            }
            else
            {
                MessageBox.Show("专业名称不能为空！");
            }
        }
    }
}
