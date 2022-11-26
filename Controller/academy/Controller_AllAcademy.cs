using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    class Controller_AllAcademy
    {
        public Controller_AllAcademy()
        {

        }
        public void GetAcademy(ListView listView1)
        {
            List<Poco_Model.Academy> Academys;
            DataSet Academy = MysqlUtils.GetHead().Select("academy");
            Academys = Poco_Model.ModelManager.LoadAcademy(Academy);
            LoadClassInfo(Academys, listView1);
        }

        private void LoadClassInfo(List<Poco_Model.Academy> Academys, ListView listView1)
        {
            for (int i = 0; i < Academys.Count; i++)
            {
                ListViewItem row = new ListViewItem();
                row.SubItems[0].Text = Convert.ToString(Academys[i].Id);
                row.SubItems.Add(Academys[i].AcademyName);
                listView1.Items.Add(row);
            }
        }
    }
}
