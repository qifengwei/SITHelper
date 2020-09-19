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
            using (var stream = File.OpenRead(excelPath))
            {
                workbook = new XSSFWorkbook(stream);
                if (workbook.GetSheet("问题列表") == null)
                {
                    workbook.CreateSheet("问题列表");
                }
            }
            SaveExcel(workbook);

        }

        public bool WriteInNextVacantRow(int ColumnTitle, int ColumnContents, string Title, string Contents)
        {
            throw new NotImplementedException();
        }

        private void SaveExcel(IWorkbook wb)
        {
            using (FileStream fs = new FileStream(excelPath, FileMode.Create))
            {
                wb.Write(fs);
            }
        }
    }
}
