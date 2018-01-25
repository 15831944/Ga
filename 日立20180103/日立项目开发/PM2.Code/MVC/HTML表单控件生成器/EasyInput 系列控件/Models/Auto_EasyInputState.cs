using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code
{
    public enum Auto_EasyInputState
    {
        None,

        /// <summary>
        /// 文本框
        /// </summary>
        Easy_Textbox,

        /// <summary>
        /// 密码框
        /// </summary>
        Easy_Passwordbox,

        /// <summary>
        /// 数值框
        /// </summary>
        Easy_Numberbox_Int32,
        Easy_Numberbox_Decimal,

        /// <summary>
        /// 日期框
        /// </summary>
        Easy_Datebox,

        /// <summary>
        /// 下拉列表
        /// </summary>
        Easy_Combobox,

        /// <summary>
        /// 复选框: 开关
        /// </summary>
        Easy_Switchbutton
        
    }
}
