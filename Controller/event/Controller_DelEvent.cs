using System.Windows.Forms;

namespace StudentManager
{
    class Controller_DelEvent
{
        public Controller_DelEvent()
        {

        }

        public void Delete(string ID)
        {
            if (MysqlUtils.GetHead().Select("event", "ID", ID).Tables[0].Rows.Count != 0)
            {
               if (MysqlUtils.GetHead().Delete("event", "ID", ID))
                {
                    MessageBox.Show("事件删除成功！");
                }
                else
                {
                    MessageBox.Show("事件删除失败，请联系管理员！");
                }
            }
            else
            {
                MessageBox.Show("该事件不存在！");
            }
        }
    }
}
