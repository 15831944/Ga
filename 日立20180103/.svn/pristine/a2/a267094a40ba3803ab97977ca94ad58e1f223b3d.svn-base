using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code030
{
    /// <summary>
    /// 暂时使用
    /// </summary>
    public class SqlHelper
    {
        private static string _ConnectionString = string.Empty;
        public static string ConnectionString
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_ConnectionString))
                //{
                //    string dir = AppDomain.CurrentDomain.BaseDirectory;
                //    string filePath = Path.Combine(dir, "PM2Config.json");
                //    FileStream fs = File.OpenRead(filePath);
                //    StreamReader sr = new StreamReader(fs);
                //    string configContent = sr.ReadToEnd();

                //    szrl100_PM2Config config = JsonConvert.DeserializeObject<szrl100_PM2Config>(configContent);
                //    _ConnectionString = config.DataConfig.EFConfig.DbContextConfig[0].ConnectionString;
                //    fs.Close();
                //}
                //return _ConnectionString;
                return "Data Source=192.168.1.14;Initial Catalog=BS_Prj_苏州日立;Persist Security Info=True;User ID=sa;Password=888888;MultipleActiveResultSets = True";
            }
        }

        public static object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text);
        }

        public static object ExecuteScalar(string sql, CommandType commandType)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = commandType;
                object result = cmd.ExecuteScalar();
                conn.Close();
                return result;
            }
        }
    }
}
