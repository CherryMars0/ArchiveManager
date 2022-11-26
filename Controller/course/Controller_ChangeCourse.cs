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
    class Controller_ChangeCourse
    {
        public Controller_ChangeCourse()
        {

        }

        public void GetTeacher(ComboBox Teacher)
        {
            Teacher.Items.Clear();
            DataSet teacher = MysqlUtils.GetHead().Select("teacher");
            for (int i = 0; i < teacher.Tables[0].Rows.Count; i++)
            {
                Teacher.Items.Add(teacher.Tables[0].Rows[i]["TeacherName"].ToString());
            }
            Teacher.SelectedIndex = 0;
        }

        public void FindCourse(string TeacherName, ComboBox Course)
        {
            Course.Items.Clear();
            DataSet course = MysqlUtils.GetHead().Select("course", "teacher", TeacherName);
            for (int i = 0; i < course.Tables[0].Rows.Count; i++)
            {
                Course.Items.Add(course.Tables[0].Rows[i]["CourseName"].ToString());
            }
            Course.SelectedIndex = 0;
        }

        public void SeaarchCourse(string CourseName, string Teacher,TextBox Name,TextBox Credit,TextBox Hour)
        {
            DataSet Course = MysqlUtils.GetHead().Select("course", "CourseName", CourseName,"Teacher", Teacher);
            Name.Text = Course.Tables[0].Rows[0]["CourseName"].ToString();
            Credit.Text = Course.Tables[0].Rows[0]["CourseCredits"].ToString();
            Hour.Text = Course.Tables[0].Rows[0]["CourseHours"].ToString();
        }

        public void Change(string oldTeacherName ,string oldCourseName,string newTeacherName,string newCourseName,string Credit,string Hour)
        {
            if (newCourseName.Length != 0 && Credit.Length != 0 && Hour.Length != 0)
            {
                
                if (MysqlUtils.GetHead().Select("course", "CourseName", oldCourseName).Tables[0].Rows.Count == 0)
                {
                    string props = string.Format(
                        "Teacher='{0}',CourseName='{1}',CourseCredits='{2}',CourseHours='{3}'",
                        newTeacherName, newCourseName, Credit, Hour
                    );
                    string condition = string.Format(
                        "Teacher='{0}' and CourseName='{1}'",
                        oldTeacherName, oldCourseName
                    );
                    if (MysqlUtils.GetHead().UpdateMixd("course", props, condition))
                    {
                        MessageBox.Show("课程信息修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("课程信息修改失败请联系管理员！");
                    }
                }
                else
                {
                    MessageBox.Show("该教师的课程已存在！");
                }
                
            }
            else
            {
                MessageBox.Show("请输入完整的课程信息！");
            }

        }


    }
}
