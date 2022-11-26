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
    public partial class View_AddEvent : Form
{
        Controller_AddEvent Controller_AddEvent;
        public View_AddEvent()
        {
            InitializeComponent();
            Controller_AddEvent = new Controller_AddEvent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_AddEvent.Add(comboBox5.Text,textBox1.Text);
            textBox1.Text = string.Empty;
        }

        private void View_AddEvent_Load(object sender, EventArgs e)
        {
            Controller_AddEvent.FindAcademy(comboBox1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Controller_AddEvent.FindDepartment(comboBox1.Text, comboBox2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Controller_AddEvent.FindMajor(comboBox2.Text, comboBox3);
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            Controller_AddEvent.FindClass(comboBox3.Text, comboBox4);
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            Controller_AddEvent.FindStudent(comboBox4.Text, comboBox5);
        }
    }
}
