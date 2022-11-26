using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class View_ChangeEvent : Form
{
        Controller_ChangeEvent Controller_ChangeEvent;
        public View_ChangeEvent()
        {
            InitializeComponent();
            Controller_ChangeEvent = new Controller_ChangeEvent();
        }

        

        private void View_ChangeEvent_Load(object sender, EventArgs e)
        {
            Controller_ChangeEvent.FindAcademy(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_ChangeEvent.Change(comboBox6.Text,textBox1.Text);
            textBox1.Text = string.Empty;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeEvent.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeEvent.FindMajor(comboBox2.Text, comboBox3);
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeEvent.FindClass(comboBox3.Text, comboBox4);
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeEvent.FindStudent(comboBox4.Text, comboBox5);
        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeEvent.FindStudentDetails(comboBox5.Text,comboBox6);
        }

        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            Controller_ChangeEvent.GetDetails(comboBox6.Text,textBox1);
        }
    }
}
