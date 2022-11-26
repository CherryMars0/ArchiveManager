using System.Data;
using System.Windows.Forms;

namespace StudentManager
{
    class Controller_ChangeDepartment
    {
        string AcademyID;
        public Controller_ChangeDepartment()
        {

        }

        public void FindAcademy(ComboBox Academy)
        {
            Academy.Items.Clear();
            DataSet academy = MysqlUtils.GetHead().Select("Academy");
            if(academy.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < academy.Tables[0].Rows.Count; i++)
                {
                    Academy.Items.Add(academy.Tables[0].Rows[i]["AcademyName"].ToString());
                }
                Academy.SelectedIndex = 0;
            }
        }

        public void FindDepartment(string Academy, ComboBox Department)
        {
            Department.Items.Clear();
            AcademyID = MysqlUtils.GetHead().Select("Academy", "AcademyName", Academy).Tables[0].Rows[0]["ID"].ToString();
            DataSet Departments = MysqlUtils.GetHead().Select("Department", "AcademyID", AcademyID);
            if(Departments.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < Departments.Tables[0].Rows.Count; i++)
                {
                    Department.Items.Add(Departments.Tables[0].Rows[i]["DepartmentName"].ToString());
                }
                Department.SelectedIndex = 0;
            }
        }

        public void Change(string oldDepartmentName,string newDepartmentName)
        {
            if (MysqlUtils.GetHead().Select("department", "DepartmentName", newDepartmentName).Tables[0].Rows.Count == 0)
            {
                if(MysqlUtils.GetHead().Update("department", "DepartmentName", newDepartmentName, "DepartmentName", oldDepartmentName))
                {
                    MessageBox.Show("专业名修改成功！");
                }
                else
                {
                    MessageBox.Show("专业名修改失败，请联系管理员！");
                }
            }
            else
            {
                MessageBox.Show("该专业已存在！");
            }
        }
    }
}
