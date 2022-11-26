using StudentManager.Controller;
using StudentManager.View;
using System;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class View_Main : Form
    {
        readonly Poco_Model.Admin admin;
        readonly Controller_Main main;

        public View_Main(Poco_Model.Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            main = new Controller_Main(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            main.Checking(admin);
            MysqlUtils.GetHead().TestConn();
            main.MainRender(label1,label4,label5,label6,label7,label9,label10,label11,label12,chart1,chart6);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MysqlUtils.GetHead().SavePoint(admin.AdminName + ":" + admin.AdminPermissions);
            Application.Exit();
        }

        private void 注销系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Login login = new View_Login();
            login.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AddStu addStu = new View_AddStu();
            addStu.ShowDialog();
        }

        private void 查看学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AllStu allStu = new View_AllStu();
            allStu.ShowDialog();
        }

        private void 查看所有用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AllUser allUser = new View_AllUser();
            allUser.ShowDialog();
        }

        private void 添加班级信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AddClass addClass = new View_AddClass();
            addClass.ShowDialog();
        }

        private void 添加课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AddCourse addCourse = new View_AddCourse();
            addCourse.ShowDialog();
        }

        private void 添加新专业ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AddMajor addMajor = new View_AddMajor();
            addMajor.ShowDialog();
        }

        private void 添加新系部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AddDepartment addDepartment = new View_AddDepartment();
            addDepartment.ShowDialog();
        }

        private void 添加新学院ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AddAcademy addAcademy = new View_AddAcademy();
            addAcademy.ShowDialog();
        }

        private void 添加新事件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AddEvent addEvent = new View_AddEvent();
            addEvent.ShowDialog();
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AddUser addUser = new View_AddUser();
            addUser.ShowDialog();
        }

        private void 修改用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ChangeUser changeUser = new View_ChangeUser();
            changeUser.ShowDialog();
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_DelUser delUser = new View_DelUser();
            delUser.ShowDialog();
        }

        private void 查看班级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AllClass allClass = new View_AllClass();
            allClass.ShowDialog();
        }

        private void 查看课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AllCourse allCourse = new View_AllCourse();
            allCourse.ShowDialog();
        }

        private void 查看专业ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AllMajor allMajor = new View_AllMajor();
            allMajor.ShowDialog();
        }

        private void 查看系部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AllDepartment allDepartment = new View_AllDepartment();
            allDepartment.ShowDialog();
        }

        private void 查看学院ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AllAcademy allAcademy = new View_AllAcademy();
            allAcademy.ShowDialog();
        }

        private void 查看事件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AllEvent allEvent = new View_AllEvent();
            allEvent.ShowDialog();
        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ChangeStu changeStu = new View_ChangeStu();
            changeStu.ShowDialog();
        }

        private void 查看成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AllGrades allGrades = new View_AllGrades();
            allGrades.ShowDialog();
        }

        private void 录入成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_AddGrade addGrade = new View_AddGrade();
            addGrade.ShowDialog();
        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_DelStu view_DelStu = new View_DelStu();
            view_DelStu.ShowDialog();

        }

        private void 修改成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ChangeGrade view_ChangeGrade = new View_ChangeGrade();
            view_ChangeGrade.ShowDialog();
        }

        private void 删除成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_DelGrade view_DelGrade = new View_DelGrade();
            view_DelGrade.ShowDialog();
        }

        private void 修改班级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ChangeClass changeClass = new View_ChangeClass();
            changeClass.ShowDialog();
        }

        private void 删除课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_DeleteCourse deleteCourse = new View_DeleteCourse();
            deleteCourse.ShowDialog();
        }

        private void 删除专业ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_DeleteMajor deleteMajor = new View_DeleteMajor();
            deleteMajor.ShowDialog();
        }

        private void 删除系部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_DeleteDepartment deleteDepartment = new View_DeleteDepartment();
            deleteDepartment.ShowDialog();
        }

        private void 删除学院ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_DeleteAcademy deleteAcademy = new View_DeleteAcademy();
            deleteAcademy.ShowDialog();
        }

        private void 删除事件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_DelEvent delEvent = new View_DelEvent();
            delEvent.ShowDialog();
        }

        private void 删除班级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_DelClass delClass = new View_DelClass();
            delClass.ShowDialog();
        }

        private void 修改时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ChangeEvent changeEvent = new View_ChangeEvent();
            changeEvent.ShowDialog();
        }

        private void 修改课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ChangeCourse changeCourse = new View_ChangeCourse();
            changeCourse.ShowDialog();
        }

        private void 修改专业ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ChangeMajor changeMajor = new View_ChangeMajor();
            changeMajor.ShowDialog();
        }

        private void 修改系部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ChangeDepartment changeDepartment = new View_ChangeDepartment();
            changeDepartment.ShowDialog();
        }

        private void 修改学院ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ChangeAcademy changeAcademy = new View_ChangeAcademy();
            changeAcademy.ShowDialog();
        }
    }
}
