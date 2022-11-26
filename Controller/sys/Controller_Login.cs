using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager.Controller
{
    public class Controller_Login
    {
       
        const int LOGIN_SUCCESS = 1000;
        const int ACCOUNT_ERROR = 1001;
        const int INPUT_EMPTY = 1002;


        public Controller_Login()
        {

        }

        public List<object> UserLogin(TextBox userNameBox, TextBox passwordBox)
        {
            List<object> result = new List<object>();
            string userName = userNameBox.Text;
            string password = passwordBox.Text;
            DataSet token = MysqlUtils.GetHead().Select("admin", "Name", userName, "Password", password);
            Poco_Model.Admin admin = new Poco_Model.Admin(token);
            if (userName != string.Empty && password != string.Empty)
            {
                if (admin.Empty())
                {
                    result.Add(ACCOUNT_ERROR);
                    return result;
                }
                else
                {
                    result.Add(LOGIN_SUCCESS);
                    result.Add(admin);
                    return result;
                }
            }
            else
            {
                result.Add(INPUT_EMPTY);
                return result;
            }
        }
    }
}
