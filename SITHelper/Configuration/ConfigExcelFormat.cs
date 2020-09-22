﻿using System;
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

        public static ObservableCollection<char> ColumnName { get; set; }

        static ConfigExcelFormat()
        {
            ColumnName = new ObservableCollection<char>
            {
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };
        }
    }
}
