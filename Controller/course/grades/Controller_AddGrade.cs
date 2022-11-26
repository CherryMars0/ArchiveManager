using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    class Controller_AddGrade
    {
       public  Controller_AddGrade()
       {

       }

        public void addGrade(string studentId , string courseId , string score)
        {
            if(MysqlUtils.GetHead().Select("student","ID", studentId).Tables[0].Rows.Count != 0)
            {
                if (MysqlUtils.GetHead().Select("course", "ID", courseId).Tables[0].Rows.Count != 0)
                {
                    if(MysqlUtils.GetHead().Select("grades", "CourseID", courseId, "StudentID", studentId).Tables[0].Rows.Count == 0)
                    {
                        string key = "CourseID,StudentID,Score";
                        string value = string.Format(
                            "'{0}','{1}','{2}'",
                            courseId, studentId, score
                        );
                        if(MysqlUtils.GetHead().Insert("grades", key, value)){
                            MessageBox.Show("录入成功！");
                        }
                        else
                        {
                            MessageBox.Show("录入失败，请联系管理员！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("该课程成绩已经被录入，如需修改请到修改成绩页面！");
                    }
                }
                else
                {
                    MessageBox.Show("该课程不存在，请检查课程是否输入正确！");
                }
            }
            else
            {
                MessageBox.Show("该学生不存在，请检查学号是否输入正确！");
            }
        }
    }
}
