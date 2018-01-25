using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class CellStyleContext
    {
        /// <summary>
        /// 是否为粗体
        /// </summary>
        public bool Boldweight { get; set; }

        /// <summary>
        /// 字体
        /// </summary>
        private string fontName = "宋体";
        public string FontName { get { return this.fontName; } set { this.fontName = value; } }

        /// <summary>
        /// 边框
        /// </summary>
        public bool Border { get; set; }

        /// <summary>
        /// 字体大小
        /// </summary>
        public short FontHeightInPoints { get; set; }

        /// <summary>
        /// 对齐方式
        /// </summary>
        public HorizontalAlignment Alignment { get; set; }

        /// <summary>
        /// 垂直对齐[合并单元格后设置居中]
        /// </summary>
        public VerticalAlignment VerticalAlignment { get; set; }

        /// <summary>
        /// 系统默认样式格式
        /// </summary>
        public CellStyleEnum CellStyleEnum { get; set; }

    }
}
