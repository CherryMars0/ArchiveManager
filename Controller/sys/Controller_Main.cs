using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static StudentManager.Poco_Model;

namespace StudentManager.Controller
{
    public class Controller_Main
    {
        readonly View_Main View_Main;
        Admin admin;
        public Controller_Main(View_Main main)
        {
            View_Main = main;
        }

        public void Checking(Admin admin)
        {
            this.admin = admin;
            switch (admin.AdminPermissions)
            {
                case Permissions_Model.SUPER_ADMIN:
                    SuperLogin(View_Main);
                    break;
                case Permissions_Model.CLASS_ADMIN:
                    ClassLogin(View_Main);
                    break;
                case Permissions_Model.MAJOR_ADMIN:
                    MajorLogin(View_Main);
                    break;
                case Permissions_Model.DEPARTMENT_ADMIN:
                    DepartmentLogin(View_Main);
                    break;
                case Permissions_Model.ACADEMY_ADMIN:
                   AcademyLogin(View_Main);
                    break;
                case Permissions_Model.COURSE_ADMIN:
                    CourseLogin(View_Main);
                    break;
                case Permissions_Model.EVENT_ADMIN:
                    EventLogin(View_Main);
                    break;
                case Permissions_Model.STUDENT_ADMIN:
                    StudentLogin(View_Main);
                    break;
            }
        }

        private void EventLogin(View_Main main)
        {
            main.toolStripStatusLabel1.Text = Permissions_Model.Permissions(admin.AdminPermissions);
            main.奖惩管理ToolStripMenuItem.Visible = true;
        }

        private void StudentLogin(View_Main main)
        {
            main.toolStripStatusLabel1.Text = Permissions_Model.Permissions(admin.AdminPermissions);
            main.学生管理ToolStripMenuItem.Visible = true;
        }

        private void ClassLogin(View_Main main)
        {
            main.toolStripStatusLabel1.Text = Permissions_Model.Permissions(admin.AdminPermissions);
            main.学生管理ToolStripMenuItem.Visible = true;
            main.班级管理ToolStripMenuItem.Visible = true;

        }
        private void CourseLogin(View_Main main)
        {
            main.toolStripStatusLabel1.Text = Permissions_Model.Permissions(admin.AdminPermissions);
            main.学生管理ToolStripMenuItem.Visible = true;
            main.班级管理ToolStripMenuItem.Visible = true;
            main.课程管理ToolStripMenuItem.Visible = true;
        }

        private void MajorLogin(View_Main main)
        {
            main.toolStripStatusLabel1.Text = Permissions_Model.Permissions(admin.AdminPermissions);
            main.学生管理ToolStripMenuItem.Visible = true;
            main.班级管理ToolStripMenuItem.Visible = true;
            main.课程管理ToolStripMenuItem.Visible = true;
            main.专业管理ToolStripMenuItem.Visible = true;
        }

        private void DepartmentLogin(View_Main main)
        {
            main.toolStripStatusLabel1.Text = Permissions_Model.Permissions(admin.AdminPermissions);
            main.学生管理ToolStripMenuItem.Visible = true;
            main.班级管理ToolStripMenuItem.Visible = true;
            main.课程管理ToolStripMenuItem.Visible = true;
            main.专业管理ToolStripMenuItem.Visible = true;
            main.系部管理ToolStripMenuItem.Visible = true;
        }

        private void AcademyLogin(View_Main main)
        {
            main.toolStripStatusLabel1.Text = Permissions_Model.Permissions(admin.AdminPermissions);
            main.学生管理ToolStripMenuItem.Visible = true;
            main.班级管理ToolStripMenuItem.Visible = true;
            main.课程管理ToolStripMenuItem.Visible = true;
            main.专业管理ToolStripMenuItem.Visible = true;
            main.系部管理ToolStripMenuItem.Visible = true;
            main.学院管理ToolStripMenuItem.Visible = true;
        }

        private void SuperLogin(View_Main main)
        {
            main.toolStripStatusLabel1.Text = Permissions_Model.Permissions(admin.AdminPermissions);
            main.学生管理ToolStripMenuItem.Visible = true;
            main.班级管理ToolStripMenuItem.Visible = true;
            main.课程管理ToolStripMenuItem.Visible = true;
            main.专业管理ToolStripMenuItem.Visible = true;
            main.系部管理ToolStripMenuItem.Visible = true;
            main.学院管理ToolStripMenuItem.Visible = true;
            main.奖惩管理ToolStripMenuItem.Visible = true;
            main.用户管理ToolStripMenuItem1.Visible = true;
        }

        public void MainRender(Label totalStu, Label totalAcademy, Label totalDepartment, Label totalMajor, Label totalClass, Label totalAdmin, Label totalHith, Label totalLow,Label totalNone ,Chart sexCount,Chart pepCount)
        {
            totalStu.Text = "系统中共有在籍学生 " + Overview() + "人";
            totalAcademy.Text = "";
            totalDepartment.Text = "";
            totalMajor.Text = "";
            totalClass.Text = "";
            totalAdmin.Text = "系统中共登记管理员 " + MysqlUtils.GetHead().Count("admin", "*") + "个";
            totalHith.Text = "高级管理员1个";
            totalLow.Text = "普通管理员8个";
            totalNone.Text = "未分配权限管理员0个";
            List<string> x1Data = new List<string>() { "男", "女"};
            List<int> y1Data = new List<int>() {Convert.ToInt32(MysqlUtils.GetHead().Count("student", "*", "sex", "男")), Convert.ToInt32(MysqlUtils.GetHead().Count("student", "*", "sex", "女"))};
            sexCount.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            sexCount.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            sexCount.Series[0].Points.DataBindXY(x1Data, y1Data);
        }
        private string Overview()
        {
            return MysqlUtils.GetHead().Count("student", "ID");
        }
    }
}
