using Excel;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace SITHelper
{
    /// <summary>
    /// SetPathWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SetPathWindow : Window
    {
        public SetPathWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
        }

        private void Bt_OpenFileDlg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Microsoft Excel 工作表|*.xlsx;*.xls";
            Nullable<bool> result = fileDialog.ShowDialog();
            if (result == true)
            {
                TB_Excel_Path.Text = fileDialog.FileName;
            }
        }

        private void Bt_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Bt_Apply_Click(object sender, RoutedEventArgs e)
        {
            IExcel excel = ExcelFactory.GetExcel();
            if (!System.IO.File.Exists(TB_Excel_Path.Text))
            {
                excel.CreateExcel(TB_Excel_Path.Text);
            }
            else
            {
                excel.OpenExcel(TB_Excel_Path.Text);
            }    
            this.Close();
        }
    }
}
