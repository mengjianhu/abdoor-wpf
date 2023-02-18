using Rubyer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 监狱AB门WPF.Views
{
    /// <summary>
    /// SeetingView.xaml 的交互逻辑
    /// </summary>
    public partial class SeetingView : Window
    {
        public SeetingView()
        {
            InitializeComponent();
            txt_ip.Text = App.appUrl;
           // this.DataContext = this;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Execute();
        }
        private async void Execute()
        {
            if (!string.IsNullOrEmpty(txt_ip.Text))
            {
                await File.WriteAllTextAsync("seeting.txt", txt_ip.Text.Trim());
                App.appUrl = txt_ip.Text.Trim();
                Message.SuccessGlobal("保存成功");
            }
        }
    }
}
