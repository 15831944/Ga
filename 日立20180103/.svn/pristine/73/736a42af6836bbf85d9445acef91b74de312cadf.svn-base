using Gmail.DDD.Utility;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public interface IExcelUnitWork
    {
        IComponent<WorkbookAdapter> WorkbookAdapter { get; }
        #region 操作 ISheet
        /// <summary>
        /// 创建 ISheet
        /// </summary>
        /// <param name="sheetName">Sheet 名称</param>
        /// <returns></returns>
        SheetContext CreateSheet(string sheetName);

        /// <summary>
        /// 切换 Sheet
        /// </summary>
        /// <param name="sheetIndex">Sheet 下标</param>
        /// <returns></returns>
        SheetContext ChangeSheet(int sheetIndex);

        /// <summary>
        /// 当前Sheet 重新计算公式
        /// </summary>
        /// <param name="sheetIndex">Sheet 下标</param>
        /// <returns></returns>
        void SheetRecalculation();
        #endregion

        #region 单元格样式工厂
        /// <summary>
        /// 单元格样式工厂
        /// </summary>
        ICellStyleFactory CStylesFactory { set; get; }
        #endregion
        #region 合并单元格
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="FirstRow"></param>
        /// <param name="LastRow"></param>
        /// <param name="FirstCell"></param>
        /// <param name="LastCell"></param>
        /// <param name="cStyle">合并后[单元格样式]</param>
        void MergedRegion(int FirstRow, int LastRow, int FirstCell, int LastCell, CellStyleContext cStyle);
        #endregion
        #region 从指定的行[创建移动区域行]
        /// <summary>
        /// 从指定的行[创建移动区域行]
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="inCount">创建移动区域行</param>
        /// <param name="cStyle">单元格样式: 默认与起始移动行相同</param>
        void InsertCopyRows(int startRow, int inCount, CellStyleContext cStyle = null);
        #endregion

        #region 获取单元格数据
        /// <summary>
        /// 获取单元格数据
        /// </summary>
        /// <param name="rIndex">行下标[0]</param>
        /// <param name="cIndex">单元格下标[0]</param>
        /// <returns></returns>
        object GetCellValue(int rIndex, int cIndex);
        #endregion
        #region 设置单元格数据
        /// <summary>
        /// 设置单元格数据
        /// </summary>
        /// <param name="rIndex">行下标[0]</param>
        /// <param name="cIndex">单元格下标[0]</param>
        /// <param name="value">Value</param>
        /// <param name="cStyle">单元格样式</param>
        void SetCellValue(int rIndex, int cIndex, string value, CellStyleContext cStyle = null);

        /// <summary>
        /// 设置单元格数据 - 系统样式
        /// </summary>
        /// <param name="rIndex">行下标[0]</param>
        /// <param name="cIndex">单元格下标[0]</param>
        /// <param name="value">Value</param>
        /// <param name="cStyle">[系统]单元格样式</param>
        /// <param name="isCStyle">是否[启用系统样式]</param>
        void SetCellValue(int rIndex, int cIndex, string value, CellStyleEnum cStyle, bool isCStyle = true);
        #endregion

        #region 其他操作
        IRow GetRow(int rowIndex);
        ICell GetCell(IRow row, int cellndex);
        ICell GetCell(int rIndex, int cIndex);
        #endregion

    }


}
