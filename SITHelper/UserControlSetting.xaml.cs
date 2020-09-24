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
    /// UserControlSetting.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlSetting : UserControl
    {
        public UserControlSetting()
        {
            InitializeComponent();
            ObservableCollection<ContentFormatModel> contentFormatData = ContentFormatModel.GetObservableCollection();
            Description_Format_Data.DataContext = contentFormatData;
        }

        private void Save_Location_Excel_Click(object sender, RoutedEventArgs e)
        {
            Save_Location_Excel.IsEnabled = false;
            ConfigExcelFormat.TitleColumn = (char)CB_TitleColumn.SelectedItem;
            ConfigExcelFormat.ContentColumn = (char)CB_DescriptionColumn.SelectedItem;
            ConfigExcelFormat.Save();
            if (Save_Location_Excel_State != null) Save_Location_Excel_State.Visibility = Visibility.Visible;
        }

        private void ComboItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Save_Location_Excel!=null)Save_Location_Excel.IsEnabled = true;
            if (Save_Location_Excel_State != null) Save_Location_Excel_State.Visibility = Visibility.Hidden;
        }
    }
}
