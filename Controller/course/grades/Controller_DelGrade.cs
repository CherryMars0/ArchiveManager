using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    class Controller_DelGrade
    {
        public Controller_DelGrade()
        {

        }

        public void Delete(string studentID,string courseID)
        {
            if (MysqlUtils.GetHead().Select("student","ID", studentID).Tables[0].Rows.Count != 0)
            {
                if (MysqlUtils.GetHead().Select("course","ID", courseID).Tables[0].Rows.Count != 0)
                {
                    if (MysqlUtils.GetHead().Select("grades", "CourseID", courseID, "StudentID", studentID).Tables[0].Rows.Count != 0)
                    {
                        if (MysqlUtils.GetHead().Delete("grades", "courseID", courseID, "studentID", studentID))
                        {
                            MessageBox.Show("删除成功！");
                        }
                        else
                        {
                            MessageBox.Show("删除失败，请联系管理员！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("该学生未取得成绩，请前往成绩添加页面！");
                    }
                }
                else
                {
                    MessageBox.Show("输入的课程号不存在！");
                }
            }
            else
            {
                MessageBox.Show("输入的学号不存在！");
            }
        }
    }
}
