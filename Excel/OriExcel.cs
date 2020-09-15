using System;

namespace Excel
{
    public class OriExcel:IExcel
    {
        private static OriExcel instance;

        private OriExcel() { }

        public static OriExcel GetExcel() => instance;
    }
}
