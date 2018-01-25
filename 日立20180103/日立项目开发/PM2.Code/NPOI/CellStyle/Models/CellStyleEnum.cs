using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public enum CellStyleEnum
    {
        /// <summary>
        /// 字符串:左对齐
        /// </summary>
        String_Left,
        /// <summary>
        /// 字符串:居中对齐
        /// </summary>
        String_Center,
        /// <summary>
        /// 字符串:居右对齐
        /// </summary>
        String_Right,
        /// <summary>
        /// 日期格式 yyyy-MM-dd:居中对齐
        /// </summary>
        Date_Center,
        /// <summary>
        /// 日期格式 yyyy-MM-dd: 左边对齐
        /// </summary>
        Date_Left,
        /// <summary>
        /// 保留2位小数 #,##0.00:右对齐
        /// </summary>
        Round2_Right,
        /// <summary>
        /// 保留4位小数 #,##0.0000:右对齐
        /// </summary>
        Round4_Right,
        /// <summary>
        /// % 百分比:右对齐
        /// </summary>
        Percentage_Right,
        /// <summary>
        /// 整形:右对齐
        /// </summary>
        Int_Right,
        /// <summary>
        /// 整形:居中对齐
        /// </summary>
        Int_Center,

        /// <summary>
        /// Double: 无格式
        /// </summary>
        Double_None
    }
}
