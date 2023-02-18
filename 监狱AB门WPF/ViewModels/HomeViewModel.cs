using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Rubyer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using 智能AB门WPF.Common.Help;
using 智能AB门WPF.Common.Model;
using 监狱AB门WPF.Common;
using 监狱AB门WPF.Common.Help;
using 监狱AB门WPF.Common.Model;
using 监狱AB门WPF.Service;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  HomeViewModel
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/25 11:39:43
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/25 11:39:43
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.ViewModels
{
    public class HomeViewModel : NavigationViewModel
    {

        public DelegateCommand executeCommandOpenA { get; set; }
        public DelegateCommand executeCommandOpenB { get; set; }
        private bool _isOpenA = false;
        /// <summary>
        /// A门的状态
        /// </summary>
        public bool isOpenA
        {
            get { return _isOpenA; }
            set { _isOpenA = value; RaisePropertyChanged(); }
        }
        private bool _isOpenB = false;
        /// <summary>
        /// B门的状态
        /// </summary>
        public bool isOpenB
        {
            get { return _isOpenB; }
            set { _isOpenB = value; RaisePropertyChanged(); }
        }
        private Brush _isSelectColorA = new SolidColorBrush(Colors.Gray);
        /// <summary>
        /// B门的颜色
        /// </summary>
        public Brush isSelectColorA
        {
            get { return _isSelectColorA; }
            set { _isSelectColorA = value; RaisePropertyChanged(); }
        }

        private Brush _isSelectColorB = new SolidColorBrush(Colors.Gray);
        /// <summary>
        /// B门的颜色
        /// </summary>
        public Brush isSelectColorB
        {
            get { return _isSelectColorB; }
            set { _isSelectColorB = value; RaisePropertyChanged(); }
        }
        private string _errorMessage;
        /// <summary>
        /// 开门异常提示
        /// </summary>
        public string errorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<DeviceInfo> _deviceInfos;
        /// <summary>
        /// 设备信息集合
        /// </summary>
        public ObservableCollection<DeviceInfo> deviceInfos
        {
            get { return _deviceInfos; }
            set { _deviceInfos = value; RaisePropertyChanged(); }
        }
        #region 索引
        private int _deviceIndex;

        public int deviceIndex
        {
            get { return _deviceIndex; }
            set { _deviceIndex = value; RaisePropertyChanged(); }
        }
        private int _devicePersoninfoAIndex;
        /// <summary>
        /// 设备A的索引
        /// </summary>
        public int devicePersoninfoAIndex
        {
            get { return _devicePersoninfoAIndex; }
            set { _devicePersoninfoAIndex = value; RaisePropertyChanged(); }
        }

        private int _devicePersoninfoBIndex;
        /// <summary>
        /// 设备B的索引
        /// </summary>
        public int devicePersoninfoBIndex
        {
            get { return _devicePersoninfoBIndex; }
            set { _devicePersoninfoBIndex = value; RaisePropertyChanged(); }
        }
        private int _devicePersoninfoCIndex;
        /// <summary>
        /// 设备C的索引
        /// </summary>
        public int devicePersoninfoCIndex
        {
            get { return _devicePersoninfoCIndex; }
            set { _devicePersoninfoCIndex = value; RaisePropertyChanged(); }
        }
        private int _devicePersoninfoDIndex;
        /// <summary>
        /// 设备C的索引
        /// </summary>
        public int devicePersoninfoDIndex
        {
            get { return _devicePersoninfoDIndex; }
            set { _devicePersoninfoDIndex = value; RaisePropertyChanged(); }
        }
        #endregion
        private bool _isCheckMessage = true;


        private string _ADoorImage;

        public string ADoorImage
        {
            get { return _ADoorImage; }
            set { _ADoorImage = value; RaisePropertyChanged(); }
        }

        private string _BDoorImage;

        public string BDoorImage
        {
            get { return _BDoorImage; }
            set { _BDoorImage = value; RaisePropertyChanged(); }
        }
        private string _deviceAName;

        public string deviceAName
        {
            get { return _deviceAName; }
            set { _deviceAName = value; RaisePropertyChanged(); }
        }

        private string _deviceBName;

        public string deviceBName
        {
            get { return _deviceBName; }
            set { _deviceBName = value;RaisePropertyChanged(); }
        }      

        private string _deviceCName;

        public string deviceCName
        {
            get { return _deviceCName; }
            set { _deviceCName = value; RaisePropertyChanged(); }
        }
        private string _deviceDName;

        public string deviceDName
        {
            get { return _deviceDName; }
            set { _deviceDName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 操作 查看设备时 是否弹出提示小时 默认为true
        /// </summary>
        public bool isCheckMessage
        {
            get { return _isCheckMessage; }
            set { _isCheckMessage = value; RaisePropertyChanged(); }
        }

        #region 设备信息
        private ObservableCollection<DeviceHyPersonDetail> _devicePersonInfosA;
        /// <summary>
        /// 设备A的核验信息
        /// </summary>
        public ObservableCollection<DeviceHyPersonDetail> devicePersonInfosA
        {
            get { return _devicePersonInfosA; }
            set { _devicePersonInfosA = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<DeviceHyPersonDetail> _devicePersonInfosB;
        /// <summary>
        /// 设备B的核验信息
        /// </summary>
        public ObservableCollection<DeviceHyPersonDetail> devicePersonInfosB
        {
            get { return _devicePersonInfosB; }
            set { _devicePersonInfosB = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<DeviceHyPersonDetail> _devicePersonInfosC;
        /// <summary>
        /// 设备C的核验信息
        /// </summary>
        public ObservableCollection<DeviceHyPersonDetail> devicePersonInfosC
        {
            get { return _devicePersonInfosC; }
            set { _devicePersonInfosC = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<DeviceHyPersonDetail> _devicePersonInfosD;
        /// <summary>
        /// 设备D的核验信息
        /// </summary>
        public ObservableCollection<DeviceHyPersonDetail> devicePersonInfosD
        {
            get { return _devicePersonInfosD; }
            set { _devicePersonInfosD = value; RaisePropertyChanged(); }
        }
        #endregion

        string cmdConnect = "adb connect ";//连接
        string cmdDisConnect = "adb disconnect ";//断开连接

        string beforeIP = "";
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public async Task<string> excuteCmdCommand(string cmd)
        {

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(cmd + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令
            //获取cmd窗口的输出信息
            string output = await p.StandardOutput.ReadToEndAsync();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            await p.WaitForExitAsync();//等待程序执行完退出进程
            p.Close();

            return output;
        }

        /// <summary>
        /// 打开Adb程序
        /// </summary>
        public void openDeviceADB()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"scrcpy.exe";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process pro = Process.Start(info);
            pro.WaitForExit();
        }
        public DelegateCommand ExecuteCommand { get; set; }
        

        #region 按钮详情信息
        /// <summary>
        /// 设备A中人员的详细信息
        /// </summary>
        public DelegateCommand ExecuteCommandADetail { get; set; }


        public DelegateCommand ExecuteCommandBDetail { get; set; }
        public DelegateCommand ExecuteCommandCDetail { get; set; }
        public DelegateCommand ExecuteCommandDDetail { get; set; }

        public DelegateCommand<string> ExecuteRefreshCommand { get; set; }
        #endregion
        public HomeViewModel(IContainerProvider provider) : base(provider)
        {
            ExecuteCommand = new DelegateCommand(getDeviceDetailWithAdb);
            ExecuteCommandADetail = new DelegateCommand(btn_deviceADetail);
            ExecuteCommandBDetail = new DelegateCommand(btn_deviceBDetail);
            ExecuteCommandCDetail = new DelegateCommand(btn_deviceCDetail);
            ExecuteCommandDDetail = new DelegateCommand(btn_deviceDDetail);

            ExecuteRefreshCommand = new DelegateCommand<string>(refresh);
            executeCommandOpenA = new DelegateCommand(openAdoor);
            executeCommandOpenB = new DelegateCommand(openBdoor);
            devicePersonInfosA = new ObservableCollection<DeviceHyPersonDetail>();
            devicePersonInfosB = new ObservableCollection<DeviceHyPersonDetail>();
            devicePersonInfosC = new ObservableCollection<DeviceHyPersonDetail>();
            devicePersonInfosD = new ObservableCollection<DeviceHyPersonDetail>();
            deviceInfos = new ObservableCollection<DeviceInfo>();


            this.ADoorImage = App.closeDoorImage;
            this.BDoorImage = App.closeDoorImage;
            //deviceInfos.Add(new DeviceInfo() { name = "A进", ipaddress = "192.168.1.1", isOnLine = true });
            //deviceInfos.Add(new DeviceInfo() { name = "A出", ipaddress = "192.168.1.2",   = false });
            //deviceInfos.Add(new DeviceInfo() { name = "B进", ipaddress = "192.168.1.3", isOnLine = true });
            //deviceInfos.Add(new DeviceInfo() { name = "B出", ipaddress = "192.168.1.4", isOnLine = false });
            //GetDeviceInfo();
            //GetPerosonInfoA(App.deviceMacList.macA);
            //GetPerosonInfoB(App.deviceMacList.macB);
            //GetPerosonInfoC(App.deviceMacList.macC);
            //GetPerosonInfoD(App.deviceMacList.macD);
            // GetDeviceInfo();
        }

        private void btn_deviceDDetail()
        {
            MessageBox.Show(devicePersoninfoDIndex.ToString());
        }

        private void btn_deviceCDetail()
        {
            MessageBox.Show(devicePersoninfoCIndex.ToString());
        }

        private void btn_deviceBDetail()
        {
            MessageBox.Show(devicePersoninfoBIndex.ToString());
        }

        private void btn_deviceADetail()
        {
            MessageBox.Show(devicePersoninfoAIndex.ToString());
        }

        /// <summary>
        /// 刷新
        /// </summary>
        private void refresh(string ss)
        {
             
            switch (ss)
            {
                case "deviceAllRefresh":
                    refreshDeviceAll();
                    break;
                case "deviceARefresh":
                    deviceARefresh();
                    break;
                case "deviceBRefresh":
                    deviceBRefresh();
                    break;
                case "deviceCRefresh":
                    deviceCRefresh();
                    break;
                case "deviceDRefresh":
                    deviceDRefresh();
                    break;

            }
            
        }
        /// <summary>
        /// 设备A刷新
        /// </summary>
        private void deviceARefresh()
        {
            GetPerosonInfoA(App.deviceMacList.macA);
        }
        /// <summary>
        /// 设备B刷新
        /// </summary>
        private void deviceBRefresh()
        {
            GetPerosonInfoB(App.deviceMacList.macB);
        }
        /// <summary>
        /// 设备C刷新
        /// </summary>
        private void deviceCRefresh()
        {
            GetPerosonInfoC(App.deviceMacList.macC);
        }
        /// <summary>
        /// 设备D刷新
        /// </summary>
        private void deviceDRefresh()
        {
            GetPerosonInfoD(App.deviceMacList.macD);
        }

        private void refreshDeviceAll()
        {
            GetDeviceInfo();
        }

        private async void getDeviceDetailWithAdb()
        {

            if (deviceIndex >= 0)
            {
                var result = MessageBoxR.ConfirmGlobal($"是否查看{deviceInfos[deviceIndex].name}：{deviceInfos[deviceIndex].ipaddress}的设备信息?", "提示");
                if (result == MessageBoxResult.Yes)
                {
                    string nowIP = deviceInfos[deviceIndex].ipaddress;
                    if (nowIP != beforeIP && !string.IsNullOrEmpty(beforeIP))
                    {
                        string diss = await excuteCmdCommand(cmdDisConnect + beforeIP);//执行断开命令

                        if (diss.Contains("disconnected"))
                        {
                            if (isCheckMessage)
                            {
                                MessageBox.Show("成功断开连接:" + beforeIP);
                            }

                        }

                    }

                    try
                    {
                        UpdateLoading(true);
                        string ss = await excuteCmdCommand(cmdConnect + nowIP);//执行连接命令
                                                                               //  MessageBox.Show(ss);
                        if (ss.Contains("cannot"))
                        {

                            if (isCheckMessage)
                            {
                                Message.WarningGlobal("无法连接到该设备,请检查设备是成功联网");

                            }

                            beforeIP = nowIP;
                            return;
                        }
                        if (ss.Contains("disconnected"))
                        {

                            if (isCheckMessage)
                            {
                                Message.SuccessGlobal("成功断开连接:" + nowIP);
                            }

                        }
                        if (ss.Contains("already connected"))
                        {
                            if (isCheckMessage)
                            {
                                Message.WarningGlobal("已经成功连接");
                            }



                            beforeIP = nowIP;//
                            openDeviceADB();
                        }
                        else if (ss.Contains("connected") && !ss.Contains("already"))
                        {
                            if (isCheckMessage)
                            {

                                Message.SuccessGlobal("成功连接:" + nowIP);
                            }
                            beforeIP = nowIP;//成功连接之后 

                            openDeviceADB();
                        }
                    }
                    catch (Exception ex)
                    {
                        UpdateLoading(false);
                        MessageBox.Show(ex.Message);

                    }
                    finally
                    {
                        UpdateLoading(false);
                    }
                }
                // MessageBox.Show(ss);

            }
        }
        /// <summary>
        /// 使用线程加载设备数据
        /// </summary>
        public   void GetDeviceInfo()
        {
            Task.Run(async () =>
             {
                 try
                 {
                     Dictionary<string, int> para = new Dictionary<string, int>();
                     para.Add("page", 1);
                     para.Add("limit", 10);
                     //string ss = await HUHttpClientHelp.WebApiGetAsync(App.appUrl + "/dfaceV1/device/getAll", para);
                     string ss = await HUHttpClientHelp.WebApiGetAsync("http://192.168.1.252:8080/dfaceV1/device/getAll", para);
                     Console.WriteLine($"result:{ss}");
                     if (ss != null)
                     {
                         Result<DeviceInfo> result1 = JsonConvert.DeserializeObject<Result<DeviceInfo>>(ss);
                         if (result1 != null)
                         {
                             if (result1.code == 0)
                             {
                                 deviceInfos = result1.data;
                                 deviceAName = deviceInfos[0].name;
                                 deviceBName = deviceInfos[1].name;
                                 deviceCName = deviceInfos[2].name;
                                 deviceDName = deviceInfos[3].name;
                                 if (deviceInfos != null)
                                 {
                                     foreach (var item in deviceInfos)
                                     {
                                         if (TimeHelp.GetDiffSecond(Convert.ToDateTime(item.lastTime), DateTime.Now) <= 600)
                                         {
                                             item.isOnLine = true;
                                         }
                                         else
                                         {
                                             item.isOnLine = false;
                                         }
                                     }
                                 }

                             }

                         }


                     }
                     else
                     {
                         Console.WriteLine("异常");
                     }
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message);
                 }

             });

        }

        class Mac
        {
            public string mac { get; set; }
        }


        public void GetPerosonInfoA(string deviceMac)
        {
            Task.Run(async () =>
            {
                try
                {
                    string ss = await HUHttpClientHelp.Post(JsonConvert.SerializeObject(new Mac()
                    {
                        mac = deviceMac
                    }), App.appUrl + "/record/selectByMac");
                    Console.WriteLine($"result:{ss}");
                    if (ss != null)
                    {
                        Result<DeviceHyPersonDetail> result1 = JsonConvert.DeserializeObject<Result<DeviceHyPersonDetail>>(ss);
                        if (result1 != null)
                        {
                            if (result1.code == 200 && result1.data != null)
                            {
                                List<DeviceHyPersonDetail> deviceHyPersonDetails = result1.data.OrderByDescending(a => a.dateTime).Take(100).ToList();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine(deviceHyPersonDetails.Count);
                                devicePersonInfosA =
ConvertList2ObserveableCollectionHelp.ConvertList2ObserveableCollection(deviceHyPersonDetails);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("异常");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            });
        }
        public void GetPerosonInfoB(string deviceMac)
        {
            Task.Run(async () =>
            {
                try
                {
                    string ss = await HUHttpClientHelp.Post(JsonConvert.SerializeObject(new Mac()
                    {
                        mac = deviceMac
                    }), App.appUrl + "/record/selectByMac");
                    Console.WriteLine($"result:{ss}");
                    if (ss != null)
                    {
                        Result<DeviceHyPersonDetail> result1 = JsonConvert.DeserializeObject<Result<DeviceHyPersonDetail>>(ss);
                        if (result1 != null)
                        {
                            if (result1.code == 200 && result1.data != null)
                            {
                                List<DeviceHyPersonDetail> deviceHyPersonDetails = result1.data.OrderByDescending(a => a.dateTime).Take(100).ToList();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine(deviceHyPersonDetails.Count);
                                devicePersonInfosB = ConvertList2ObserveableCollectionHelp.ConvertList2ObserveableCollection(deviceHyPersonDetails);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("异常");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            });

        }

        public void GetPerosonInfoC(string deviceMac)
        {
            Task.Run(async () =>
            {
                try
                {
                    string ss = await HUHttpClientHelp.Post(JsonConvert.SerializeObject(new Mac()
                    {
                        mac = deviceMac
                    }), App.appUrl + "/record/selectByMac");
                    Console.WriteLine($"result:{ss}");
                    if (ss != null)
                    {
                        Result<DeviceHyPersonDetail> result1 = JsonConvert.DeserializeObject<Result<DeviceHyPersonDetail>>(ss);
                        if (result1 != null)
                        {
                            if (result1.code == 200 && result1.data != null)
                            {
                                List<DeviceHyPersonDetail> deviceHyPersonDetails = result1.data.OrderByDescending(a => a.dateTime).Take(100).ToList();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine(deviceHyPersonDetails.Count);
                                devicePersonInfosC = ConvertList2ObserveableCollectionHelp.ConvertList2ObserveableCollection(deviceHyPersonDetails);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("异常");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            });
        }
        public void GetPerosonInfoD(string deviceMac)
        {
            Task.Run(async () =>
            {
                try
                {
                    string ss = await HUHttpClientHelp.Post(JsonConvert.SerializeObject(new Mac()
                    {
                        mac = deviceMac
                    }), App.appUrl + "/record/selectByMac");
                    Console.WriteLine($"result:{ss}");
                    if (ss != null)
                    {
                        Result<DeviceHyPersonDetail> result1 = JsonConvert.DeserializeObject<Result<DeviceHyPersonDetail>>(ss);
                        if (result1 != null)
                        {
                            if (result1.code == 200 && result1.data != null)
                            {
                                List<DeviceHyPersonDetail> deviceHyPersonDetails = result1.data.OrderByDescending(a => a.dateTime).Take(100).ToList();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine(deviceHyPersonDetails.Count);
                                devicePersonInfosD = ConvertList2ObserveableCollectionHelp.ConvertList2ObserveableCollection(deviceHyPersonDetails);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("异常");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            });
        }

        private void openAdoor()
        {
            if (isOpenA)
            {
                isOpenA = false;
                errorMessage = "A门已经被关闭";
                isSelectColorA = new SolidColorBrush(Colors.Gray);
                ADoorImage = App.closeDoorImage;
            }
            else if (isOpenB)
            {
                errorMessage = "B门已经被打开,暂时无法打开A门";
            }
            else
            {
                isOpenA = true;
                errorMessage = "A门已经被打开";
                ADoorImage = App.openDoorImage;
                BDoorImage = App.closeDoorImage;
                isSelectColorA = new SolidColorBrush(Colors.Green);
                isSelectColorB = new SolidColorBrush(Colors.Gray);
            }

        }
        private void openBdoor()
        {
            if (isOpenB)
            {
                isOpenB = false;
                errorMessage = "B门已经被关闭";
                BDoorImage = App.closeDoorImage;
                isSelectColorB = new SolidColorBrush(Colors.Gray);
            }
            else if (isOpenA)
            {
                errorMessage = "A门已经被打开,暂时无法打开B门";
            }
            else
            {
                isOpenB = true;
                errorMessage = "B门已经被打开";
                BDoorImage = App.openDoorImage;
                ADoorImage = App.closeDoorImage;
                isSelectColorB = new SolidColorBrush(Colors.Green);
                isSelectColorA = new SolidColorBrush(Colors.Gray);
            }
        }


    }
}
