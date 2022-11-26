using System.Data;
using System.Windows.Forms;
using static StudentManager.Poco_Model;

namespace StudentManager
{
    class Controller_DeleteCourse
    {
        public Controller_DeleteCourse()
        {

        }

        public void GetCourse(ComboBox Course)
        {
            DataSet course = MysqlUtils.GetHead().Select("course");
            for (int i = 0; i < course.Tables[0].Rows.Count; i++)
            {
                Course.Items.Add(course.Tables[0].Rows[i]["CourseName"].ToString());
            }
            Course.SelectedIndex = 0;
        }

        public void SearchTeacher(string CourseName,ComboBox Teacher)
        {
            Teacher.Items.Clear();
            DataSet teacher = MysqlUtils.GetHead().Select("course","CourseName", CourseName);
            for (int i = 0; i < teacher.Tables[0].Rows.Count; i++)
            {
                Teacher.Items.Add(teacher.Tables[0].Rows[i]["Teacher"].ToString());
            }
            Teacher.SelectedIndex = 0;
        }

        public void Delete(string Course,string Teacher)
        {
           if(Course.Length != 0 && Teacher.Length != 0)
            {
                if (MysqlUtils.GetHead().Delete("course", "CourseName", Course, "Teacher", Teacher))
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
            else
            {
                MessageBox.Show("请选择课程与教师！");
            }
        }
    }
}
