using SITHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //UserControl
        private UserControl uCRecord;
        private UserControl uCSetting;
        private UserControl uCHistory;

        public MainWindow()
        {
            CallSetPathWindow();
            InitializeComponent();
            InitConfiguration();
            InitUserRecord();
        }

        private void InitUserRecord()
        {
            uCRecord = new UserControlRecord();
            uCSetting = new UserControlSetting();
            uCHistory = new UserControlHistory();
        }

        private void InitConfiguration()
        {

            //Init ExcelFormat
            if (!File.Exists(System.IO.Path.Combine(WorkPath.ConfigrationPath, WorkPath.ConfigExcelFormatSaveFilePath)))
            {
                ConfigExcelFormat.TitleColumn = 'A';
                ConfigExcelFormat.ContentColumn = 'B';
                ConfigExcelFormat.Save();
            }
            else
            {
                ConfigExcelFormat.Load();
            }


            //Init ContentFormat
            ConfigContentFormat.SetTitle("【SIT】");

            ConfigContentFormat.ContentParaList.Clear();
            ConfigContentFormat.AddContentParagraph("版本:", "123213");
            ConfigContentFormat.AddContentParagraph("描述:", null);
            ConfigContentFormat.AddContentParagraph("复现:", "Yes");
            ConfigContentFormat.AddContentParagraph("描述人:", " ");
            ConfigContentFormat.SetContent();


        }

        private void CallSetPathWindow()
        {
            SetPathWindow setPathWindow = new SetPathWindow();
            setPathWindow.ShowDialog();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
            }
            catch
            { }
            
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //Set Tooltips Visibility
            if (tg_btn.IsChecked == true)
            {
                tt_record.Visibility = Visibility.Collapsed;
                tt_setting.Visibility = Visibility.Collapsed;
                tt_close.Visibility = Visibility.Collapsed;
                tt_history.Visibility = Visibility.Collapsed;
            }
            else 
            {
                tt_record.Visibility = Visibility.Visible;
                tt_setting.Visibility = Visibility.Visible;
                tt_close.Visibility = Visibility.Visible;
                tt_history.Visibility = Visibility.Visible;
            }
        }

        private void tg_btn_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "LVI_Record":
                    GridMain.Children.Add(uCRecord);
                    break;
                case "LVI_Setting":
                    GridMain.Children.Add(uCSetting);
                    break;
                case "LVI_History":
                    GridMain.Children.Add(uCHistory);
                    break;
                case "LVI_Close":
                    Exit();
                    break;
            }
        }

        private void Exit()
        {
            this.Close();
        }

        private void nav_pnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
        }
    }
}
