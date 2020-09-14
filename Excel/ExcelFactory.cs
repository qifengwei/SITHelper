using System;
using System.Collections.Generic;
using System.Text;

namespace Excel
{
    public class ExcelFactory
    {
        public IExcel GetExcel(string excelType)
        {
            switch (excelType.ToLower())
            {
                case "original":
                    return new Excel();
                default:
                    return new Excel();
            }
        }
    }
}
