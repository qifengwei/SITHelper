using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace SITHelper.Configuration
{
    [Serializable]
    static class ConfigContentFormatStatic
    {
        public static string TitleSavePath { get; set; } = @"Configuration\Data\Title.rtf";

        public static string ContentSavePath { get; set; } = @"Configuration\Data\Content.rtf";

        public static FlowDocument TitleInitDocument { get; set; } = new FlowDocument();

        public static FlowDocument ContentInitDocument { get; set; } = new FlowDocument();

        public static Paragraph TitleParagraph { get; set; } = new Paragraph();

        public static List<Paragraph> ContentParaList { get; set; } = new List<Paragraph>();

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
            run.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xff, 0xff, 0xff));
            TitleParagraph.Inlines.Add(title);
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
            Run run = new Run(content);
            run.FontSize = 12;
            run.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xff, 0x00, 0x00));

            Run run1 = new Run(contentAppend??" ");
            run.FontSize = 12;
            run.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xff, 0xff, 0x00));

            Bold bold = new Bold(run);
            paragraph.Inlines.Add(bold);
            paragraph.Inlines.Add(run1);

            ContentParaList.Add(paragraph);
        }

    }
}
