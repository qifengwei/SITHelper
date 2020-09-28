using SITHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SITHelper.Configuration
{
    public static class ConfigLogSave
    {
        public static ObservableCollection<LogPathStruct> logPaths { get; set; } = new ObservableCollection<LogPathStruct>();

        public static void Save()
        {
            XElement element = new XElement("LogPath");
            foreach (var logPath in logPaths)
            {
                XElement subEle = new XElement(logPath.Name,
                    new XElement("SourcePath", logPath.SourcePath),
                    new XElement("TargetPath", logPath.TargetPath));
                element.Add(subEle);
            }
            if (!Directory.Exists(WorkPath.ConfigrationPath)) Directory.CreateDirectory(WorkPath.ConfigrationPath);
            element.Save(Path.Combine(WorkPath.ConfigrationPath, WorkPath.ConfigLogSaveFilePath));
        }

        public static void Load()
        {
            if (!File.Exists(Path.Combine(WorkPath.ConfigrationPath, WorkPath.ConfigLogSaveFilePath))) Save();
            else
            {
                XElement element = XElement.Load(Path.Combine(WorkPath.ConfigrationPath, WorkPath.ConfigLogSaveFilePath));
                logPaths = new ObservableCollection<LogPathStruct>();
                foreach (var logPath in element.Elements())
                {

                    logPaths.Add(new LogPathStruct()
                    {
                        SourcePath = logPath.XPathSelectElement("SourcePath").Value,
                        TargetPath = logPath.XPathSelectElement("TargetPath").Value,
                        Name = logPath.Name.LocalName
                    });
                }
            }
        }
    }
}
