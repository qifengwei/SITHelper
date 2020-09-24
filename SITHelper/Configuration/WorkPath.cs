using System;
using System.Collections.Generic;
using System.Text;

namespace SITHelper.Configuration
{
    public static class WorkPath
    {
        public static string DefalutWorkPath { get; set; } = @"WorkPath";

        public static string ConfigrationPath { get; set; } = @"AppData\Configrations";

        public static string ConfigExcelFormatSaveFilePath { get; set; } = @"ExcelFormat.xml";

        public static void WriteXML(object e, string path)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(e.GetType());
            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file, e);
            file.Close();
        }
    }
}
