using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SITHelper.Configuration
{
    [Serializable]
    public static class ConfigExcelFormat
    {
        public static char TitleColumn { get; set; }

        public static char ContentColumn { get; set; }

    }
}
