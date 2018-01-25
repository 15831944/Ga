using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.szrl100Model
{
    /// <summary>
    /// 合同签订授权代表姓名的信息
    /// </summary>
    public class SignedNameObj
    {
        public string ID { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }
}
