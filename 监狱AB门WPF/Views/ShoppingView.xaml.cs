using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace 智能AB门WPF.Views
{
    /// <summary>
    /// ShoppingView.xaml 的交互逻辑
    /// </summary>
    public partial class ShoppingView : UserControl
    {
        private int ddCOunt = 0;
        public ShoppingView()
        {
            InitializeComponent();
            this.Loaded += ShoppingView_Loaded;
            
        }

        private void ShoppingView_Loaded(object sender, RoutedEventArgs e)
        {
            ddCOunt = dd.Items.Count;

        }

        private void dd_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            Console.WriteLine("1");
        }

        private void dd_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }
        double preOffset = 0;
        private void dd_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

            DataGrid dataGrid = sender as DataGrid;
            var ss = dataGrid.Items.Count;
            int nowcount = ss;


            if (nowcount != ddCOunt)
            {
                //double suffOffSet = e.VerticalOffset;//获取当前的值
                //if (e.VerticalChange >= 0 && suffOffSet >= preOffset)
                //{
                //    if (suffOffSet - preOffset >= 1)
                //        dataGrid.Items.MoveCurrentToNext();
                //    else
                //        dataGrid.Items.MoveCurrentToLast();
                //    if (dataGrid.Items.CurrentItem != null)
                //    {
                //        var temp = dataGrid.Items.CurrentItem;
                //        dataGrid.ScrollIntoView(temp);
                //        dataGrid.UpdateLayout();
                //    }
                //}
                //preOffset = suffOffSet;


                bool istrue = dataGrid.Items.MoveCurrentToLast();
                if (dataGrid.Items.CurrentItem != null)
                {
                    
                    var temp = dataGrid.Items.CurrentItem;
                    dataGrid.ScrollIntoView(temp);  
                    dataGrid.UpdateLayout();
                }
             
                ddCOunt = nowcount;
            }


        }
    }
}
