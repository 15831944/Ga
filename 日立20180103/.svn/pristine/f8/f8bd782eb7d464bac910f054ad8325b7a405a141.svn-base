using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PM2.Code.NPOI;
using PM2.Models.Code030.szrl111Model;
using PM2.Service.Code001;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PM2.Service.Code030.Szrl105Service
{
    public class GlobalService
    {
        /// <summary>
        /// 取当前登录用户
        /// </summary>
        /// <returns></returns>
        public static string GetLoginUserId()
        {
            string name = "当前用户1";
            if (HttpContext.Current != null)
            {
                name = HttpContext.Current.User.Identity.Name;
            }

            return name;
        }


        /// <summary>
        /// 取当前登录用户
        /// </summary>
        /// <returns></returns>
        public static string GetLoginUserName()
        {
            string name = "当前用户1";
            if (HttpContext.Current != null)
            {
                name = UserContext.Pj00402;
            }

            return name;
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SerializeDateObject(object data)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(data, Formatting.Indented, timeConverter);
        }


        /// <summary>
        /// 取新的供应商序列号
        /// </summary>
        /// <returns></returns>
        private string GetNewSupplierSerialNo()
        {
            string sql = "EXEC P_GetNewSequence";
            int no = (int)SqlHelper.ExecuteScalar(sql);
            return no.ToString().PadLeft(5, '0');
        }


        /// <summary>
        /// 取新的GUID
        /// </summary>
        /// <returns></returns>
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }


        public static DataTable ToDataTable<TEntity>(IEnumerable<TEntity> objs, string dtName = "")
        {
            var type = typeof(TEntity);
            var infos = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            dtName = string.IsNullOrWhiteSpace(dtName) ? type.Name : dtName;
            DataTable dt = new DataTable(dtName);
            List<ExcelColAttribute> attrList = new List<ExcelColAttribute>();
            foreach(var info in infos)
            {
                var attr = (ExcelColAttribute)info.GetCustomAttribute(typeof(ExcelColAttribute), false);
                attr.PI = info;
                attrList.Add(attr);
            }
            attrList = attrList.OrderBy(x => x.Index).ToList();
            foreach (var attr in attrList)
            {
                dt.Columns.Add(attr.Name);
            }

            foreach (var obj in objs)
            {
                DataRow dr = dt.NewRow();
                foreach (var attr in attrList)
                {
                    dr[attr.Name] = Convert.ToString(attr.PI.GetValue(obj));
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }


        /// <summary>
        /// 搜索树
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="key"></param>
        public static void SearchByKey(List<TreeNodeInfo> nodeList, string key)
        {
            for (var i = 0; i < nodeList.Count; i++)
            {
                var hasKey = HasKey(nodeList, nodeList[i], key);
                if (!hasKey)
                {
                    i--;
                }
            }
        }

        /// <summary>
        /// 搜索树子节点
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static bool HasKey(List<TreeNodeInfo> nodeList, TreeNodeInfo node, string key)
        {
            bool selfHasKey = node.text.Contains(key);
            bool childHasKey = false;
            var childNodeList = node.children;
            if (childNodeList != null)
            {
                for (var i = 0; i < childNodeList.Count; i++)
                {
                    var childHasKey2 = HasKey(childNodeList, childNodeList[i], key);
                    if (!childHasKey2)
                    {
                        i--;
                    }
                    else
                    {
                        childHasKey = childHasKey2;
                    }
                }
            }

            bool hasKey = selfHasKey || childHasKey;
            if (!hasKey)
            {
                nodeList.Remove(node);
            }
            else
            {
                node.state = "open";
            }
            return hasKey;
        }
    }
}
