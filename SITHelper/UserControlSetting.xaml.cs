using SITHelper.Configuration;
using System;
using System.Collections.Generic;
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
    /// UserControlSetting.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlSetting : UserControl
    {
        public UserControlSetting()
        {
            InitializeComponent();
        }

        private void Save_Location_Excel_Click(object sender, RoutedEventArgs e)
        {
            Save_Location_Excel.Visibility = Visibility.Hidden;
            ConfigExcelFormat.TitleColumn = (char)CB_TitleColumn.SelectedItem;
            ConfigExcelFormat.ContentColumn = (char)CB_DescriptionColumn.SelectedItem;
        }
    }
}
