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
    class Controller_AddClass
    {

        string AcademyID;
        string DepartmentID;
        string MajorID;

        public Controller_AddClass() { 
        
        
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
            if (Departments.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < Departments.Tables[0].Rows.Count; i++)
                {
                    Department.Items.Add(Departments.Tables[0].Rows[i]["DepartmentName"].ToString());
                }
                Department.SelectedIndex = 0;
            }
        }

        public void FindMajor(string Department, ComboBox Major)
        {
            Major.Items.Clear();
            DepartmentID = MysqlUtils.GetHead().Select("Department", "DepartmentName", Department, "AcademyID", AcademyID).Tables[0].Rows[0]["ID"].ToString();
            DataSet Majors = MysqlUtils.GetHead().Select("Major", "DepartmentID", DepartmentID);
            if(Majors.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < Majors.Tables[0].Rows.Count; i++)
                {
                    Major.Items.Add(Majors.Tables[0].Rows[i]["MajorName"].ToString());
                }
                Major.SelectedIndex = 0;
            }
        }

        public void FindClass(string Major)
        {
            MajorID = MysqlUtils.GetHead().Select("Major", "MajorName", Major, "DepartmentID", DepartmentID).Tables[0].Rows[0]["ID"].ToString();
        }

        public void Add(string ClassName)
        {
           if(ClassName.Length != 0)
            {
                if (MysqlUtils.GetHead().Select("Class", "ClassName", ClassName).Tables[0].Rows.Count == 0)
                {
                    int ClassCount = Convert.ToInt32(MysqlUtils.GetHead().Count("class", "MajorID", "MajorID", MajorID)) + 1;
                    string classID = MajorID + ClassCount;
                    string key = "ID,MajorID,ClassName";
                    string value = string.Format(
                        "'{0}','{1}','{2}'",
                        classID, MajorID, ClassName
                    );
                    if (MysqlUtils.GetHead().Insert("class", key, value))
                    {
                        MessageBox.Show("班级添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("班级添加失败，请联系管理员！");
                    }
                }
                else
                {
                    MessageBox.Show("该班级已存在！");
                }
                
            }
            else
            {
                MessageBox.Show("请输入班级名称！");
            }
        }
    }
}
