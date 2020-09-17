using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Excel
{
    public class OriExcel:IExcel
    {
        private IWorkbook workbook;

        private ISheet sheet;

        public string SavedPath { get; set; }

        private static OriExcel instance = new OriExcel();

        private OriExcel() 
        {
            workbook = new XSSFWorkbook();
        }

        public static OriExcel GetExcel() => instance;

        public void CloseWithoutSave()
        {
            throw new NotImplementedException();
        }

        public void CloseWithSave()
        {
            FileStream stream = File.Create(SavedPath);
            workbook.Write(stream);
            stream.Close();
        }

        public void CloseWithSaveAs()
        {
            throw new NotImplementedException();
        }

        public void CreateNewExcel()
        {
            throw new NotImplementedException();
        }

        public void OpenExcel()
        {
            throw new NotImplementedException();
        }

        public void OpenExcel(string path)
        {
            throw new NotImplementedException();
        }

        public void CreateExcel(string path)
        {
            SavedPath = path;
            sheet = workbook.CreateSheet("问题列表");
        }

        public void SaveAs(string path)
        {
            throw new NotImplementedException();
        }

        public void SaveFile()
        {
            
        }

        public void WriteContent(int row, int col, string content)
        {
            throw new NotImplementedException();
        }

        public void WriteContentNextVacantRow(string content)
        {
            throw new NotImplementedException();
        }

        public void WriteContentNextVacantRow(int col, string content)
        {
            sheet.CreateRow(2).CreateCell(col).SetCellValue(content);
        }

        public void WriteContentNextVacantRow(Dictionary<int, string> content)
        {
            throw new NotImplementedException();
        }
    }
}
