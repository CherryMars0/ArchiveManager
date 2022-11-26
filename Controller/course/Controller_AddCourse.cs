using System.Data;
using System.Windows.Forms;

namespace StudentManager
{
    class Controller_AddCourse
    {
        public Controller_AddCourse()
        {

        }
        public void GetTeacher(ComboBox Teacher)
        {
            DataSet teacher = MysqlUtils.GetHead().Select("teacher");
            for (int i = 0; i < teacher.Tables[0].Rows.Count; i++)
            {
                Teacher.Items.Add(teacher.Tables[0].Rows[i]["TeacherName"].ToString());
            }
            Teacher.SelectedIndex = 0;
        }

        public void Add(string ID, string name, string hours, string credits, string teacher)
        {
            if (ID.Length != 0 && name.Length != 0 && hours.Length != 0 && credits.Length != 0 && teacher.Length != 0)
            {
                string keys = "ID,CourseName,CourseCredits,CourseHours,Teacher";
                string value = string.Format(
                    "'{0}','{1}','{2}','{3}','{4}'",
                    ID,name, credits, hours, teacher
                );
                if (MysqlUtils.GetHead().Insert("course",keys,value))
                {
                    MessageBox.Show("课程添加成功！");
                }
                else
                {
                    MessageBox.Show("课程添加失败！");
                }
            }
            else
            {
                MessageBox.Show("请填写完整的课程信息！");
            }
        }
    }
}
