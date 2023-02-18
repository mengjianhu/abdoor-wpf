using Lierda.WPFHelper;
using Newtonsoft.Json;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Diagnostics;
using System.IO;
using System.Windows;
using 智能AB门WPF.Common.Model;
using 智能AB门WPF.ViewModels;
using 智能AB门WPF.Views;
using 监狱AB门WPF.Common;
using 监狱AB门WPF.ViewModels;
using 监狱AB门WPF.Views;

namespace 监狱AB门WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static string appUrl = "";
        public static string openDoorImage = "";
        public static string closeDoorImage = "";
        public static DeviceMacList deviceMacList;
        protected override Window CreateShell()
        {
            //DeviceMacList deviceMacList = new DeviceMacList()
            //{
            //    macA = "1E:05:4F:FB:48:D7",
            //    macB = "1A:C2:34:18:B0:3C",
            //    macC = "6A:B5:31:27:7E:56",
            //    macD = "6E:7F:94:DE:B2:88"
            //};
            //string ss = JsonConvert.SerializeObject(deviceMacList);
            //File.WriteAllText("devicemaclist.txt", ss);
            if (!File.Exists("devicemaclist.txt"))
            {
                MessageBox.Show("缺少文件devicemaclist");
                System.Environment.Exit(0);
            }
            deviceMacList = JsonConvert.DeserializeObject<DeviceMacList>(File.ReadAllText("devicemaclist.txt"));
            System.Drawing.Image image = System.Drawing.Image.FromFile("closeDoor.png");
            System.Drawing.Image image1 = System.Drawing.Image.FromFile("openDoor.png");
            openDoorImage = Base64Helper.GetBase64String((System.Drawing.Bitmap)image);
            closeDoorImage = Base64Helper.GetBase64String((System.Drawing.Bitmap)image1);
            appUrl = File.ReadAllText("seeting.txt");
            LierdaCracker cracker = new LierdaCracker();
            cracker.Cracker();
            return Container.Resolve<MainWindow>();
        }
        protected override void OnInitialized()
        {
            //var dialog = Container.Resolve<IDialogService>();
            var service = App.Current.MainWindow.DataContext as IConfigureService;
            if (service != null)
                service.Configure(); 
            base.OnInitialized();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
            containerRegistry.RegisterForNavigation<RecordQueryView, RecordQueryViewModel>();
            containerRegistry.RegisterForNavigation<InfoExternalPersonnelView, InfoExternalPersonnelViewModel>();
            containerRegistry.RegisterForNavigation<RefuseView, RefuseViewModel>();
            containerRegistry.RegisterForNavigation<DailyDutyView, DailyDutyViewModel>();
            containerRegistry.RegisterForNavigation <ListTestView, ListTestViewModel>();
            containerRegistry.RegisterForNavigation<ShoppingView, ShoppingViewModel>();
            containerRegistry.Register<IDialogHostService, DialogHostService>();
        }
    }
}
