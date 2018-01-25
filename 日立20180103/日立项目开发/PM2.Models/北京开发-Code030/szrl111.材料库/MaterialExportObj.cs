using PM2.Code.NPOI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.szrl111Model
{
    [ExcelCol(Name = "材料信息")]
    public class MaterialExportObj
    {
        /// <summary>
        /// 材料编码
        /// </summary> 
        [ExcelCol(Index = 0, Name = "材料编码")]
        public string rl11103 { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary> 
        [ExcelCol(Index = 1, Name = "材料名称")]
        public string rl11104 { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary> 
        [ExcelCol(Index = 2, Name = "规格型号")]
        public string rl11105 { get; set; }
        /// <summary>
        /// 品牌
        /// </summary> 
        [ExcelCol(Index = 3, Name = "品牌")]
        public string rl11106 { get; set; }
        /// <summary>
        /// 产地
        /// </summary> 
        [ExcelCol(Index = 4, Name = "产地")]
        public string rl11107 { get; set; }
        /// <summary>
        /// 属性
        /// </summary> 
        [ExcelCol(Index = 5, Name = "属性")]
        public string rl11108 { get; set; }

        /// <summary>
        /// 备注
        /// </summary> 
        [ExcelCol(Index = 6, Name = "备注")]
        public string rl11110 { get; set; }


        /// <summary>
        /// 计量单位
        /// </summary> 
        [ExcelCol(Index = 7, Name = "计量单位")]
        public string MeasureUnitName { get; set; }
    }
}
