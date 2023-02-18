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
using System.Windows.Shapes;
using 监狱AB门WPF.Common.Model;

namespace 监狱AB门WPF.Views
{
    /// <summary>
    /// ExternalPersonDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class ExternalPersonDetailView : Window
    {
        public ExternalPersonInfo externalPersonInfo { get; set; }
        public ExternalPersonDetailView(ExternalPersonInfo externalPersonInfo)
        {
            this.externalPersonInfo = externalPersonInfo;
            InitializeComponent();
            this.DataContext = externalPersonInfo;

        }
    }
}
