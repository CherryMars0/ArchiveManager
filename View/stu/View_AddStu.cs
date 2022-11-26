using StudentManager.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudentManager.Poco_Model;

namespace StudentManager
{
    public partial class View_AddStu : Form
    {
        readonly Controller_AddStu Controller_AddStu;

        public View_AddStu()
        {
            InitializeComponent();
            Controller_AddStu = new Controller_AddStu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 11 && textBox2.Text.Length == 18 && textBox3.Text.Length > 3 && comboBox5.Text != "" && textBox5.Text != "")
            {
                Student student = new Student();
                student.Name = textBox5.Text;
                student.Sex = comboBox5.Text;
                student.Address = textBox3.Text;
                student.IdCard = Convert.ToInt64(textBox2.Text);
                student.Tel = Convert.ToInt64(textBox1.Text);
                student.EnrollmentDates = DateTime.Now.ToString();
                student.ClassId = Controller_AddStu.FindClassID(comboBox4.Text);
                student.Id = Controller_AddStu.CreateID(student.ClassId);
                if (student.Id != 0)
                {
                    Controller_AddStu.InsertStudent(student);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("班级人数超过一百人，规定一个平行班人数不得超过100人，请创建一个班级！");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("请输入完整的学生信息!");
            }
        }

        private void View_AddStu_Load(object sender, EventArgs e)
        {
            comboBox5.SelectedIndex = 0;
            Controller_AddStu.FindAcademy(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_AddStu.FindDepartment(comboBox1.Text,comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_AddStu.FindMajor(comboBox2.Text,comboBox3);
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            Controller_AddStu.FindClass(comboBox3.Text,comboBox4);
        }
    }
}
