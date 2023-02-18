using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 监狱AB门WPF.Common;
using 监狱AB门WPF.Common.Model;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  DailyDutyView
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/12/1 10:04:51
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/12/1 10:04:51
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.ViewModels
{
    public class DailyDutyViewModel : NavigationViewModel
    {
        private ObservableCollection<ExternalPersonInfo> _dailyPersonInfos;

        public ObservableCollection<ExternalPersonInfo> dailyPersonInfos
        {
            get { return _dailyPersonInfos; }
            set { _dailyPersonInfos = value; RaisePropertyChanged(); }
        }
        private int _data=3;

        public int data
        {
            get { return _data; }
            set { _data = value; RaisePropertyChanged(); }
        }
        public DelegateCommand ExecuteDataCommand { get; set; }
        public DailyDutyViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            string identiPhoto1 = Base64Helper.FileToBase64Str((@"D:\C#\外单位施工人员管理系统WPF\监狱AB门WPF\监狱AB门WPF\Images\w(1).png"));
            ExecuteDataCommand = new DelegateCommand(test);
            dailyPersonInfos = new ObservableCollection<ExternalPersonInfo>();
            for (int i = 0; i < 6; i++)
            {
                dailyPersonInfos.Add(new ExternalPersonInfo()
                {
                    typeExternalPerson = "货车司机" + i.ToString(),
                    name = "李四" + i.ToString()+"测试长度100342222200012030414",
                    idCardNum = "34222220012030414",
                    applicationReason = "送货物",
                    phone = "15505570050",
                    sex = "男",
                    busNum = "123456" + i.ToString(),
                    base64RealPhoto = Base64Helper.GetBase64String(new Bitmap(@"D:\\C#\\外单位施工人员管理系统WPF\\监狱AB门WPF\\监狱AB门WPF\\Images\\user.jpg")),
                    identiPhoto = identiPhoto1
                }); ;
            }
        }

        private void test()
        {
            data++;
            if (data >= 10)
            {
                
                data = 1;
            }
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
    }
}
