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
    /// Excel存在三层表头[HraderGroupEnum.One]
    /// </summary>
    public class OneHeardCommand : ExportHeaderCommand
    {
        #region ExportHeaderCommand
        protected override int CreateHeader()
        {
            //设置第一层表头
            this.CreateRow(this._context.RowIndex, HraderGroupEnum.One, this.MergedRegion);
            //设置第二层表头
            this.CreateRow(this._context.RowIndex + 1, HraderGroupEnum.Two, this.MergedRegion);
            //设置第三层表头
            this.CreateRow(this._context.RowIndex + 2, HraderGroupEnum.Three, this.MergedRegion);
            return this._context.RowIndex + 3;
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
                #region 第一层表头
                case HraderGroupEnum.One:
                    {
                        this._unit.SetCellValue(rIndex, cIndex, att.Name, this._hcStyle);
                        if (att.Colspan == ColspanEnum.Colspan)
                        {
                            #region 计算表头[X轴合并数]
                            int _colspan = 0;
                            ExcelAttribute nHeader = this._hdProps.Where(x =>
                                (x.HraderGroup == HraderGroupEnum.One && x.Index > att.Index)
                                || (x.HraderGroup == HraderGroupEnum.Two && ((int)x.Rowspan) > 0 && x.Index > att.Index)
                                || (x.HraderGroup == HraderGroupEnum.Three && ((int)x.Rowspan) == 2 && x.Index > att.Index)
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
                #endregion
                #region 第二层表头
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
                                _colspan = this._hdProps.Where(x => x.HraderGroup == HraderGroupEnum.Three && x.Index > att.Index).Count();
                            else
                                _colspan = nHeader.Index - att.Index - 1;
                            #endregion
                            this._unit.MergedRegion(rIndex, rIndex, cIndex, cIndex + _colspan, this._hcStyle);
                        }
                    }
                    break;
                #endregion
                #region 第三层表头
                case HraderGroupEnum.Three:
                    {
                        if ((int)att.Rowspan > 0)
                        {
                            switch (att.Rowspan)
                            {
                                case RowspanEnum.二:
                                    {
                                        this._unit.SetCellValue(rIndex - 1, cIndex, att.Name, null);
                                        this._unit.MergedRegion(rIndex - 1, rIndex, cIndex, cIndex, this._hcStyle);
                                    }
                                    break;
                                case RowspanEnum.三:
                                    {
                                        this._unit.SetCellValue(rIndex - 2, cIndex, att.Name, null);
                                        this._unit.MergedRegion(rIndex - 2, rIndex, cIndex, cIndex, this._hcStyle);
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
                #endregion
            }
        }
        #endregion

    }
}
