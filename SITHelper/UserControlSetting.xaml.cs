using SITHelper.Configuration;
using SITHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
            //Description_Format_Data.DataContext = ConfigContentFormat.ContentFormatModels;
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

        private void Save_Description_Format_Click(object sender, RoutedEventArgs e)
        {
            Save_Description_Format.IsEnabled = false;
            ConfigContentFormat.SaveContent();
            ConfigContentFormat.Packaging();
            if (Save_Location_Excel_State != null) Save_Description_Format_State.Visibility = Visibility.Visible;
        }

        private void Description_Format_Data_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (Save_Description_Format != null) Save_Description_Format.IsEnabled = true;
            if (Save_Description_Format_State != null) Save_Description_Format_State.Visibility = Visibility.Hidden;
        }

        private void Save_Title_Format_Click(object sender, RoutedEventArgs e)
        {
            Save_Title_Format.IsEnabled = false;
            ConfigContentFormat.Title = Default_Title.Text;
            ConfigContentFormat.SaveTitle();
            ConfigContentFormat.Packaging();
            if (Save_Title_Format_State != null) Save_Title_Format_State.Visibility = Visibility.Visible;
        }

        private void Default_Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Save_Description_Format != null) Save_Title_Format.IsEnabled = true;
            if (Save_Description_Format_State != null) Save_Title_Format_State.Visibility = Visibility.Hidden;
        }

        private void LogPathGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if(Save_LogPath!=null) Save_LogPath.IsEnabled = true;
            if (Save_LogPath_State != null) Save_LogPath_State.Visibility = Visibility.Hidden;
        }

        private void Save_LogPath_Click(object sender, RoutedEventArgs e)
        {
            Save_LogPath.IsEnabled = false;
            ConfigLogSave.Save();
            if (Save_LogPath_State != null) Save_LogPath_State.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileSelector.FolderSelector folder = new FileSelector.FolderSelector();
            var result = folder.ShowDialog();
            if (result??false)
            {
                DataRowView row = (DataRowView)LogPathGrid.SelectedItem;
                if (row != null)
                {
                    (row[2]) = folder.SelectedPath;
                }
            }
        }
    }
}
