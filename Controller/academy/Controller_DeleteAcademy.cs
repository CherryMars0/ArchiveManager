using System.Data;
using System.Windows.Forms;

namespace StudentManager
{
    class Controller_DeleteAcademy
    {
        public Controller_DeleteAcademy()
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

        public void Delete(string AcademyName)
        {
            if (MysqlUtils.GetHead().Delete("academy","AcademyName", AcademyName))
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
