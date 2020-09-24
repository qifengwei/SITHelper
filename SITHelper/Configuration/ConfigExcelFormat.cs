using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SITHelper.Configuration
{
    public static class ConfigExcelFormat
    {
        public static char TitleColumn { get; set; }

        public static char ContentColumn { get; set; }

        public static void Save()
        {
            XElement element =
                new XElement("ExcelFormat",
                    new XElement("Title", TitleColumn),
                    new XElement("Content", ContentColumn)
                );
            if (!Directory.Exists(WorkPath.ConfigrationPath)) Directory.CreateDirectory(WorkPath.ConfigrationPath);
            element.Save(Path.Combine(WorkPath.ConfigrationPath, WorkPath.ConfigExcelFormatSaveFilePath));
            
        }

        public static void Load()
        {
            XElement element = XElement.Load(Path.Combine(WorkPath.ConfigrationPath, WorkPath.ConfigExcelFormatSaveFilePath));
            XElement title = element.XPathSelectElement("Title");
            XElement content = element.XPathSelectElement("Content");
            TitleColumn = char.Parse(title.Value);
            ContentColumn = char.Parse(content.Value);
        }

    }
}
