using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code030
{
    public class MaterialExcelBase
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string ExcelFilePath { get; set; }
        /// <summary>
        /// 工作表
        /// </summary>
        public string ExcelWookSheet { get; set; }
        /// <summary>
        /// 数据范围
        /// </summary>
        public string DataRange { get; set; }

    }
}
