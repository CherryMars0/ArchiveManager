using StudentManager.Controller;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManager.View
{
    public partial class View_AllStu : Form
    {
        Controller_AllStu Controller_AllStu;
        public View_AllStu()
        {
            InitializeComponent();
            Controller_AllStu = new Controller_AllStu();
        }

        private void View_AllStu_Load(object sender, EventArgs e)
        {
             comboBox1.Items.Clear();
             Controller_AllStu.FindAcademy(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            if(ID != string.Empty)
            {
                Controller_AllStu.SerachStuInID(listView1, ID);
            }
            else
            {
                MessageBox.Show("请输入学号！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            if (name != string.Empty)
            {
                string str = Controller_AllStu.SerachStuInName(listView1, name);
                label3.Text = "共找到 " + str + " 条,与 " + name + " 相关的信息 ！";
            }
            else
            {
                MessageBox.Show("请输入姓名！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string classID = textBox3.Text;
            if (classID != string.Empty)
            {
                Controller_AllStu.SerachStuInClass(listView1, classID);
            }
            else
            {
                MessageBox.Show("请输入班级代码！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim().Length != 0 && comboBox2.Text.Trim().Length != 0 && comboBox3.Text.Trim().Length != 0 && comboBox4.Text.Trim().Length != 0)
            {
                string str = Controller_AllStu.SerachStuInMajro(listView1);
                label9.Text = "共找到 " + str + " 条,相关的信息 ！";
            }
            else
            {
                MessageBox.Show("请选择完整的条件！");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_AllStu.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_AllStu.FindMajor(comboBox2.Text, comboBox3);
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            Controller_AllStu.FindClass(comboBox3.Text, comboBox4);
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            Controller_AllStu.FindClassID(comboBox4.Text);
        }
    }
}
