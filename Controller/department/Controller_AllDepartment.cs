using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    class Controller_AllDepartment
    {
        public Controller_AllDepartment()
        {

        }

        public void GetDepartment(ListView listView1)
        {
            List<Poco_Model.Department> Departments;
            DataSet Department = MysqlUtils.GetHead().Select("department");
            Departments = Poco_Model.ModelManager.LoadDepartment(Department);
            LoadDepartmentInfo(Departments, listView1);
        }
        private void LoadDepartmentInfo(List<Poco_Model.Department> Departments, ListView listView1)
        {
            for (int i = 0; i < Departments.Count; i++)
            {
                string AcademyName = MysqlUtils.GetHead().Select("academy", "ID", Convert.ToString(Departments[i].AcademyId)).Tables[0].Rows[0]["AcademyName"].ToString();
                ListViewItem row = new ListViewItem();
                row.SubItems[0].Text = Convert.ToString(Departments[i].Id);
                row.SubItems.Add(Convert.ToString(Departments[i].DepartmentName));
                row.SubItems.Add(AcademyName);
                listView1.Items.Add(row);
            }
        }
    }
}
