using SITHelper.Configuration;
using System;
using System.Collections.Generic;
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
                instance.WriteInNextVacantRow(ConfigExcelFormat.TitleColumn, ConfigExcelFormat.ContentColumn, titleText, contentText) ;
                ResetTitleContent();
            }
            else 
            {
                MessageBox.Show("Title or Content is Empty");
            }
        }

        private void ResetTitleContent()
        {
            RTB_Content.Document = new FlowDocument();
            RTB_Title.Document = new FlowDocument();
        }
        #endregion


    }
}
