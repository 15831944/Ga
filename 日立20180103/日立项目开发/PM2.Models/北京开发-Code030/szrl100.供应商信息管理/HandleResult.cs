using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030
{
    /// <summary>
    /// 处理结果
    /// </summary>
    public class HandleResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMsg { get; set; }

        public object Data { get; set; }

        public HandleResult()
        {
            Success = true;
        }

        public HandleResult(bool success, string errorMsg)
        {
            Success = success;
            ErrorMsg = errorMsg;
        }
    }
}
