using System;

namespace Excel
{
    public class OriExcel:IExcel
    {
        private static OriExcel instance = new OriExcel();

        private OriExcel() { }

        public static OriExcel GetExcel() => instance;

        public void CreateNewExcel()
        {
            throw new NotImplementedException();
        }

        public void OpenExcel()
        {
            throw new NotImplementedException();
        }

        public void WriteContent()
        {
            throw new NotImplementedException();
        }
    }
}
