using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public abstract class ExportHeaderCommand : IExportHeaderCommand
    {
        /// <summary>
        /// 导出成功
        /// </summary>
        public event EventHandler<ExportContext> SuccessEvent;

        protected IExcelUnitWork _unit;
        protected ExportContext _context;

        protected IEnumerable<ExcelAttribute> _hdProps;
        protected CellStyleContext _hcStyle;
        #region IExcelCommand
        public void Execute(IExcelUnitWork unit, ExportContext context, IEnumerable<ExcelAttribute> hAttributes)
        {
            this._unit = unit;
            this._context = context;

            var query = from x in hAttributes.Where(x => x.Operation == Operation.All || x.Operation == Operation.Export)
                        select x;
            this._hdProps = query.ToArray();

            #region [单元格样式]
            CellStyleContext sContext = null;
            if (this._context != null && this._context.CellStyleContext != null)
                sContext = this._context.CellStyleContext;
            else 
                sContext = new CellStyleContext {
                    Border = true,
                    FontHeightInPoints = 10,
                    Alignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
            this._hcStyle = sContext;
            #endregion
            this._context.RowIndex = this.CreateHeader();

            if (this.SuccessEvent != null)
                this.SuccessEvent.Invoke(this, this._context);

        }
        #endregion
        #region 设置表头
        protected void CreateRow(int rIndex, HraderGroupEnum HraderGroup, Action<IRow, ExcelAttribute, HraderGroupEnum, int, int> MergedRegion = null)
        {
            IRow row = this._unit.GetRow(rIndex);
            foreach (ExcelAttribute att in this._hdProps.Where(x => x.HraderGroup == HraderGroup).OrderBy(x => x.Index))
            {
                int cIndex = this._context.CellIndex + att.Index;
                if (MergedRegion == null)
                    this._unit.SetCellValue(rIndex, cIndex, att.Name, this._hcStyle);
                else
                    MergedRegion.Invoke(row, att, HraderGroup, rIndex, cIndex);

                //设置宽度
                if (HraderGroup == HraderGroupEnum.Three)
                    this._unit.WorkbookAdapter.Current.SheetContext.Sheet.SetColumnWidth(cIndex, att.HWithpx);

            }
        }
        #endregion
        protected abstract int CreateHeader();

    }
}
