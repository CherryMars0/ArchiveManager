using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static StudentManager.Poco_Model;


namespace StudentManager.Controller
{
    public class Controller_AllStu
    {
        string academyID;
        string DepartmentID;
        string majorID;
        string classID;
        public Controller_AllStu()
        {
            
        }

        public void SerachStuInID(ListView listView1,string ID)
        {
            listView1.Items.Clear();
            List<Poco_Model.Student> students;
            DataSet student = MysqlUtils.GetHead().Select("student","ID",ID);
            students = Poco_Model.ModelManager.LoadStudent(student);
            if (students.Count == 0)
            {
                MessageBox.Show("查无此人!");
            }
            else
            {
                LoadStuInfo(students, listView1);
            }
        }

        public string SerachStuInName(ListView listView1, string name)
        {
            listView1.Items.Clear();
            List<Poco_Model.Student> students;
            DataSet student = MysqlUtils.GetHead().Select("student", "name", name);
            students = Poco_Model.ModelManager.LoadStudent(student);
            if (students.Count == 0)
            {
                MessageBox.Show("查无此人!");
                return "0";
            }
            else
            {
                LoadStuInfo(students, listView1);
                return Convert.ToString(students.Count);
            }
        }

        public string SerachStuInClass(ListView listView1, string classID)
        {
            listView1.Items.Clear();
            List<Poco_Model.Student> students;
            DataSet student = MysqlUtils.GetHead().Select("student", "classID", classID);
            students = Poco_Model.ModelManager.LoadStudent(student);
            if (students.Count == 0)
            {
                MessageBox.Show("该班级不存在!");
                return "0";
            }
            else
            {
                LoadStuInfo(students, listView1);
                return Convert.ToString(students.Count);
            }
        }

        public string SerachStuInMajro(ListView listView1)
        {
            listView1.Items.Clear();
            List<Poco_Model.Student> students;
            DataSet student = MysqlUtils.GetHead().Select("student", "ClassID", classID);
            students = Poco_Model.ModelManager.LoadStudent(student);
            if (students.Count == 0)
            {
                return "0";
            }
            else
            {
                LoadStuInfo(students, listView1);
                return Convert.ToString(students.Count);
            }
        }
        private void LoadStuInfo(List<Poco_Model.Student> students, ListView listView1)
        {
            for (int i = 0; i < students.Count; i++)
            {
                ListViewItem row = new ListViewItem();
                row.SubItems[0].Text = Convert.ToString(students[i].Id);
                row.SubItems.Add(students[i].Name);
                row.SubItems.Add(students[i].Sex);
                row.SubItems.Add(students[i].Address);
                row.SubItems.Add(Convert.ToString(students[i].IdCard));
                row.SubItems.Add(Convert.ToString(students[i].Tel));
                row.SubItems.Add(Convert.ToString(students[i].ClassId));
                row.SubItems.Add(Convert.ToString(students[i].EnrollmentDates));
                listView1.Items.Add(row);
            }
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
            academyID = MysqlUtils.GetHead().Select("Academy", "AcademyName", Academy).Tables[0].Rows[0]["ID"].ToString();
            DataSet Departments = MysqlUtils.GetHead().Select("Department", "AcademyID", academyID);
            for (int i = 0; i < Departments.Tables[0].Rows.Count; i++)
            {
                Department.Items.Add(Departments.Tables[0].Rows[i]["DepartmentName"].ToString());
            }
            Department.SelectedIndex = 0;
        }

        public void FindMajor(string Department, ComboBox Major)
        {
            Major.Items.Clear();
            DepartmentID = MysqlUtils.GetHead().Select("Department", "DepartmentName", Department, "AcademyID", academyID).Tables[0].Rows[0]["ID"].ToString();
            DataSet Majors = MysqlUtils.GetHead().Select("Major", "DepartmentID", DepartmentID);
            for (int i = 0; i < Majors.Tables[0].Rows.Count; i++)
            {
                Major.Items.Add(Majors.Tables[0].Rows[i]["MajorName"].ToString());
            }
            Major.SelectedIndex = 0;
        }

        public string FindClass(string Major, ComboBox Class)
        {
            Class.Items.Clear();
            majorID = MysqlUtils.GetHead().Select("Major", "MajorName", Major, "DepartmentID", DepartmentID).Tables[0].Rows[0]["ID"].ToString();
            DataSet Majors = MysqlUtils.GetHead().Select("Class", "MajorID", majorID);
            for (int i = 0; i < Majors.Tables[0].Rows.Count; i++)
            {
                Class.Items.Add(Majors.Tables[0].Rows[i]["ClassName"].ToString());
            }
            Class.SelectedIndex = 0;
            return majorID;
        }

        public void FindClassID(string ClassName)
        {
            classID = MysqlUtils.GetHead().Select("class", "MajorID", majorID, "ClassName", ClassName).Tables[0].Rows[0]["ID"].ToString();
        }
    }
}
