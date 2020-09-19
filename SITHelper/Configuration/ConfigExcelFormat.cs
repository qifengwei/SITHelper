using System;
using System.Collections.Generic;
using System.Text;

namespace SITHelper.Configuration
{
    [Serializable]
    public static class ConfigExcelFormat
    {
        public static int TitleColumn { get; set; }

        public static int ContentColumn { get; set; }
    }
}
