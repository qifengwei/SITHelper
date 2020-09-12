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
    /// UserControlRecord.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlRecord : UserControl
    {
        public UserControlRecord()
        {
            InitializeComponent();
        }

        private void Bt_Fixed_Click(object sender, RoutedEventArgs e)
        {
            var window = this.Parent as MainWindow;
            var brush = new ImageBrush();
            if (window.Topmost == true)
            {
                window.Topmost = false;
                brush.ImageSource = new BitmapImage(new Uri("Assets\\unfixed.png"));
                Bt_Fixed.Background = brush;
            }
            else 
            {
                window.Topmost = true;
                brush.ImageSource = new BitmapImage(new Uri("Assets\\fixed.png"));
                Bt_Fixed.Background = brush;
            }
            
        }
    }
}
