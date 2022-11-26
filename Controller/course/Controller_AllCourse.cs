using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    class Controller_AllCourse
    {
        public Controller_AllCourse()
        {
            
        }

        public void GetCourse(ListView listView1)
        {
            List<Poco_Model.Course> Courses;
            DataSet Course = MysqlUtils.GetHead().Select("course");
            Courses = Poco_Model.ModelManager.LoadCourse(Course);
            LoadCourseInfo(Courses, listView1);
        }

        private void LoadCourseInfo(List<Poco_Model.Course> Courses, ListView listView1)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                ListViewItem row = new ListViewItem();
                row.SubItems[0].Text = Convert.ToString(Courses[i].Id);
                row.SubItems.Add(Convert.ToString(Courses[i].CourseName));
                row.SubItems.Add(Convert.ToString(Courses[i].CourseCredits));
                row.SubItems.Add(Convert.ToString(Courses[i].CourseHours));
                row.SubItems.Add(Convert.ToString(Courses[i].Teacher));
                listView1.Items.Add(row);
            }
        }
    }
}
