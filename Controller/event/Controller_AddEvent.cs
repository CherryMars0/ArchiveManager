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
     class Controller_AddEvent
{
        string AcademyID;
        string DepartmentID;
        string MajorID;
        string ClassID;
        public Controller_AddEvent()
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

        public void FindClass(string Major, ComboBox Class)
        {
            Class.Items.Clear();
            MajorID = MysqlUtils.GetHead().Select("Major", "MajorName", Major, "DepartmentID", DepartmentID).Tables[0].Rows[0]["ID"].ToString();
            DataSet Majors = MysqlUtils.GetHead().Select("Class", "MajorID", MajorID);
            if(Majors.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < Majors.Tables[0].Rows.Count; i++)
                {
                    Class.Items.Add(Majors.Tables[0].Rows[i]["ClassName"].ToString());
                }
                Class.SelectedIndex = 0;
            }
        }

        public string FindStudent(string Class, ComboBox Student)
        {
            Student.Items.Clear();
            ClassID = MysqlUtils.GetHead().Select("Class", "ClassName", Class, "MajorID", MajorID).Tables[0].Rows[0]["ID"].ToString();
            DataSet Classes = MysqlUtils.GetHead().Select("Student", "ClassID", ClassID);
            for (int i = 0; i < Classes.Tables[0].Rows.Count; i++)
            {
                Student.Items.Add(Classes.Tables[0].Rows[i]["ID"].ToString());
            }
            return ClassID;
        }

        public void Add(string StudnetID, string Details)
        {
            if(Details.Length != 0 && StudnetID.Length != 0)
            {
                string key = "StudentID,AcademyID,DepartmentID,MajorID,EventDetail";
                string value = string.Format(
                    "'{0}','{1}','{2}','{3}','{4}'",
                    StudnetID,AcademyID,DepartmentID,MajorID,Details
                );
                if(MysqlUtils.GetHead().Insert("event", key, value))
                {
                    MessageBox.Show("事件添加成功！");
                }
                else
                {
                    MessageBox.Show("事件添加失败，请联系管理员！");
                }
            }
            else
            {
                MessageBox.Show("请选择学生并输入详情！");
            }
            
        }
    }
}
