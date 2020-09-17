using System;
using System.Collections.Generic;
using System.Text;

namespace Excel
{
    public interface IExcel
    {
        public void OpenExcel();

        public void OpenExcel(string path);

        public void CreateExcel(string path);

        public void CreateNewExcel();       

        public void WriteContent(int row, int col, string content);

        public void WriteContentNextVacantRow(string content);

        public void WriteContentNextVacantRow(int col, string content);

        public void WriteContentNextVacantRow(Dictionary<int, string> content);

        public void SaveFile();

        public void SaveAs(string path);

        public void CloseWithSave();

        public void CloseWithSaveAs();

        public void CloseWithoutSave();
    }
}
