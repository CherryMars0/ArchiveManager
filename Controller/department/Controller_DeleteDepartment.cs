using System.Data;
using System.Windows.Forms;

namespace StudentManager
{
    class Controller_DeleteDepartment
    {
        string AcademyID;
        public Controller_DeleteDepartment()
        {

        }

        public void FindAcademy(ComboBox Academy)
        {
            Academy.Items.Clear();
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

        public void Delete(string academyName,string departmentName)
        {
            string academyID = MysqlUtils.GetHead().Select("academy", "AcademyName", academyName).Tables[0].Rows[0]["ID"].ToString();
            if (MysqlUtils.GetHead().Delete("department", "DepartmentName", departmentName,"AcademyID", academyID))
            {
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }
    }
}
