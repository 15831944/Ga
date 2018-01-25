using Gmail.DDD.Utility;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public sealed class CellStyleCreate : Singleton<CellStyleCreate>, ICellStyleFormat
    {
        private CellStyleCreate() { }
        static CellStyleCreate() { }
        #region ICellStyleCreate
        public ICellStyle Create(IComponent<WorkbookAdapter> wAdapter, CellStyleContext context)
        {
            IWorkbook _workbook = wAdapter.Current.XSSFWorkbook;
            ICellStyle _cellStyle = _workbook.CreateCellStyle();

            #region 字体格式
            //字体样式
            IFont _iFont = _workbook.CreateFont();
            //粗体
            if (context.Boldweight)
                _iFont.Boldweight = 700;

            _iFont.FontName = context.FontName;
            _iFont.FontHeightInPoints = context.FontHeightInPoints;
            _cellStyle.SetFont(_iFont);
            #endregion

            //对齐方式
            _cellStyle.Alignment = context.Alignment;
            //垂直对齐[合并单元格后设置居中]
            _cellStyle.VerticalAlignment = context.VerticalAlignment;
            //边框
            if (context.Border)
            {
                _cellStyle.BorderBottom = BorderStyle.Thin;
                _cellStyle.BorderLeft = BorderStyle.Thin;
                _cellStyle.BorderRight = BorderStyle.Thin;
                _cellStyle.BorderTop = BorderStyle.Thin;
            }
            return _cellStyle;
        }
        #endregion

    }
}
