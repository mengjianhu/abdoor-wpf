using DryIoc;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 监狱AB门WPF.Common;
using 监狱AB门WPF.Common.Model;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  RefuseViewModel
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/30 15:53:01
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/30 15:53:01
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.ViewModels
{
    public class RefuseViewModel : NavigationViewModel, IDialogHostAware
    {
        public readonly IDialogHostService dialogHost;
        public string DialogHostName { get; set; } = "Root";
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public RefuseViewModel(IContainerProvider provider, IDialogHostService dialogHost) : base(provider)
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancle);
            this.dialogHost = dialogHost;
        }

        private void Cancle()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                if (externalPersonInfo.isPass == null)
                {
                    externalPersonInfo.refuseReason = "";
                }
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
        }

        private ExternalPersonInfo _externalPersonInfo;

        public ExternalPersonInfo externalPersonInfo
        {
            get { return _externalPersonInfo; }
            set { _externalPersonInfo = value; RaisePropertyChanged(); }
        }

        

        private void Save()
        {
           
            if (!string.IsNullOrEmpty(externalPersonInfo.refuseReason))
            {
                externalPersonInfo.isPass = false;
                //关闭
                DialogHost.Close(DialogHostName);
            }
          
          

        }
        
        public void OnDialogOpend(IDialogParameters parameters)
        {
            try
            {
                if (parameters.ContainsKey("Value"))
                {
                    ExternalPersonInfo deviceInfo = parameters.GetValue<ExternalPersonInfo>("Value");
                    if (deviceInfo != null)
                    {
                       this.externalPersonInfo = deviceInfo;
                    }
                      
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
