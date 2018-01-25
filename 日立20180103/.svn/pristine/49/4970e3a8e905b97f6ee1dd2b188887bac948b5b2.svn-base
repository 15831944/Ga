using Gmail.DDD.Utility;
using Gmail.DDD.Extensions;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class ExcelUnitWork : IExcelUnitWork
    {
        public IComponent<WorkbookAdapter> WorkbookAdapter { get; private set; }
        private IWorkbook XSSFWorkbook { get { return this.WorkbookAdapter.Current.XSSFWorkbook; } }
        private ISheet Sheet { get { return this.WorkbookAdapter.Current.SheetContext.Sheet; } }

        #region ctor
        /// <summary>
        /// 内存创建
        /// </summary>
        /// <param name="sheetName">Sheet名称</param>
        public ExcelUnitWork(string sheetName)
        {
            this.WorkbookAdapter = new WorkbookAdapter();
            this.WorkbookAdapter.Current.CreateSheet(sheetName);
        }
        /// <summary>
        /// 指定本地Excel文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetIndex"></param>
        public ExcelUnitWork(string filePath, int sheetIndex)
        {
            this.WorkbookAdapter = new WorkbookAdapter(filePath);
            this.WorkbookAdapter.Current.ChangeSheet(sheetIndex);
        }
        /// <summary>
        /// Stream
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetIndex"></param>
        public ExcelUnitWork(System.IO.Stream stream, int sheetIndex)
        {
            this.WorkbookAdapter = new WorkbookAdapter(stream);
            this.WorkbookAdapter.Current.ChangeSheet(sheetIndex);
        }
        #endregion

        #region 操作 ISheet
        /// <summary>
        /// 创建 ISheet
        /// </summary>
        /// <param name="sheetName">Sheet 名称</param>
        /// <returns></returns>
        public SheetContext CreateSheet(string sheetName)
        {
            return this.WorkbookAdapter.Current.CreateSheet(sheetName);
        }

        /// <summary>
        /// 切换 Sheet
        /// </summary>
        /// <param name="sheetIndex">Sheet 下标</param>
        /// <returns></returns>
        public SheetContext ChangeSheet(int sheetIndex)
        {
            return this.WorkbookAdapter.Current.ChangeSheet(sheetIndex);
        }

        /// <summary>
        /// 当前Sheet 重新计算公式
        /// </summary>
        /// <returns></returns>
        public void SheetRecalculation()
        {
            this.WorkbookAdapter.Current.SheetContext.Sheet.ForceFormulaRecalculation = true;
        }
        #endregion

        #region 系统: 单元格样式工厂
        private ICellStyleFactory _cStylesFactory;
        public virtual ICellStyleFactory CStylesFactory
        {
            set { this._cStylesFactory = value; }
            get
            {
                if (_cStylesFactory == null)
                {
                    this._cStylesFactory = new DefualtCellStyleFactory(this.WorkbookAdapter, new CellStyleContext
                    {
                        FontHeightInPoints = 10,
                        Border = true
                    });
                }
                return this._cStylesFactory;
            }
        }
        #endregion
        #region 合并单元格
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="FirstRow"></param>
        /// <param name="LastRow"></param>
        /// <param name="FirstCell"></param>
        /// <param name="LastCell"></param>
        /// <param name="ccStyle">合并后[单元格样式]</param>
        public void MergedRegion(int FirstRow, int LastRow, int FirstCell, int LastCell, CellStyleContext cStyle)
        {
            if (this.Sheet == null)
                throw new Exception("ISheet is Null");

            ICellStyle style = null;
            if (cStyle != null)
                style = CellStyleCreate.Instance.Create(this.WorkbookAdapter, cStyle);

            for (int i = FirstRow; i <= LastRow; i++)
            {
                IRow row = this.GetRow(i);
                for (int j = FirstCell; j <= LastCell; j++)
                {
                    ICell singleCell = (row.GetCell(j) == null) ? row.CreateCell(j) : row.GetCell(j);
                    if (style != null)
                        singleCell.CellStyle = style;
                }
            }
            this.Sheet.AddMergedRegion(new CellRangeAddress(FirstRow, LastRow, FirstCell, LastCell));

        }
        #endregion
        #region 从指定的行[创建移动区域行]
        /// <summary>
        /// 从指定的行[创建移动区域行]
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="inCount">创建移动区域行</param>
        /// <param name="cStyle">单元格样式: 默认与起始移动行相同</param>
        public void InsertCopyRows(int startRow, int inCount, CellStyleContext cStyle = null)
        {
            if (this.Sheet == null)
                throw new Exception("ISheet is Null");

            if (inCount == 1)
                return;
            else
                inCount = inCount - 1;

            ICellStyle style = null;
            if (cStyle != null)
                style = CellStyleCreate.Instance.Create(this.WorkbookAdapter, cStyle);

            //要复制起始 Row
            IRow copyRow = this.GetRow(startRow);
            //Excel 移动区域行Row.
            this.Sheet.ShiftRows(startRow, this.Sheet.LastRowNum, inCount, true, true);
            //创建移动后的Row 并复制单元格样式.
            for (int i = startRow; i < startRow + inCount; i++)
            {
                IRow targetRow = this.Sheet.CreateRow(i);
                targetRow.HeightInPoints = copyRow.HeightInPoints;
                for (int j = copyRow.FirstCellNum; j < copyRow.LastCellNum; j++)
                {
                    ICell copyCell = this.GetCell(copyRow, j);
                    ICell targetCell = targetRow.CreateCell(j);
                    targetCell.CellStyle = (style == null) ? copyCell.CellStyle : style;
                }
            }
        }
        #endregion

        #region 设置单元格数据
        /// <summary>
        /// 设置单元格数据
        /// </summary>
        /// <param name="rIndex">行下标[0]</param>
        /// <param name="cIndex">单元格下标[0]</param>
        /// <param name="value">Value</param>
        /// <param name="cStyle">单元格样式</param>
        public void SetCellValue(int rIndex, int cIndex, string value, CellStyleContext cStyle = null)
        {
            value = value == null ? string.Empty : value.ToString();
            ICell cell = this.GetCell(rIndex, cIndex);
            cell.SetCellValue(value);
            if (cStyle != null)
                cell.CellStyle = CellStyleCreate.Instance.Create(this.WorkbookAdapter, cStyle);
        }

        /// <summary>
        /// 设置单元格数据 - 系统样式
        /// </summary>
        /// <param name="rIndex">行下标[0]</param>
        /// <param name="cIndex">单元格下标[0]</param>
        /// <param name="value">Value</param>
        /// <param name="cStyle">[系统]单元格样式</param>
        /// <param name="isCStyle">是否[启用系统样式]</param>
        public void SetCellValue(int rIndex, int cIndex, string value, CellStyleEnum cStyle, bool isCStyle = true)
        {
            value = value == null ? string.Empty : value.ToString();
            ICell cell = this.GetCell(rIndex, cIndex);
            switch (cStyle)
            {
                case CellStyleEnum.String_Left:
                case CellStyleEnum.String_Center:
                case CellStyleEnum.String_Right:
                    cell.SetCellValue(value.ToString());
                    break;
                case CellStyleEnum.Date_Center:
                case CellStyleEnum.Date_Left:
                    if (
                        !value.IsConvert<DateTime>(x =>
                        {
                            cell.SetCellValue(x.AsYMd_String());
                            return true;
                        })
                    ) { }

                    break;
                case CellStyleEnum.Round2_Right:
                    if (
                        !value.IsConvert<decimal>(x =>
                        {
                            cell.SetCellValue(x.AsTwoPoint());
                            return true;
                        })
                    ) { }

                    break;
                case CellStyleEnum.Round4_Right:
                    if (
                        !value.IsConvert<decimal>(x =>
                        {
                            cell.SetCellValue(x.AsFourPoint());
                            return true;
                        })
                    ) { }

                    break;
                case CellStyleEnum.Double_None:
                    //适用于: Excel 模板里面自带公式
                    if (
                        !value.IsConvert<double>(x =>
                        {
                            cell.SetCellValue(x);
                            return true;
                        })
                    ) { }

                    break;
                case CellStyleEnum.Percentage_Right:
                    if (
                        !value.IsConvert<decimal>(x =>
                        {
                            cell.SetCellValue(x.AsPercentage());
                            return true;
                        })
                    ) { }

                    break;

                case CellStyleEnum.Int_Right:
                case CellStyleEnum.Int_Center:
                    if (
                        !value.IsConvert<int>(x =>
                        {
                            cell.SetCellValue(x.AsString());
                            return true;
                        })
                    ) {
 
                    }
                    break;
            }

            ICellStyle _cStyle = this.CStylesFactory.Create(cStyle);
            if (isCStyle && _cStyle != null)
                cell.CellStyle = _cStyle;

        }
        #endregion
        #region 获取单元格数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rIndex">行下标[0]</param>
        /// <param name="cIndex">单元格下标[0]</param>
        /// <returns></returns>
        public object GetCellValue(int rIndex, int cIndex)
        {
            ICell cell = this.GetCell(rIndex, cIndex);
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return string.Empty;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Error:
                    return cell.ErrorCellValue;
                case CellType.Numeric:
                case CellType.Unknown:
                default:
                    return cell.ToString();
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Formula:
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue;
                    }
            }
        }
        #endregion
        
        #region 其他操作
        public IRow GetRow(int rowIndex)
        {
            return (this.Sheet.GetRow(rowIndex) == null) ? this.Sheet.CreateRow(rowIndex) : this.Sheet.GetRow(rowIndex);
        }
        public ICell GetCell(IRow row, int cellndex)
        {
            return (row.GetCell(cellndex) == null) ? row.CreateCell(cellndex) : row.GetCell(cellndex);
        }
        public ICell GetCell(int rIndex, int cIndex)
        {
            IRow row = this.GetRow(rIndex);
            ICell cell = this.GetCell(row, cIndex);
            return cell;
        }
        #endregion



        
    }
}
