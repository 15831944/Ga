using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class ValidationContext : System.EventArgs
    {
        /// <summary>
        /// 是否验证通过(False: 跳过当前导入行数据)
        /// </summary>
        private bool isValidation = true;
        public bool IsValidation { set { this.isValidation = value; } get { return this.isValidation; } }

        /// <summary>
        /// 当前[模型数据]
        /// </summary>
        public object CurrentValue { get; set; }

    }
}
