using System;
using System.Collections.Generic;
using System.Text;

namespace Excel
{
    public class ExcelFactory
    {
        public static IExcel GetExcel(string excelType="original")
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
