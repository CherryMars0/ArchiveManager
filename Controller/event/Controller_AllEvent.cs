using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    class Controller_AllEvent
    {
        public Controller_AllEvent()
        {

        }

        public void GetEvent(ListView listView1)
        {
            List<Poco_Model.Event> Events;
            DataSet Event = MysqlUtils.GetHead().Select("event");
            Events = Poco_Model.ModelManager.LoadEvent(Event);
            LoadEventInfo(Events, listView1);
        }

        private void LoadEventInfo(List<Poco_Model.Event> Events, ListView listView1)
        {
            for (int i = 0; i < Events.Count; i++)
            {
                string StudentName = MysqlUtils.GetHead().Select("student", "ID", Convert.ToString(Events[i].StudentId)).Tables[0].Rows[0]["name"].ToString();
                string AcademyName = MysqlUtils.GetHead().Select("academy", "ID", Convert.ToString(Events[i].AcademyId)).Tables[0].Rows[0]["AcademyName"].ToString();
                string DepartmentName = MysqlUtils.GetHead().Select("department", "ID", Convert.ToString(Events[i].DepartmentId)).Tables[0].Rows[0]["DepartmentName"].ToString();
                string MajorName = MysqlUtils.GetHead().Select("major", "ID", Convert.ToString(Events[i].MajorId)).Tables[0].Rows[0]["MajorName"].ToString();
                string classID = MysqlUtils.GetHead().Select("student", "ID", Convert.ToString(Events[i].StudentId)).Tables[0].Rows[0]["classID"].ToString();
                string className = MysqlUtils.GetHead().Select("class", "ID", classID).Tables[0].Rows[0]["className"].ToString();

                ListViewItem row = new ListViewItem();
                row.SubItems[0].Text = Convert.ToString(Events[i].Id);
                row.SubItems.Add(Convert.ToString(Events[i].StudentId));
                row.SubItems.Add(StudentName);
                row.SubItems.Add(className);
                row.SubItems.Add(MajorName);
                row.SubItems.Add(DepartmentName);
                row.SubItems.Add(AcademyName);
                row.SubItems.Add(Events[i].EventDetail);
                listView1.Items.Add(row);
            }
        }
    }
}
