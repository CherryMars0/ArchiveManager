using System;
using System.Windows.Forms;
using static StudentManager.Poco_Model;

namespace StudentManager
{
    public partial class View_ChangeStu : Form
    {
        Controller_ChangeStu Controller_ChangeStu;
        string studentID;
        string classID;
        public View_ChangeStu()
        {
            InitializeComponent();
            Controller_ChangeStu = new Controller_ChangeStu();
        }

        private void View_ChangeStu_Load(object sender, EventArgs e)
        {
            Controller_ChangeStu.FindAcademy(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeStu.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeStu.FindMajor(comboBox2.Text, comboBox3);
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeStu.FindClass(comboBox3.Text, comboBox4);
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            this.classID = Controller_ChangeStu.FindStudent(comboBox4.Text, comboBox5);
        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            this.studentID = comboBox5.Text;
            if (comboBox5.Text.Length != 0)
            {
                Student selectStudent = Controller_ChangeStu.SearchStudent(comboBox5.Text);
                textBox1.Text = selectStudent.Name;
                textBox3.Text = selectStudent.Address;
                textBox4.Text = Convert.ToString(selectStudent.IdCard);
                textBox5.Text = Convert.ToString(selectStudent.Tel);
                comboBox6.Text = selectStudent.Sex;
                label1.Text = "入学时间（一般不允许修改）" + selectStudent.EnrollmentDates;
                comboBox5.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("该班级中没有学生！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1 && textBox3.Text.Length >= 4 && textBox4.Text.Length == 18 && comboBox6.Text != "" && textBox5.Text.Length == 11)
            {
                Student student = new Student();
                student.Name = textBox1.Text;
                student.Sex = comboBox6.Text;
                student.Address = textBox3.Text;
                student.IdCard = Convert.ToInt64(textBox4.Text);
                student.Tel = Convert.ToInt64(textBox5.Text);
                student.ClassId = Convert.ToInt64(classID);
                student.Id = Convert.ToInt64(studentID);
                MessageBox.Show(student.ToString());
                Controller_ChangeStu.Change(student);
            }
            else
            {
                MessageBox.Show("请输入完整的学生信息!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
