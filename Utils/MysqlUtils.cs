using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace StudentManager
{
    public class MysqlUtils
    {
        string connStr;
        string cmdText;
        MySqlConnection conn;
        MySqlCommand cmd;


        public MysqlUtils(string dataBaseName)
        {
            connStr = string.Format(
                "Database={0};DataSource=localhost;User=root;port=3309;SslMode=None;Charset=utf8;",
                dataBaseName
            );
            conn = new MySqlConnection(connStr);
        }
        //测试连接
        public void TestConn()
        {
            try
            {
                conn.Open();
                conn.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"数据库连接错误！");
            }
        }

        //获取连接
        public static MysqlUtils GetHead()
        {
            return new MysqlUtils("StudentManager");
        }

        //查询整个表
        public DataSet Select(string tableName)
        {
            conn.Open();
            cmdText = string.Format(
                "SELECT * FROM {0}",tableName
            );
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset,tableName);
            conn.Close();
            return dset;
        }

        //带一个条件查找
        public DataSet Select(string tableName,string key,string value)
        {
            conn.Open();
            cmdText = string.Format(
                "SELECT * FROM {0} where {1} = '{2}';",
                tableName, key, value
            );
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return dset;
        }

        //带两个条件查找
        public DataSet Select(string tableName, string firstKey, string firstValue,string secondKey,string secondValue)
        {
            conn.Open();
            cmdText = string.Format(
                "SELECT * FROM {0} where {1}='{2}' and {3}='{4}';",
                tableName, firstKey, firstValue, secondKey, secondValue
            );
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return dset;
        }

        //带三个条件查找
        public DataSet Select(string tableName, string firstKey, string firstValue, string secondKey, string secondValue,string thirdKey,string thirdValue)
        {
            conn.Open();
            cmdText = string.Format(
                "SELECT * FROM {0} where {1}='{2}' and {3}='{4}' and {5}='{6}';",
                tableName, firstKey, firstValue, secondKey, secondValue, thirdKey, thirdValue
            );
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return dset;
        }

        //带四个条件查找
        public DataSet Select(string tableName, string firstKey, string firstValue, string secondKey, string secondValue, string thirdKey, string thirdValue,string fourthKey,string fourthValue)
        {
            conn.Open();
            cmdText = string.Format(
                "SELECT * FROM {0} where {1}='{2}' and {3}='{4}' and {5}='{6}' and {7}='{8}';",
                tableName, firstKey, firstValue, secondKey, secondValue, thirdKey, thirdValue, fourthKey, fourthValue
            );
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return dset;
        }

        //无参Count
        public string Count(string tableName,string column)
        {
            conn.Open();
            cmdText = string.Format(
                "select count({0}) from {1};",
                column, tableName
            );
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return Convert.ToString(dset.Tables[0].Rows[0][0]);
        }

        //1参Count
        public string Count(string tableName, string column,string firstKey, string firstValue)
        {
            conn.Open();
            cmdText = string.Format(
                "select count({0}) from {1} where {2} = '{3}';",
                column, tableName, firstKey, firstValue
            );
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return Convert.ToString(dset.Tables[0].Rows[0][0]);
        }

        //插入
        public bool Insert(string tableName,string keysProp,string valuesProp)
        {
            conn.Open();
            cmdText = string.Format(
                "insert into {0}({1}) values({2});",
                tableName, keysProp, valuesProp
            );
            MessageBox.Show(cmdText);
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return true;
        }

        //更改带 1 个条件
        public bool Update(string tableName, string target, string value, string firstKey, string firstValue)
        {
            conn.Open();
            cmdText = string.Format(
                "update {0} set {1} = '{2}' where {3} = '{4}';",
                tableName, target, value, firstKey, firstValue
            );
            MessageBox.Show(cmdText);
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return true;
        }

        //更改带 2 个条件
        public bool Update(string tableName,string target,string value, string firstKey, string firstValue, string secondKey, string secondValue)
        {
            conn.Open();
            cmdText = string.Format(
                "update {0} set {1} = '{2}' where {3} = '{4}' and {5} = '{6}';",
                tableName,target, value, firstKey, firstValue, secondKey, secondValue
            );
            MessageBox.Show(cmdText);
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return true;
        }

        //更改带混合
        public bool UpdateMixd(string tableName, string props,string condition)
        {
            conn.Open();
            cmdText = string.Format(
                "update {0} set {1} where {2};",
                tableName, props, condition
            );
            cmd = new MySqlCommand(cmdText, conn);
            MessageBox.Show(cmdText);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return true;
        }

        //删除带一个参数
        public bool Delete(string tableName, string key, string value)
        {
            conn.Open();
            cmdText = string.Format(
                "delete from {0} where {1} = '{2}';",
                tableName, key, value
            );
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return true;
        }

        //删除带两个参数
        public bool Delete(string tableName, string firstKey, string firstValue, string secondKey, string secondValue)
        {
            conn.Open();
            cmdText = string.Format(
                "delete from {0} where {1} = '{2}' and {3} = '{4}';",
                tableName, firstKey, firstValue, secondKey, secondValue
            );
            cmd = new MySqlCommand(cmdText, conn);
            MySqlDataAdapter dad = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            dad.Fill(dset, tableName);
            conn.Close();
            return true;
        }

        //创建回滚点
        public bool SavePoint(string savePointName)
        {
            conn.Open();
            cmdText = string.Format(
                "set savepoint ({0});",
                savePointName
            );
            MessageBox.Show(cmdText);
            //new MySqlCommand(cmdText, conn);
            conn.Close();
            return true;
        }
    }
}
