using SITHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using SaveLog;
using System.Diagnostics;

namespace SITHelper
{
    /// <summary>
    /// UserControlRecord.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlRecord : UserControl
    {
        public UserControlRecord()
        {
            InitializeComponent();
            UserInit();
        }


        private void UserInit()
        {
            ResetTitleContent();
            GenerateLogPath();
        }

        private void GenerateLogPath()
        {
            foreach (var log in ConfigLogSave.logPaths)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = log.Name;
                checkBox.Name = log.Name;
                checkBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xb4, 0xb4, 0xb4));
                //checkBox.Visibility = Visibility.Visible;
                LogType.Children.Add(checkBox);
            }
        }

        private void CB_Fixed_Click(object sender, RoutedEventArgs e) => SetTopMost(CB_Fixed.IsChecked ?? false);

        #region function
        /// <summary>
        /// 设置window置顶状态
        /// </summary>
        /// <param name="state">是否置顶</param>
        private void SetTopMost(bool state)
        {
            var grid1 = this.Parent as Grid;
            var grid2 = grid1.Parent as Grid;
            var grid3 = grid2.Parent as Grid;
            var window = grid3.Parent as MainWindow;
            window.Topmost = state;
        }

        #endregion

        #region Submit Code
        private void RefreshContents_Click(object sender, RoutedEventArgs e)
        {
            ResetTitleContent();
        }
        private void ConfirmContent_Click(object sender, RoutedEventArgs e)
        {
            StartCopy();
            RecordInExcel();            
        }

        private void RecordInExcel()
        {
            //if (new TextRange(RTB_Content.Document.ContentStart, RTB_Content.Document.ContentEnd).Text.Length==0) MessageBox.Show("neirongkong");
            //if (new TextRange(RTB_Title.Document.ContentStart, RTB_Title.Document.ContentEnd).Text.Length == 0) MessageBox.Show("biaotikong");
            if (new TextRange(RTB_Content.Document.ContentStart, RTB_Content.Document.ContentEnd).Text.Trim().Length != 0 &&
                new TextRange(RTB_Title.Document.ContentStart, RTB_Title.Document.ContentEnd).Text.Trim().Length != 0)
            {
                string titleText = new TextRange(RTB_Title.Document.ContentStart, RTB_Title.Document.ContentEnd).Text;
                string contentText = new TextRange(RTB_Content.Document.ContentStart, RTB_Content.Document.ContentEnd).Text;
                var instance = Excel.ExcelFactory.GetExcel();
                instance.WriteInNextVacantRow(CharToIntColumnName(ConfigExcelFormat.TitleColumn), CharToIntColumnName(ConfigExcelFormat.ContentColumn), titleText, contentText) ;
                ResetTitleContent();
            }
            else 
            {
                MessageBox.Show("Title or Content is Empty");
            }
        }

        private int CharToIntColumnName(char charColumn)=> (int)charColumn - 65;

        private void ResetTitleContent()
        {
            if(RTB_Title!=null && RTB_Content != null) {
            TextRange textRange1 = new TextRange(RTB_Title.Document.ContentStart, RTB_Title.Document.ContentEnd);
            LoadRTFFile(ref textRange1, ConfigContentFormat.TitleSavePath);
            TextRange textRange2 = new TextRange(RTB_Content.Document.ContentStart, RTB_Content.Document.ContentEnd);
            LoadRTFFile(ref textRange2, ConfigContentFormat.ContentSavePath);
            }
        }

        private void LoadRTFFile(ref TextRange textRange, string path)
        {
            if (String.IsNullOrEmpty(path)) throw new ArgumentNullException();
            else if (!File.Exists(path)) throw new FileNotFoundException();
            else 
            {
                using (FileStream file = File.OpenRead(path))
                {
                    textRange.Load(file, DataFormats.Rtf);
                }
            }
        }
        #endregion

        #region copyLog

        private void StartCopy()
        {
            DateTime startTime = OccurTime.DateTime.AddSeconds(-1.0 * int.Parse(TB_Previous.Text));
            DateTime endTime = OccurTime.DateTime.AddSeconds(int.Parse(TB_Later.Text));

            for (int i = 0; i < LogType.Children.Count; i++)
            {               
                CheckBox checkBox = (CheckBox)LogType.Children[i];

                var find = from path in ConfigLogSave.logPaths
                           where path.Name == checkBox.Name
                           select path;
                string sourcePath = find.ToList()[0].SourcePath;

                string title = new TextRange(RTB_Title.Document.ContentStart, RTB_Title.Document.ContentEnd).Text.Replace(ConfigContentFormat.Title, "").Trim();

                string targetPath = System.IO.Path.Combine(WorkPath.DefalutWorkPath, title, find.ToList()[0].TargetPath);

                string zipName = $"{find.ToList()[0].Name}.zip";

                if (checkBox.IsChecked == true)
                {
                    SaveLogFactory.GetInstance().CopyLog(sourcePath, targetPath, zipName, startTime, endTime);
                }
            }
        }


        #endregion

        private void OpenWorkPath_Click(object sender, RoutedEventArgs e)
        {
            using (Process process = new Process())
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = WorkPath.DefalutWorkPath;
                process.Start();
            }
        }
    }
}
