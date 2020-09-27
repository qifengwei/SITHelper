using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;

namespace Excel
{
    public class ExcelBase : IExcel
    {
        private string excelPath;

        private static ExcelBase instance = new ExcelBase();

        private static String WorkSheetName = "问题列表";

        private ExcelBase() { }

        public static ExcelBase GetExcel() => instance;

        public void GetPath(string path)
        {
            excelPath = path;
            if (File.Exists(excelPath))
            {
                CreateTable();
            }
            else 
            {
                CreateWB();
            }
        }

        public void CreateWB()
        {
            IWorkbook workbook = new XSSFWorkbook();
            SaveExcel(workbook);
            CreateTable();
        }

        private void CreateTable()
        {
            IWorkbook workbook;
            using (var stream = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
            {
                workbook = WorkbookFactory.Create(excelPath);
                if (workbook.GetSheet(WorkSheetName) == null)
                {
                    ISheet sheet = workbook.CreateSheet(WorkSheetName);
                }
            }

            SaveExcel(workbook);

        }

        public bool WriteInNextVacantRow(int ColumnTitle, int ColumnContents, string Title, string Contents)
        {
            IWorkbook workbook = OpenWB();
            WriteInNPOINextVacantRow(ColumnTitle, ColumnContents, Title, Contents, ref workbook);
            SaveExcel(workbook);
            return true;

        }

        private void WriteInNPOINextVacantRow(int ColumnTitle, int ColumnContents, string Title, string Contents, ref IWorkbook wb)
        {
            ISheet sheet = wb.GetSheet(WorkSheetName);
            sheet.SetColumnWidth(ColumnTitle, 25 * 256);
            sheet.SetColumnWidth(ColumnContents, 50 * 256);
            int rowNum = sheet.LastRowNum + 1;
            IRow row = sheet.CreateRow(rowNum);
            ICell cellTitle = row.CreateCell(ColumnTitle);
            ICell cellContent = row.CreateCell(ColumnContents);

            ICellStyle cellStyle = wb.CreateCellStyle();
            cellStyle.WrapText = true;
            cellTitle.CellStyle = cellStyle;
            cellContent.CellStyle = cellStyle;

            cellTitle.SetCellValue(Title.Trim());
            cellContent.SetCellValue(Contents.Trim());
        }

        private IWorkbook OpenWB()
        {
            using (var stream = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
            {
                return WorkbookFactory.Create(excelPath);
            }
        }

        private void SaveExcel(IWorkbook wb)
        {
            using (FileStream fs = new FileStream(excelPath, FileMode.Create))
            {
                wb.Write(fs);
            }
        }

        public void ReadHistory(int columnTitle, int columnContents, List<string> titleList, List<string> contentList)
        {
            //List<string> contentList = new List<string>();
            IWorkbook workbook = OpenWB();
            ISheet worksheet = workbook.GetSheet(WorkSheetName);
            for(int i = 1; i<=worksheet.LastRowNum;i++)
            {
                titleList.Add(worksheet.GetRow(i).GetCell(columnTitle).StringCellValue);
                contentList.Add(worksheet.GetRow(i).GetCell(columnContents).StringCellValue);
            }
        }
    }
}
