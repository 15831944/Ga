using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM2.Models.Code001
{
    /// <summary>
    /// 当前用户对象,支持序列化
    /// </summary>
    [Serializable]
    public class CurrentUserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string Pj00401 { set; get; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Pj00402 { set; get; }
        /// <summary>
        /// 用户编码
        /// </summary>
        public string Pj00421 { set; get; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public string Pj00301 { set; get; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Pj00302 { set; get; }
        /// <summary>
        /// 公司ID
        /// </summary>
        public string Pj02501 { set; get; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Pj02505 { set; get; }

    }
}