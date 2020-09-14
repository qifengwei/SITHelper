using System;
using System.Collections.Generic;
using System.IO;
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

        private void CB_Fixed_Checked(object sender, RoutedEventArgs e)
        {
            IsTopMost(CB_Fixed.IsChecked??false);
        }

        private void IsTopMost(bool state)
        {
            var grid1 = this.Parent as Grid;
            var grid2 = grid1.Parent as Grid;
            var grid3 = grid2.Parent as Grid;
            var window = grid3.Parent as MainWindow;
            window.Topmost = state;
        }
    }
}
