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
    class Controller_AddStu
    {
        string academyID;
        string DepartmentID;
        string majorID;
        public Controller_AddStu()
        {
           
        }

        public void FindAcademy(ComboBox Academy)
        {
            DataSet academy =  MysqlUtils.GetHead().Select("Academy");
            for(int i = 0; i < academy.Tables[0].Rows.Count;i++)
            {
                Academy.Items.Add(academy.Tables[0].Rows[i]["AcademyName"].ToString());
            }
            Academy.SelectedIndex = 0;
        }

        public void FindDepartment(string Academy, ComboBox Department)
        {
            Department.Items.Clear();
            academyID = MysqlUtils.GetHead().Select("Academy", "AcademyName", Academy).Tables[0].Rows[0]["ID"].ToString();
            DataSet Departments = MysqlUtils.GetHead().Select("Department", "AcademyID", academyID);
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
            DepartmentID = MysqlUtils.GetHead().Select("Department", "DepartmentName", Department,"AcademyID", academyID).Tables[0].Rows[0]["ID"].ToString();
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

        public string FindClass(string Major,ComboBox Class)
        {
            Class.Items.Clear();
            majorID = MysqlUtils.GetHead().Select("Major", "MajorName", Major, "DepartmentID", DepartmentID).Tables[0].Rows[0]["ID"].ToString();
            DataSet Majors = MysqlUtils.GetHead().Select("Class", "MajorID", majorID);
            if(Majors.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < Majors.Tables[0].Rows.Count; i++)
                {
                    Class.Items.Add(Majors.Tables[0].Rows[i]["ClassName"].ToString());
                }
                Class.SelectedIndex = 0;
            }
            return majorID;
        }

        public long CreateID(long ClassId)
        {
            string classNumber = MysqlUtils.GetHead().Count("student", "ID", "ClassID", Convert.ToString(ClassId));
            if(Convert.ToInt32(classNumber) <= 100)
            {
                long id = Convert.ToInt64(ClassId + "0" + classNumber);
                return id + 1;
            }
            else
            {
                return 0;
            }
        }

        public long FindClassID(string ClassName)
        {
            long classID = Convert.ToInt64(MysqlUtils.GetHead().Select("Class", "MajorID", majorID, "ClassName", ClassName).Tables[0].Rows[0]["ID"].ToString());
            return classID;
        }

        public void InsertStudent(Student student)
        {
            MessageBox.Show(student.ToString());
            if(MysqlUtils.GetHead().Select("student", "ID", Convert.ToString(student.Id)).Tables[0].Rows.Count == 0)
            {
                bool flag;
                string key = "ID,name,sex,address,IdCart,tel,classID,enrollmentDates";
                string value = string.Format(
                    "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'",
                    student.Id, student.Name, student.Sex, student.Address, student.IdCard, student.Tel, student.ClassId, student.EnrollmentDates
                );
                flag = MysqlUtils.GetHead().Insert("student", key, value);
                if (flag)
                {
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("添加失败,请联系管理员！");
                }
            }
            else
            {
                MessageBox.Show("该学生已存在！");
            }
        }
    }
}
