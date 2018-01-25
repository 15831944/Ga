using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.szrl100Model
{
    /// <summary>
    /// G&G代码企业关联
    /// </summary>
    public enum GGCodeType
    {
        [Description("不关联")]
        不关联 = 0,
        [Description("一般")]
        一般 = 1,
        [Description("关联公司")]
        关联公司 = 2,
        [Description("母公司")]
        母公司 = 3,
    }
}
