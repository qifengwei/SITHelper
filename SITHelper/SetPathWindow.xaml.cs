using Excel;
using Microsoft.Win32;
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
                //打开原有文件(IExcel.GetPath())
                throw new NotImplementedException();
            }
            else 
            {
                if (!(System.IO.Path.GetExtension(TB_Excel_Path.Text) == ".xlsx"))
                {
                    MessageBox.Show("The file path is not a valid Excel file");
                    return;
                }
                try
                {
                    using (FileStream fs = File.Create(TB_Excel_Path.Text))
                    {
                    }
                    //打开原有文件(IExcel.GetPath())
                    throw new NotImplementedException();
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
    }
}
