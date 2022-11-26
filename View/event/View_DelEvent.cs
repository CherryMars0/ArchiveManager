using System;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class View_DelEvent : Form
{
        Controller_DelEvent Controller_DelEvent;
        public View_DelEvent()
        {
            InitializeComponent();
            Controller_DelEvent = new Controller_DelEvent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller_DelEvent.Delete(textBox1.Text);
        }
    }
}
