using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    /// <summary>
    /// Excel存在二层表头[HraderGroupEnum.Two]
    /// </summary>
    public class TwoHeardCommand : ExportHeaderCommand
    {
        #region ExportHeaderCommand
        protected override int CreateHeader()
        {
            //设置第二层表头
            this.CreateRow(this._context.RowIndex, HraderGroupEnum.Two, this.MergedRegion);
            //设置第三层表头
            this.CreateRow(this._context.RowIndex + 1, HraderGroupEnum.Three, this.MergedRegion);
            return this._context.RowIndex + 2;
        }
        #endregion
        #region 合并单元格 - 赋值
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="hcStyle"></param>
        /// <param name="hdAtt"></param>
        /// <param name="hraderGroup"></param>
        /// <param name="cIndex"></param>
        private void MergedRegion(IRow row, ExcelAttribute att, HraderGroupEnum hraderGroup, int rIndex, int cIndex)
        {
            switch (hraderGroup)
            {
                case HraderGroupEnum.Two:
                    {
                        this._unit.SetCellValue(rIndex, cIndex, att.Name, this._hcStyle);
                        if (att.Colspan == ColspanEnum.Colspan)
                        {
                            #region 计算表头[X轴合并数]
                            int _colspan = 0;
                            ExcelAttribute nHeader = this._hdProps.Where(x =>
                                (x.HraderGroup == HraderGroupEnum.Two && x.Index > att.Index)
                                || (x.HraderGroup == HraderGroupEnum.Three && ((int)x.Rowspan) > 0 && x.Index > att.Index)
                            ).OrderBy(x => x.Index).FirstOrDefault();
                            if (nHeader == null)
                            {
                                _colspan = this._hdProps.Where(x => x.HraderGroup == HraderGroupEnum.Three && x.Index > att.Index).Count();
                            }
                            else
                                _colspan = nHeader.Index - att.Index - 1; 
                            #endregion
                            this._unit.MergedRegion(rIndex, rIndex, cIndex, cIndex + _colspan, this._hcStyle);
                        }
                    }
                    break;
                case HraderGroupEnum.Three:
                    {
                        if ((int)att.Rowspan > 0)
                        {
                            switch (att.Rowspan)
                            {
                                case RowspanEnum.二:
                                    {
                                        this._unit.SetCellValue(rIndex - 1, cIndex, att.Name, this._hcStyle);
                                        this._unit.MergedRegion(rIndex - 1, rIndex, cIndex, cIndex, this._hcStyle);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            this._unit.SetCellValue(rIndex, cIndex, att.Name, this._hcStyle);
                        }
                    }
                    break;
            }
        }
        #endregion
    }
}
