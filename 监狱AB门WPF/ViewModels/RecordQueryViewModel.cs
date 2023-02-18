using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Rubyer;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 智能AB门WPF.Common.Model;
using 监狱AB门WPF.Common.Help;
using 监狱AB门WPF.Common.Model;
using 监狱AB门WPF.Service;
using 监狱AB门WPF.Views;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  RecordQueryViewModel
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/28 9:53:40
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/28 9:53:40
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.ViewModels
{
    public class RecordQueryViewModel : NavigationViewModel, INavigationAware
    {

        private int _dataindex = -1;


        /// <summary>
        /// 索引 
        /// </summary>
        public int dataindex
        {
            get { return _dataindex; }
            set { _dataindex = value; RaisePropertyChanged(); }
        }

        private DateTime? _dateTimeStart;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? dateTimeStart
        {
            get { return  _dateTimeStart; }
            set { _dateTimeStart = value; RaisePropertyChanged(); }
        }

        private DateTime? _dateTimeEnd;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? dateTimeEnd
        {
            get { return  _dateTimeEnd; }
            set { _dateTimeEnd = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<DeviceInfo> _deviceInfos;

        public ObservableCollection<DeviceInfo> deviceInfos
        {
            get { return _deviceInfos; }
            set { _deviceInfos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        public DelegateCommand ExecuteDataSelectCommand { get; set; }

        private int _pageNum = 1;
        /// <summary>
        /// 页码
        /// </summary>
        public int pageNum
        {
            get { return _pageNum ; }
            set { _pageNum = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<DeviceHyPersonDetail> _recores;

        public ObservableCollection<DeviceHyPersonDetail> recores
        {
            get { return _recores; }
            set { _recores = value; RaisePropertyChanged(); }
        }
      //  private ObservableCollection<PersonInfo> listrecores = new ObservableCollection<PersonInfo>();
        public DelegateCommand<string> ExecuteCommand { get; set; }
        public RecordQueryViewModel(IContainerProvider provider) : base(provider)
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
            ExecuteDataSelectCommand = new DelegateCommand(query);

            //this.recores = listrecores;
            select(pageNum);



        }
        private void Execute(string obj)
        {
            switch (obj)
            { 
               case "btn_skipPage"://查询
                    btn_skipPageClick();
            break;
                case "reset"://重置
                    reset();
                    break;
                case "btn_upPage"://上一页
                    btn_upPageClick();
                    break;
                case "btn_downPage"://下一页 
                    btn_downPageClick();
                    break;
                case "btn_detail"://详情 
                    btn_detail();
                    break;
                case "btn_del"://删除 
                    btn_del();
                    break;
            }
        }

        /// <summary>
        /// 跳转
        /// </summary>
        private void btn_skipPageClick()
        {
            //MessageBox.Show(pageNum.ToString());
            if (pageNum > 0)
            {
                select(pageNum);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        
        private void query()
        {
            if (dateTimeStart != null && dateTimeEnd != null)
            {
                int i = TimeHelp.CompanyDate((DateTime)dateTimeStart, (DateTime)dateTimeEnd);
                if (i >= 0)
                {
                    MessageBox.Show("请选择正确的时间节点");
                }
                Console.WriteLine(i);
            }
            
        }
        /// <summary>
        /// 重置
        /// </summary>
        private void reset()
        {
            dateTimeStart = null;
            dateTimeEnd = null;
        }
        /// <summary>
        /// 下一页
        /// </summary>
        private void btn_downPageClick()
        {
            pageNum++;
            select(pageNum);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        private void btn_upPageClick()
        {
            if (pageNum > 1)
            {
                pageNum--;
                select(pageNum);
            }
            else
            {
                MessageBox.Show("当前已是首页");
            }
        }
        public async void select(int pageNum,int limit=10)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                UpdateLoading(true);
                Dictionary<string, int> ss = new Dictionary<string, int>();
                ss.Add("limit", limit);
                ss.Add("page", pageNum);
                //数据拼接
                string result = await HUHttpClientHelp.WebApiPostAsync(App.appUrl +"/record/getAllRecord", ss);
                Console.WriteLine(result);
                Result<DeviceHyPersonDetail> result1 = JsonConvert.DeserializeObject<Result<DeviceHyPersonDetail>>(result);
                if (result1.code ==0)
                {
                    ObservableCollection<DeviceHyPersonDetail> persons = result1.data;
                    recores = persons;
                }
              
               
            }
            catch (Exception)
            {
                UpdateLoading(false);
            }
            finally
            {
                UpdateLoading(false);
            }

        }

        private void btn_del()
        {
            if (dataindex >= 0)
            {
                var result = MessageBoxR.ConfirmGlobal("是否删除改数据?", "提示");
                if (result == MessageBoxResult.Yes)
                {
                    recores.Remove(recores[dataindex]);
                    Message.SuccessGlobal("删除成功");
                }
            }
        }
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        private void btn_detail()
        {

            if (dataindex >= 0)
            {
                RecordQueryDetailView test = new RecordQueryDetailView(recores[dataindex]);
                test.Show();
                // MessageBox.Show(dataindex.ToString());
            }
        }






    }
}
