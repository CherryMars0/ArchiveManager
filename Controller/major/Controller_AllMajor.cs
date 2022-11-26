using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    class Controller_AllMajor
    {
        public Controller_AllMajor()
        {

        }
        public void GetMajor(ListView listView1)
        {
            List<Poco_Model.Major> Majors;
            DataSet Major = MysqlUtils.GetHead().Select("major");
            Majors = Poco_Model.ModelManager.LoadMajor(Major);
            LoadMajorInfo(Majors, listView1);
        }
        private void LoadMajorInfo(List<Poco_Model.Major> Majors, ListView listView1)
        {
            for (int i = 0; i < Majors.Count; i++)
            {
                string DepartmentName = MysqlUtils.GetHead().Select("department", "ID", Convert.ToString(Majors[i].DepartmentId)).Tables[0].Rows[0]["DepartmentName"].ToString();
                string AcademyID = MysqlUtils.GetHead().Select("department", "ID", Convert.ToString(Majors[i].DepartmentId)).Tables[0].Rows[0]["AcademyID"].ToString();
                string AcademyName = MysqlUtils.GetHead().Select("academy", "ID", AcademyID).Tables[0].Rows[0]["AcademyName"].ToString();

                ListViewItem row = new ListViewItem();
                row.SubItems[0].Text = Convert.ToString(Majors[i].Id);
                row.SubItems.Add(Convert.ToString(Majors[i].MajorName));
                row.SubItems.Add(DepartmentName);
                row.SubItems.Add(AcademyName);
                listView1.Items.Add(row);
            }
        }
    }
}
