using Excel;
using Microsoft.Win32;
using SITHelper.Configuration;
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
            if (System.IO.File.Exists(TB_Excel_Path.Text))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(TB_Excel_Path.Text)) { }
                }
                catch (IOException)
                {
                    MessageBox.Show("The file is opened by another application");
                    return;
                }
                var instance = ExcelFactory.GetExcel();
                instance.GetPath(TB_Excel_Path.Text);
            }
            else 
            {
                if (!Directory.Exists(TB_Work_Path.Text)) Directory.CreateDirectory(TB_Work_Path.Text);
                if (!(System.IO.Path.GetExtension(TB_Excel_Path.Text) == ".xlsx"))
                {
                    MessageBox.Show("The file path is not a valid Excel file");
                    return;
                }
                try
                {                  
                    var instance = ExcelFactory.GetExcel();
                    instance.GetPath(TB_Excel_Path.Text);
                }
                catch (DirectoryNotFoundException err)
                {
                    MessageBox.Show($"Can't create excel at {TB_Excel_Path.Text}, {err.Message}");
                    return;
                }
                catch (NotSupportedException err)
                {
                    MessageBox.Show($"The format for path is invalid, {err.Message}");
                    return;
                }
                catch (Exception err)
                {
                    MessageBox.Show($"{err.Message}");
                    return;
                }
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

        private void Bt_AutoGenerate_Click(object sender, RoutedEventArgs e)
        {
            TB_Excel_Path.Text = System.IO.Path.GetFullPath(System.IO.Path.Combine(WorkPath.DefalutWorkPath, $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx"));
        }
    }
}
