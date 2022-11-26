using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    class Controller_DeleteStu
    {
        public Controller_DeleteStu()
        {

        }

        public void delete(string studentID)
        {
            if (MysqlUtils.GetHead().Select("student", "ID", studentID).Tables[0].Rows.Count != 0)
            {
                try
                {
                    MysqlUtils.GetHead().Delete("student", "ID", studentID);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    MessageBox.Show("删除成功！");
                }
            }
            else
            {
                MessageBox.Show("该学生不存在！");
            }
        }
    }
}
