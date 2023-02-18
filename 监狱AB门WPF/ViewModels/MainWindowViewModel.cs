using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using 监狱AB门WPF.Common;
using 监狱AB门WPF.Common.Model;
using 监狱AB门WPF.Extensions;
using 监狱AB门WPF.Views;

namespace 监狱AB门WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase, IConfigureService
    {
        //private string _title = "Prism Application";
        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}
        private readonly IContainerProvider containerProvider;
        private readonly IRegionManager regionManager;

        private ObservableCollection<MenuBar> menuBars;
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        public DelegateCommand SeetingCommand { get; set; }
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        public MainWindowViewModel(IContainerProvider containerProvider, IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            SeetingCommand = new DelegateCommand(OpenSeetingForm);
            this.regionManager = regionManager;
            this.containerProvider = containerProvider;
        }
        /// <summary>
        /// 设置页面
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void OpenSeetingForm()
        {
            SeetingView seetingView = new SeetingView();
            seetingView.Show();
        }

        /// <summary>
        /// 导航
        /// </summary>
        /// <param name="obj"></param>
        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace);
        }

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "ScoreboardOutline", Title = "首页", NameSpace = "HomeView" });
            // MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "日常值班", NameSpace = "DailyDutyView" });
            MenuBars.Add(new MenuBar() { Icon = "ClipboardTextClock", Title = "记录查询", NameSpace = "RecordQueryView" });
            // MenuBars.Add(new MenuBar() { Icon = "Information", Title = "实时数据统计", NameSpace = "AboutView" });
            // MenuBars.Add(new MenuBar() { Icon = "Information", Title = "系统设置", NameSpace = "AboutView" });
            MenuBars.Add(new MenuBar() { Icon = "Information", Title = "访客审批", NameSpace = "InfoExternalPersonnelView" });
            //MenuBars.Add(new MenuBar() { Icon = "Information", Title = "ListViewTest", NameSpace = "ListTestView" });
            MenuBars.Add(new MenuBar() { Icon = "Information", Title = "结算", NameSpace = "ShoppingView" });
        }

        public void Configure()
        {
            CreateMenuBar();
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("HomeView");
        }
    }
}
