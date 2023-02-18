using Rubyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using 智能AB门WPF.Common.Model;
using 监狱AB门WPF.Common;
using 监狱AB门WPF.Common.Model;

namespace 监狱AB门WPF.Views
{
    /// <summary>
    /// RecordQueryDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class RecordQueryDetailView : Window
    {
        public DeviceHyPersonDetail personInfo { get; set; }
        public DeviceHyPersonDetail personInfo1 { get; set; }
        public RecordQueryDetailView(DeviceHyPersonDetail DeviceHyPersonDetail)
        {
            this.personInfo = personInfo;
            //if (personInfo != null)
            //{
            //    this.personInfo1 = new PersonInfo()//旧的
            //    {
            //        name = personInfo.name,
                  
                   
            //    };
            //}
            this.DataContext = this;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (personInfo != null && personInfo1 != null)
            //{
            //    if (CompareHelper.CompareType<PersonInfo>(personInfo, personInfo1))
            //    {
            //        Notification.WarningGlobal("您并未修改任何东西");
            //        return;
                   
            //    }
            //    else
            //    {
            //        //重新赋值
            //        Message.SuccessGlobal("修改成功");
            //        personInfo1.name = personInfo.name;
            //        personInfo1.sex = personInfo.sex;
            //        personInfo1.bh = personInfo.bh;
            //        personInfo1.phone = personInfo.phone;
                    
            //    }
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //if (personInfo != null)
            //{
            //    if (personInfo.name == personInfo1.name)
            //    {
            //        if (false)
            //        {
            //            personInfo.phone = personInfo1.phone;
            //        }
            //    }
            //}
        }
    }
}
