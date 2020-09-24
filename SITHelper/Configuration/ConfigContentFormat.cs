using SITHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SITHelper.Configuration
{
    public static class ConfigContentFormat
    {
        public static string TitleSavePath { get; set; } = @"Configuration\Data\Title.rtf";

        public static string ContentSavePath { get; set; } = @"Configuration\Data\Content.rtf";

        public static FlowDocument TitleInitDocument { get; set; } = new FlowDocument();

        public static FlowDocument ContentInitDocument { get; set; } = new FlowDocument();

        public static Paragraph TitleParagraph { get; set; } = new Paragraph();

        public static List<Paragraph> ContentParaList { get; set; } = new List<Paragraph>();

        public static ObservableCollection<ContentFormatModel> ContentFormatModels = new ObservableCollection<ContentFormatModel>();

        private static void SaveFlowDocumentToRTF(FlowDocument doc, string path)
        {
            var content = new TextRange(doc.ContentStart, doc.ContentEnd);
            if (content.CanSave(DataFormats.Rtf))
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
                using (var stream = File.Create(path))
                {
                    content.Save(stream, DataFormats.Rtf);
                }
            }
        }

        public static void SetTitle(string title) 
        {
            TitleParagraph.Inlines.Clear();
            TitleInitDocument.Blocks.Clear();
            Run run = new Run(title);
            run.FontSize = 18;
            run.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xdf, 0xdf, 0xdf));
            TitleParagraph.Inlines.Add(run);
            TitleInitDocument.Blocks.Add(TitleParagraph);
            SaveFlowDocumentToRTF(TitleInitDocument, TitleSavePath);

        }

        public static void SetContent()
        {
            ContentInitDocument.Blocks.Clear();           
            ContentInitDocument.Blocks.AddRange(ContentParaList);
            SaveFlowDocumentToRTF(ContentInitDocument, ContentSavePath);
        }

        public static void AddContentParagraph(string content, string? contentAppend)
        {
            Paragraph paragraph = new Paragraph();
            Run run1 = new Run(content);
            run1.FontSize = 12;
            run1.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xff, 0xff, 0x00));

            Run run2 = new Run(contentAppend??" ");
            run2.FontSize = 12;
            run2.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xd0, 0xd0, 0xd0));

            Bold bold = new Bold(run1);
            paragraph.Inlines.Add(bold);
            paragraph.Inlines.Add(run2);

            ContentParaList.Add(paragraph);
        }

        public static void Save()
        {
            if (!Directory.Exists(WorkPath.ConfigrationPath)) Directory.CreateDirectory(WorkPath.ConfigrationPath);
            XElement root = new XElement("ContentFormat");
            foreach (var item in ContentFormatModels)
            {
                XElement xItem = new XElement("Item",
                    new XElement("Host", item.Host),
                    new XElement("Slave", item.Slave));
                root.Add(xItem);
            }
            root.Save(Path.Combine(WorkPath.ConfigrationPath, WorkPath.ConfigContentFormatSaveFilePath));
        }

        public static void Load()
        {
            if (!File.Exists(Path.Combine(WorkPath.ConfigrationPath, WorkPath.ConfigContentFormatSaveFilePath))) return;
            XElement root = XElement.Load(Path.Combine(WorkPath.ConfigrationPath, WorkPath.ConfigContentFormatSaveFilePath));
            var items = root.XPathSelectElements("Item");
            ContentFormatModels.Clear();
            foreach (var item in items)
            {
                ContentFormatModels.Add(new ContentFormatModel() { Host = item.XPathSelectElement("Host").Value, Slave = item.XPathSelectElement("Slave").Value });
            }
        }

    }
}
