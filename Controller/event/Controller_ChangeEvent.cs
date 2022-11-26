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
     class Controller_ChangeEvent
{
        string AcademyID;
        string DepartmentID;
        string MajorID;
        string ClassID;

        public Controller_ChangeEvent()
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

        public void FindStudent(string Class, ComboBox Student)
        {
            Student.Items.Clear();
            ClassID = MysqlUtils.GetHead().Select("Class", "ClassName", Class, "MajorID", MajorID).Tables[0].Rows[0]["ID"].ToString();
            DataSet Classes = MysqlUtils.GetHead().Select("Student", "ClassID", ClassID);
            for (int i = 0; i < Classes.Tables[0].Rows.Count; i++)
            {
                Student.Items.Add(Classes.Tables[0].Rows[i]["ID"].ToString());
            }
            Student.SelectedIndex = 0;
        }

        public void FindStudentDetails(string StudentID, ComboBox Detail)
        {
            Detail.Items.Clear();
            DataSet DetailID = MysqlUtils.GetHead().Select("event", "StudentID", StudentID);
            if (DetailID.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < DetailID.Tables[0].Rows.Count; i++)
                {
                    Detail.Items.Add(DetailID.Tables[0].Rows[i]["ID"].ToString());
                }
                Detail.SelectedIndex = 0;
            }
        }

        public void GetDetails(string DetailID,TextBox Details)
        {
            Details.Text = string.Empty;
            string detail = MysqlUtils.GetHead().Select("event", "ID", DetailID).Tables[0].Rows[0]["EventDetail"].ToString();
            Details.Text = detail;
        }


        public void Change(string EventID,string Details)
        {
            if (EventID.Length != 0 && Details.Length != 0)
            {
                string props = string.Format(
                    "EventDetail='{0}'",
                    Details
                );
                string condition = string.Format(
                    "ID='{0}'",
                    EventID
                );
                if(MysqlUtils.GetHead().UpdateMixd("event", props, condition))
                {
                    MessageBox.Show("事件修改成功！");
                }
                else
                {
                    MessageBox.Show("事件修改失败，请联系管理员！");
                }
            }
            else
            {
                MessageBox.Show("请选择事件！");
            }
        }
    }
}
