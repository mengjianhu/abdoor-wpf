using Prism.Events;
using System;
using System.Windows;
using System.Windows.Input;
using 监狱AB门WPF.Common;
using 监狱AB门WPF.Extensions;

namespace 监狱AB门WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow(IEventAggregator aggregator)
        {
            InitializeComponent();
            //this.dialogHostService = dialogHostService;
            // 注册提示消息
            //aggregator.ResgiterMessage(arg =>
            //{
            //    Snackbar.MessageQueue = new MaterialDesignThemes.Wpf.SnackbarMessageQueue(TimeSpan.FromSeconds(1));
            //    Snackbar.MessageQueue.Enqueue(arg.Message);

            //});
            //注册等待消息
            aggregator.Resgiter(agr =>
            {
                DialogHost.IsOpen = agr.IsOpen;
                if (DialogHost.IsOpen)
                {
                    DialogHost.DialogContent = new ProgressView();
                }
            });
            ColorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            };
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    btnMax.Content = "☐";
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    btnMax.Content = "❐";
                }
            };
            //btn_seeting.Click += (s, e) =>
            //{
            //    SeetingView seetingView = new SeetingView();
            //    seetingView.Topmost = true;
            //    seetingView.ShowDialog();
            //};
            btnMin.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };
            btnClose.Click += (s, e) =>
            {
                this.Close();
            };
            ColorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            };
            ColorZone.MouseDoubleClick += (s, e) =>
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                    btnMax.Content = "❐";
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                    btnMax.Content = "☐";
                }
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
            this.Height = SystemParameters.WorkArea.Height;//获取屏幕的宽高  使之不遮挡任务栏
            this.Width = SystemParameters.WorkArea.Width;
           // MessageBox.Show(Height.ToString() + ":" + Width.ToString());
        }
    }
}
