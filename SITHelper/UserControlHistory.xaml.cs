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
            Histories.Add(new HistoryGridModel() { Title = "123asdasd 萨达沙发沙发沙发按时发士大夫敢死队风格但是东莞市东莞市豆腐干豆腐干豆腐干豆腐干地方豆腐干地方法规", Description = "234" });
        }
    }
}
