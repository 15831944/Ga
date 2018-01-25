using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public sealed class ExcelAttribute : System.Attribute
    {
        /// <summary>
        /// 支持类型
        /// </summary>
        private Operation _op = Operation.All;
        public Operation Operation { get { return this._op; } set { this._op = value; } }

        #region 导出设置
        #region 多表头设置
        /// <summary>
        /// [多表头设置] 
        ///     注意: 最多支持三层.
        /// </summary>
        private HraderGroupEnum hraderGroup = HraderGroupEnum.Three;
        public HraderGroupEnum HraderGroup { get { return this.hraderGroup; } set { this.hraderGroup = value; } }
        /// <summary>
        /// [合并X轴]
        ///     注意: 此属性对[HraderGroupEnum.Three]无效. 
        /// </summary>
        public ColspanEnum Colspan { get; set; }
        /// <summary>
        /// [合并Y轴]
        ///     注意: 此属性对[HraderGroupEnum.One]无效. 
        /// </summary>
        public RowspanEnum Rowspan { get; set; }
        #endregion

        /// <summary>
        /// [表头排序下标]
        ///    注意: 下标从 0 开始 -> [存在多表头的情况下,下标必须与其一致]
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 表头名称
        /// </summary>
        public string Name { get; set; }

        #region 表头宽度
        /// <summary>
        /// 表头宽度
        /// </summary>
        private HWidthEnum hWidth = HWidthEnum.十五Px;
        public HWidthEnum HWidth { get { return this.hWidth; } set { this.hWidth = value; } }
        /// <summary>
        /// 表头宽度PX
        /// </summary>
        private int hWithpx = -1;
        public int HWithpx
        {
            get
            {
                if (this.hWithpx == -1)
                {
                    switch (this.HWidth)
                    {
                        case HWidthEnum.AutoPx:
                            break;
                        case HWidthEnum.十Px:
                            this.hWithpx = 10 * 256;
                            break;
                        case HWidthEnum.十五Px:
                            this.hWithpx = 15 * 256;
                            break;
                        case HWidthEnum.五十Px:
                            this.hWithpx = 50 * 256;
                            break;
                    }
                }
                return this.hWithpx;
            }
            set { this.hWithpx = value; }
        }
        #endregion

        /// <summary>
        /// 单元格内容格式化
        /// </summary>
        private CellStyleEnum cStyle = CellStyleEnum.String_Left;
        public CellStyleEnum CStyle { get { return this.cStyle; } set { this.cStyle = value; } }
        #endregion
        #region 导入设置
        /// <summary>
        /// 导入对应Excel头文
        /// </summary>
        public ECHeadEnum ECHeadEnum { get; set; }
        #endregion

    }
}
