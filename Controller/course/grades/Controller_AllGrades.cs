using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    class Controller_AllGrades
    {
        public Controller_AllGrades()
        {

        }

        public void GetGrade(ListView listView1)
        {
            List<Poco_Model.Grades> Grades;
            DataSet Grade = MysqlUtils.GetHead().Select("grades");
            Grades = Poco_Model.ModelManager.LoadGrade(Grade);
            LoadGradeInfo(Grades, listView1);
        }

        private void LoadGradeInfo(List<Poco_Model.Grades> Grades, ListView listView1)
        {
            for (int i = 0; i < Grades.Count; i++)
            {
                string CourseName = MysqlUtils.GetHead().Select("course", "ID", Convert.ToString(Grades[i].CourseId)).Tables[0].Rows[0]["CourseName"].ToString();
                string StudentName = MysqlUtils.GetHead().Select("student", "ID", Convert.ToString(Grades[i].StudentId)).Tables[0].Rows[0]["name"].ToString();
                ListViewItem row = new ListViewItem();
                row.SubItems[0].Text = Convert.ToString(Grades[i].CourseId);
                row.SubItems.Add(CourseName);
                row.SubItems.Add(Convert.ToString(Grades[i].StudentId));
                row.SubItems.Add(StudentName);
                row.SubItems.Add(Convert.ToString(Grades[i].Score));
                listView1.Items.Add(row);
            }
        }
    }
}
