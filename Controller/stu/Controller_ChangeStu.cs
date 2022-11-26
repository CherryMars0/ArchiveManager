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
    class Controller_ChangeStu
    {
        string AcademyID;
        string DepartmentID;
        string MajorID;
        string ClassID;

        public Controller_ChangeStu()
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

        public void Change(Student student)
        {
            string props = string.Format(
                "name='{0}',sex='{1}',address='{2}',IdCart='{3}',tel='{4}',classID='{5}'",
                student.Name,student.Sex,student.Address,student.IdCard,student.Tel,student.ClassId
            );
            string condition = string.Format(
                "ID='{0}'",
                student.Id
            );

            if (MysqlUtils.GetHead().UpdateMixd("student", props, condition))
            {
                MessageBox.Show("修改成功！");
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
        }

        public Student SearchStudent(string studentID)
        {
            DataSet data = MysqlUtils.GetHead().Select("student", "ID", studentID);
            Student student = new Student(data);
            return student;
        }
    }
}
