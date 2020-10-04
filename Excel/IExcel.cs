using System;
using System.Collections.Generic;
using System.Text;

namespace Excel
{
    public interface IExcel
    {
        public void GetPath(string path);

        public void CreateWB();

        bool WriteInNextVacantRow(int ColumnTitle, int ColumnContents, string Title, string Contents);

        bool ReadHistory(int ColumnTitle, int ColumnContents, List<string>TitleList, List<string>ContentList);

        void SaveHistory(int ColumnTitle, int ColumnContents, List<string> TitleList, List<string> ContentList);
    }
}
