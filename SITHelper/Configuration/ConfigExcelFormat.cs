using System;
using System.Collections.Generic;
using System.Text;

namespace SITHelper.Configuration
{
    [Serializable]
    public class ConfigExcelFormat
    {
        public int TitleColumn { get; set; }

        public int ContentColumn { get; set; }
    }
}
