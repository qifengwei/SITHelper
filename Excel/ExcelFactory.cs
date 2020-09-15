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
                    return OriExcel.GetExcel();
                default:
                    return OriExcel.GetExcel();
            }
        }
    }
}
