using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using Gmail.DDD.JsonConvert;
using PM2.Models.Code030.szrl100Model;
using PM2.Models.Code030;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Web;
using PM2.Models.Code030.Szrl105Model;
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl111Model;
using PM2.Service.Code030.Szrl105Service;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Text.RegularExpressions;
using PM2.Code.NPOI;
using System.Reflection;
using Gmail.DDD.Mvc;
using NPOI.SS.Util;
using System.Web.Mvc;

namespace PM2.Service.Code030.szrl111Service
{
    /// <summary>
    /// 供应商信息管理
    /// </summary>
    public class ExcelService : IExcelService
    {
        /// <summary>
        /// 导入的EXCEL的临时存储目录
        /// </summary>
        private const string PATH_EXCEL_TEMP = "/Temp/szrl111/";


        /// <summary>
        /// 取EXCEL的工作表名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<TreeNodeInfo> GetSheetNames(string filePath)
        {
            FileStream fs = null;
            IWorkbook workbook = null;
            ISheet sheet = null;

            List<TreeNodeInfo> list = new List<TreeNodeInfo>();
            try
            {
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        int num = workbook.NumberOfSheets;
                        for (var i = 0; i < num; i++)
                        {
                            sheet = workbook.GetSheetAt(i);
                            list.Add(new TreeNodeInfo() { id = string.Format("{0}_{1}", i + 1, sheet.SheetName), text = sheet.SheetName });
                        }
                    }
                    workbook.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        /// <summary>
        /// 导入EXCEL数据
        /// </summary>
        /// <param name="excelInfo"></param>
        public DataTable ImportData(ImportExcelInfo excelInfo)
        {
            FileStream fs = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            DataTable dt = null;

            try
            {
                var filePath = excelInfo.ExcelFilePath;
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        dt = new DataTable();
                        sheet = workbook.GetSheet(excelInfo.SheetName);
                        if (sheet != null)
                        {
                            string[] rangeInfo = excelInfo.DataRange.Split(':');
                            if (rangeInfo.Length == 2)
                            {
                                var startColumn = rangeInfo[0].Substring(0, 1);
                                var startRow = rangeInfo[0].Substring(1, rangeInfo[0].Length - 1);
                                var endColumn = rangeInfo[1].Substring(0, 1);
                                var endRow = rangeInfo[1].Substring(1, rangeInfo[1].Length - 1);
                                Regex reg = new Regex("^[A-Z]$");
                                if (reg.IsMatch(startColumn) && reg.IsMatch(endColumn))
                                {
                                    int startColumnIndex = GetColumnIndex(startColumn), endColumnIndex = GetColumnIndex(endColumn);
                                    int startRowIndex = -1, endRowIndex = -1;
                                    for (int i = startColumnIndex; i <= endColumnIndex; i++)
                                    {
                                        dt.Columns.Add(GetColumnName(i));
                                    }

                                    if (int.TryParse(startRow, out startRowIndex) && int.TryParse(endRow, out endRowIndex))
                                    {
                                        startRowIndex--;
                                        endRowIndex--;
                                        for (int i = startRowIndex; i <= endRowIndex; i++)
                                        {
                                            var row = sheet.GetRow(i);
                                            if (row != null)
                                            {
                                                var newDr = dt.NewRow();
                                                for (int k = startColumnIndex; k <= endColumnIndex; k++)
                                                {
                                                    var cell = row.GetCell(k);
                                                    newDr[GetColumnName(k)] = Convert.ToString(cell);
                                                }
                                                dt.Rows.Add(newDr);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DeleteExcelFile(excelInfo.ExcelFilePath);
            }

            return dt;
        }


        /// <summary>
        /// 保存EXEL文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns>EXCEL的相对路径</returns>
        public string SaveExcel(HttpPostedFileBase file)
        {
            string rFilePath = string.Empty;
            try
            {
                string fileName = file.FileName;
                var index = fileName.LastIndexOf('\\');
                if (index > 0)
                {
                    fileName = fileName.Substring(index + 1);
                }

                string dirPath = GetTempExcelDir();
                rFilePath = Path.Combine(PATH_EXCEL_TEMP, string.Format("{0}_{1}", GlobalService.NewGuid(), fileName));
                string filePath = HttpContext.Current.Server.MapPath(rFilePath);
                file.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rFilePath;
        }

        /// <summary>
        /// 取EXCEL存储路径的绝对路径
        /// </summary>
        /// <returns></returns>
        private string GetTempExcelDir()
        {
            string dirPath = HttpContext.Current.Server.MapPath(PATH_EXCEL_TEMP);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            return dirPath;
        }


        /// <summary>
        /// 删除上传的EXCEL文件
        /// </summary>
        /// <param name="excelFilePath"></param>
        public void DeleteExcelFile(string excelFilePath)
        {
            try
            {
                // 删除当前EXCEL文件
                if (File.Exists(excelFilePath))
                {
                    File.Delete(excelFilePath);
                }

                // 删除存在的过期EXCEL文件
                string dirPath = GetTempExcelDir();
                string[] filePaths = Directory.GetFiles(dirPath);
                DateTime currentDt = DateTime.Now;
                foreach (var filePath in filePaths)
                {
                    if (filePath.EndsWith(".xls") || filePath.EndsWith(".xlsx"))
                    {
                        FileInfo fi = new FileInfo(filePath);
                        //if (currentDt.Subtract(fi.CreationTime).TotalDays > 1)
                        //{
                        //    File.Delete(filePath);
                        //}
                        if (currentDt.Subtract(fi.CreationTime).TotalHours > 1)
                        {
                            File.Delete(filePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private string GetColumnName(int columnIndex)
        {
            int code = (columnIndex + (int)Encoding.ASCII.GetBytes("A")[0]);
            byte[] buffer = new byte[] { (byte)code };
            return Encoding.ASCII.GetString(buffer);
        }

        private int GetColumnIndex(string column)
        {
            var cellIndex = (int)Encoding.ASCII.GetBytes(column)[0] - (int)Encoding.ASCII.GetBytes("A")[0];
            return cellIndex;
        }



        /// <summary>
        /// 导出到EXCEL
        /// </summary>
        /// <returns></returns>
        public MemoryStream ExportToExcel(DataTable dt)
        {
            try
            {
                MemoryStream ms = null;
                if (dt != null)
                {
                    string sheetName = dt.TableName;
                    IWorkbook workbook = new HSSFWorkbook();
                    ISheet sheet = workbook.CreateSheet(sheetName);

                    int startRow = 0;

                    ExportDataTable(workbook, sheet, dt, startRow);
                    AutoResizeColumn(sheet, dt.Columns.Count);

                    ms = new MemoryStream();
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    //DownloadExcelFile(ms, sheetName);

                    //return new FileStreamResult(ms, "application/vnd.ms-excel");
                    return ms;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 将DataTable数据写入到sheet中
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="dt"></param>
        /// <param name="startRow">sheet中的开始行数</param>
        private void ExportDataTable(IWorkbook workbook, ISheet sheet, DataTable dt, int startRow)
        {
            if (sheet != null)
            {
                ICellStyle headCellStyle = GetHeadCellStyle(workbook);
                int currentRowIndex = startRow;
                IRow titleRow = sheet.CreateRow(currentRowIndex++);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = titleRow.CreateCell(i);
                    cell.CellStyle = headCellStyle;
                }
                CellRangeAddress range = new CellRangeAddress(titleRow.RowNum, titleRow.RowNum, 0, dt.Columns.Count - 1);
                sheet.AddMergedRegion(range);
                titleRow.Cells[0].SetCellValue(dt.TableName);

                IRow headRow = sheet.CreateRow(currentRowIndex++);
                ICell headCell = null;
                // 列头
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string columnName = dt.Columns[i].ColumnName;
                    headCell = headRow.CreateCell(i);
                    headCell.SetCellValue(columnName);
                    headCell.CellStyle = headCellStyle;
                }

                // 内容
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    IRow row = sheet.CreateRow(currentRowIndex++);
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        string content = Convert.ToString(dr[k]);
                        ICell cell = row.CreateCell(k);
                        cell.SetCellValue(content);
                    }
                }
            }
        }



        /// <summary>
        /// 宽度自适应
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="columnCount"></param>
        private void AutoResizeColumn(ISheet sheet, int columnCount)
        {
            for (int columnNum = 0; columnNum <= columnCount; columnNum++)
            {
                int columnWidth = sheet.GetColumnWidth(columnNum) / 256;
                for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                {
                    IRow currentRow = sheet.GetRow(rowNum);
                    if (currentRow != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);

                        if (currentCell != null)
                        {
                            if (!currentCell.IsMergedCell)
                            {
                                int length = Encoding.UTF8.GetBytes(currentCell.ToString()).Length;
                                if (columnWidth < length + 1)
                                {
                                    columnWidth = length + 1;
                                }
                            }
                        }
                    }
                }
                sheet.SetColumnWidth(columnNum, columnWidth * 256);
            }
        }


        /// <summary>
        /// 表头单元格样式
        /// </summary>
        /// <param name="workbook"></param>
        /// <returns></returns>
        private ICellStyle GetHeadCellStyle(IWorkbook workbook)
        {
            ICellStyle headerCellStyle = workbook.CreateCellStyle();
            headerCellStyle.Alignment = HorizontalAlignment.Center;
            headerCellStyle.VerticalAlignment = VerticalAlignment.Center;
            headerCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            headerCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            headerCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            headerCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            return headerCellStyle;
        }

        
    }
}
