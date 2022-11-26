using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudentManager.Poco_Model;

namespace StudentManager
{
    class Controller_ChangeGrade
    {
        public Controller_ChangeGrade()
        {

        }

        public void Change(string studentID, string courseID, string score)
        {
            if (MysqlUtils.GetHead().Select("student", "ID", studentID).Tables[0].Rows.Count != 0)
            {
                if (MysqlUtils.GetHead().Select("course", "ID", courseID).Tables[0].Rows.Count != 0)
                {
                    if (MysqlUtils.GetHead().Select("grades", "CourseID", courseID,"StudentID", studentID).Tables[0].Rows.Count != 0)
                    {
                        if (MysqlUtils.GetHead().Update("grades", "Score", score, "courseID", courseID, "studentID", studentID))
                        {
                            MessageBox.Show("修改成功！");
                        }
                        else
                        {
                            MessageBox.Show("修改失败，请联系管理员！");
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
