using System;
using System.Collections.Generic;
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
        private UserControl uCRecord;
        private UserControl uCSetting;
        public MainWindow()
        {
            InitializeComponent();
            InitUserRecord();
        }

        private void InitUserRecord()
        {
            uCRecord = new UserControlRecord();
            uCSetting = new UserControlSetting();
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
            }
            else 
            {
                tt_record.Visibility = Visibility.Visible;
                tt_setting.Visibility = Visibility.Visible;
                tt_close.Visibility = Visibility.Visible;
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
            }
        }

        private void nav_pnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
        }
    }
}
