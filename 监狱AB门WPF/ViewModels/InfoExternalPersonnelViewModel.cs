using DryIoc;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Rubyer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using 监狱AB门WPF.Common;
using 监狱AB门WPF.Common.Model;
using 监狱AB门WPF.Service;
using 监狱AB门WPF.Views;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  InfoExternalPersonnelViewModel
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/29 14:19:34
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/29 14:19:34
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.ViewModels
{
    public class InfoExternalPersonnelViewModel : NavigationViewModel
    {
        public readonly IDialogHostService dialog;

        private ObservableCollection<ExternalPersonInfo> _externalPersonInfos;

        public ObservableCollection<ExternalPersonInfo> externalPersonInfos
        {
            get { return _externalPersonInfos; }
            set { _externalPersonInfos = value; RaisePropertyChanged(); }
        }
        private int _dataCount;

        public int DataCount
        {
            get { return _dataCount; }
            set { _dataCount = value; RaisePropertyChanged(); }
        }

        private Brush _colorIsPass;

        public Brush colorIsPassProperty
        {
            get { return _colorIsPass; }
            set { _colorIsPass = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 同意
        /// </summary>
        public DelegateCommand<object> ExecuteCommandSuccess { get; set; }
        /// <summary>
        /// 拒绝
        /// </summary>
        public DelegateCommand<object> ExecuteCommandDefeat { get; set; }
        /// <summary>
        /// 查看详情
        /// </summary>
        public DelegateCommand<object> ExecuteCommandDetail { get; set; }
        /// <summary>
        /// 刷新
        /// </summary>
        public DelegateCommand ExexuteUpdateCommad { get; set; }

        public InfoExternalPersonnelViewModel(IContainerProvider provider, IDialogHostService dialog) : base(provider)
        {
            externalPersonInfos = new ObservableCollection<ExternalPersonInfo>();

            ExecuteCommandSuccess = new DelegateCommand<object>(btn_success);
            ExecuteCommandDefeat = new DelegateCommand<object>(btn_defeat);
            ExecuteCommandDetail = new DelegateCommand<object>(btn_detail);
            ExexuteUpdateCommad = new DelegateCommand(btn_update);
            test();
            this.dialog = dialog;
        }

        private void btn_update()
        {
            try
            {
                UpdateLoading(true);
                string ss = Base64Helper.GetBase64String(new Bitmap(@"D:\\C#\\外单位施工人员管理系统WPF\\监狱AB门WPF\\监狱AB门WPF\\Images\\user.jpg"));
                string identiPhoto1 = Base64Helper.FileToBase64Str((@"D:\C#\外单位施工人员管理系统WPF\监狱AB门WPF\监狱AB门WPF\Images\w(1).png"));
                externalPersonInfos.Clear();
                for (int i = 0; i < 5; i++)
                {
                    externalPersonInfos.Add(new ExternalPersonInfo()
                    {
                        typeExternalPerson = "货车司机" + i.ToString(),
                        name = "李四" + i.ToString(),
                        isPass = true,
                        busNum = "123456" + i.ToString(),
                        base64RealPhoto = Base64Helper.GetBase64String(new Bitmap(@"D:\\C#\\外单位施工人员管理系统WPF\\监狱AB门WPF\\监狱AB门WPF\\Images\\user.jpg")),
                        identiPhoto = identiPhoto1
                    });
                }
                DataCount = externalPersonInfos.Count;

            }
            catch (Exception)
            {


            }
            finally
            {
                UpdateLoading(false);
            }

        }

        public async void test()
        {
            string ss = Base64Helper.GetBase64String(new Bitmap(@"D:\\C#\\外单位施工人员管理系统WPF\\监狱AB门WPF\\监狱AB门WPF\\Images\\user.jpg"));
            string identiPhoto1 = Base64Helper.FileToBase64Str((@"D:\C#\外单位施工人员管理系统WPF\监狱AB门WPF\监狱AB门WPF\Images\w(1).png"));
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < 20; i++)
                {
                    externalPersonInfos.Add(new ExternalPersonInfo()
                    {
                        typeExternalPerson = "货车司机" + i.ToString(),
                        name = "李四" + i.ToString(),
                        idCardNum = "34222220012030414",
                        applicationReason = "送货物",
                        phone = "15505570050",
                        sex = "男",
                        busNum = "123456" + i.ToString(),
                        base64RealPhoto = Base64Helper.GetBase64String(new Bitmap(@"D:\\C#\\外单位施工人员管理系统WPF\\监狱AB门WPF\\监狱AB门WPF\\Images\\user.jpg")),
                        identiPhoto = identiPhoto1

                    }); ;
                }
                DataCount = externalPersonInfos.Count;


                stopwatch.Stop();

                Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
                //UpdateLoading(true);
                //Dictionary<string, int> ss = new Dictionary<string, int>();
                //ss.Add("limit", 10);
                //ss.Add("page", 1);
                ////数据拼接
                //string result = await  HUHttpClientHelp.WebApiPostAsync("http://192.168.1.13:8080/personnal/findData", ss);
            }
            catch (Exception ex)
            {
                UpdateLoading(false);
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        private void btn_detail(object obj)
        {
            Button button = (Button)obj;
            if (button != null)
            {
                ExternalPersonInfo externalPersonInfo = button.DataContext as ExternalPersonInfo;
                if (externalPersonInfo != null)
                {
                    ExternalPersonDetailView externalPersonDetailView = new ExternalPersonDetailView(externalPersonInfo);
                    externalPersonDetailView.ShowDialog();
                }
            }
        }

        private async void btn_defeat(object obj)
        {
            try
            {
                Button button = (Button)obj;
                if (button != null)
                {
                    ExternalPersonInfo externalPersonInfo = button.DataContext as ExternalPersonInfo;
                    if (externalPersonInfo != null)
                    {
                        DialogParameters param = new DialogParameters();
                        param.Add("Value", externalPersonInfo);
                        await dialog.ShowDialog("RefuseView", param);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void btn_success(object obj)
        {
            try
            {
                UpdateLoading(true);
                Button button = (Button)obj;
                if (button != null)
                {
                    ExternalPersonInfo externalPersonInfo = button.DataContext as ExternalPersonInfo;
                    if (externalPersonInfo != null)
                    {
                        externalPersonInfo.isPass = true;
                        Message.SuccessGlobal($"同意{externalPersonInfo.name}的请求");
                        externalPersonInfos.Remove(externalPersonInfo);
                        DataCount = externalPersonInfos.Count;
                    }
                }
            }
            catch (Exception ex)
            {

                Message.SuccessGlobal($"异常：{ex.Message}");
            }
            finally
            {
                UpdateLoading(false);
            }


        }
    }
}
