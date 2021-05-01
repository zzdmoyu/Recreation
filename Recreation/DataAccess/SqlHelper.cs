using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Recreation.DataAccess
{
    public class SqlHelper
    {
        /// <summary>
        /// mysql数据库连接字符串
        /// </summary>
        public string MysqlConnectionString { get; set; }

        public SqlHelper()
        {
            this.MysqlConnectionString = "server=localhost;database=recreation;PORT=3306; uid=root;pwd=zx1217;Connect Timeout=600;charset=utf8";
        }

        public int ExecuteNonQuery(string sqlstr)
        {
            using (MySqlConnection connection = new MySqlConnection(this.MysqlConnectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlstr, connection);
                try
                {
                    connection.Open();
                    command.CommandTimeout = 0;
                    return command.ExecuteNonQuery();
                }
                catch (MySqlException exception)
                {
                    connection.Close();
                    throw exception;
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
        }

        public DataTable GetDataTable(string sqlstr)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(MysqlConnectionString))
            {
                using (MySqlCommand command = new MySqlCommand(sqlstr, connection))
                {
                    connection.Open();
                    new MySqlDataAdapter(command).Fill(dataTable);
                }
            }
            return dataTable;
        }

    }
}