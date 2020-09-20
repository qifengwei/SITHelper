using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;

namespace SITHelper.Configuration
{
    [Serializable]
    public class ConfigContentFormat
    {
        public FlowDocument TitleInitDocument { get; set; } = new FlowDocument();

        public FlowDocument ContentInitDocument { get; set; } = new FlowDocument();

        public Paragraph TitleParagraph { get; set; } = new Paragraph();

        public List<Paragraph> ContentParaList { get; set; } = new List<Paragraph>();

        public void SetTitle(string title)
        {
            TitleParagraph.Inlines.Clear();
            TitleInitDocument.Blocks.Clear();
            Run run = new Run(title);
            run.FontSize = 18;
            run.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xb4, 0xb4, 0xb4));
            TitleParagraph.Inlines.Add(title);
            TitleInitDocument.Blocks.Add(TitleParagraph);
        }

        public void SetContent()
        {
            ContentInitDocument.Blocks.Clear();
            ContentInitDocument.Blocks.AddRange(ContentParaList);
        }

        public void AddContentParagraph(string content, string? contentAppend)
        {
            Paragraph paragraph = new Paragraph();
            Run run = new Run(content);
            run.FontSize = 12;
            run.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xb4, 0xb4, 0xb4));

            Run run1 = new Run(contentAppend ?? "");
            run.FontSize = 12;
            run.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xb4, 0xb4, 0xb4));

            Bold bold = new Bold(run);
            paragraph.Inlines.Add(bold);
            paragraph.Inlines.Add(run1);

            ContentParaList.Add(paragraph);
        }
    }
}
