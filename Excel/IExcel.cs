using System;
using System.Collections.Generic;
using System.Text;

namespace Excel
{
    public interface IExcel
    {
        public void OpenExcel();

        public void CreateNewExcel();

        public void WriteContent();
    }
}
