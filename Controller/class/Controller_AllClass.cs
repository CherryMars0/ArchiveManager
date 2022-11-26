using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentManager.Poco_Model;

namespace StudentManager
{
    class Controller_AllClass
    {
        public Controller_AllClass()
        {

        }

        public void GetClass(ListView listView1)
        {
            List<Poco_Model.Class> Classes;
            DataSet Class = MysqlUtils.GetHead().Select("class");
            Classes = Poco_Model.ModelManager.LoadClass(Class);
            LoadClassInfo(Classes, listView1);
        }

        private void LoadClassInfo(List<Poco_Model.Class> Classes, ListView listView1)
        {
            for (int i = 0; i < Classes.Count; i++)
            {
                string MajorName = MysqlUtils.GetHead().Select("major", "ID", Convert.ToString(Classes[i].MajorId)).Tables[0].Rows[0]["MajorName"].ToString();
                string DepartmentID = MysqlUtils.GetHead().Select("major", "ID", Convert.ToString(Classes[i].MajorId)).Tables[0].Rows[0]["DepartmentID"].ToString();
                string DepartmentName = MysqlUtils.GetHead().Select("department", "ID", DepartmentID).Tables[0].Rows[0]["DepartmentName"].ToString();
                string AcademyID = MysqlUtils.GetHead().Select("department", "ID", DepartmentID).Tables[0].Rows[0]["AcademyID"].ToString();
                string AcademyName = MysqlUtils.GetHead().Select("academy", "ID", AcademyID).Tables[0].Rows[0]["AcademyName"].ToString();
                ListViewItem row = new ListViewItem();
                row.SubItems[0].Text = Convert.ToString(Classes[i].Id);
                row.SubItems.Add(Classes[i].ClassName);
                row.SubItems.Add(MajorName);
                row.SubItems.Add(DepartmentName);
                row.SubItems.Add(AcademyName);
                listView1.Items.Add(row);
            }
        }
    }
}
