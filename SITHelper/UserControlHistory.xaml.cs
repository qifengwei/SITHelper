﻿using Excel;
using SITHelper.Configuration;
using SITHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
    /// UserControlHistory.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlHistory : UserControl
    {
        public static ObservableCollection<HistoryGridModel> Histories { get; set; } = new ObservableCollection<HistoryGridModel>();
        public UserControlHistory()
        {
            InitializeComponent();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Histories = new ObservableCollection<HistoryGridModel>();
            List<string> titleList = new List<string>();
            List<string> contentList = new List<string>();
            var instance = ExcelFactory.GetExcel();
            instance.ReadHistory(CharToIntColumnName(ConfigExcelFormat.TitleColumn), CharToIntColumnName(ConfigExcelFormat.ContentColumn), titleList, contentList);
            for (int i = 0; i < titleList.Count; i++)
            {
                Histories.Add(new HistoryGridModel() { Title = titleList[i], Description = contentList[i] });
            }
            ((System.Windows.Controls.Grid)this.Parent).Children.Add(new UserControlHistory());
        }

        private int CharToIntColumnName(char charColumn) => (int)charColumn - 65;

        private void HistoryGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Apply.IsEnabled = true;
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
#if DEBUG
            List<string> titleList = new List<string>();
            List<string> contentList = new List<string>();
            foreach (var item in Histories)
            {
                titleList.Add(item.Title);
                contentList.Add(item.Description);
            }
            IExcel excel = ExcelFactory.GetExcel();
            excel.SaveHistory(CharToIntColumnName(ConfigExcelFormat.TitleColumn), CharToIntColumnName(ConfigExcelFormat.ContentColumn), titleList, contentList);
#endif
        }
    }
}
