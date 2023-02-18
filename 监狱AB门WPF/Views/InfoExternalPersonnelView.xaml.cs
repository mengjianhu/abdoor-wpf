using Panuon.WPF.UI;
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
using 监狱AB门WPF.Common.Model;

namespace 监狱AB门WPF.Views
{
    /// <summary>
    /// InfoExternalPersonnelView.xaml 的交互逻辑
    /// </summary>
    public partial class InfoExternalPersonnelView : UserControl
    {
        //IPendingHandler pending = null;
        public InfoExternalPersonnelView()
        {    
            InitializeComponent();
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //pending = PendingBox.Show("正在加载中");
            Console.WriteLine("渲染完成");
            //pending.Close();
        }
        
    }
}
