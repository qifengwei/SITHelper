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
            if (!System.IO.File.Exists(TB_Excel_Path.Text))
            {
                //打开原有文件
            }
            else if (1==1)
            {
                
            }
            else
            {
                TB_Excel_Path.Text = "";
                return;
            }
            this.Close();
        }

        private void TB_Excel_Path_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TB_Work_Path.Text = TB_Excel_Path.Text;
            TB_Work_Path.Text = System.IO.Path.GetDirectoryName(TB_Excel_Path.Text);
        }

        private void TB_Excel_Path_LostFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("show");
        }
    }
}
