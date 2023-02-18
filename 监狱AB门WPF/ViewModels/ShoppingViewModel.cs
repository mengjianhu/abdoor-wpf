using ImTools;
using Microsoft.Xaml.Behaviors;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using 智能AB门WPF.Common.Model;
using 监狱AB门WPF.ViewModels;
using TriggerAction = Microsoft.Xaml.Behaviors.TriggerAction;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2023  All Rights Reserved.
 * 文 件 名:  ShoppingViewModel
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2023-2-10 15:58:48
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2023-2-10 15:58:48
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 智能AB门WPF.ViewModels
{
    internal class ShoppingViewModel : NavigationViewModel
    {
        private ObservableCollection<ShoppingEntity> _shoppingEntities;
        private int _selectindex;

        public int selectindex
        {
            get { return _selectindex; }
            set { _selectindex = value; RaisePropertyChanged(); }
        }

        private int _Num1 = 1;

        public int Num1
        {
            get { return _Num1; }
            set { _Num1 = value; RaisePropertyChanged(); }
        }
        private double _ShopCountPrice;

        public double ShopCountPrice
        {
            get { return _ShopCountPrice; }
            set { _ShopCountPrice = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<ShoppingEntity> shoppingSource
        {
            get { return _shoppingEntities; }
            set { _shoppingEntities = value; RaisePropertyChanged(); }
        }
        public DelegateCommand<object> NavigateCommand { get; set; }
        public DelegateCommand<object> ExecuteAddCommand { get; set; }
        public DelegateCommand<object> ExecuteRemCommand { get; set; }

        public DelegateCommand commandTest { get; set; }
        public ShoppingViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            NavigateCommand = new DelegateCommand<object>(test);
            shoppingSource = new ObservableCollection<ShoppingEntity>();
            ExecuteAddCommand = new DelegateCommand<object>(add);
            ExecuteRemCommand = new DelegateCommand<object>(rem);
            commandTest = new DelegateCommand(addShop);
            for (int i = 0; i < 15; i++)
            {
                ShoppingEntity shoppingEntity = new ShoppingEntity()
                {
                    Name = "可口可乐" + i,
                    Num = 10,
                    Price = 3.00,
                    CountPrice = 3.00
                };
                shoppingSource.Add(shoppingEntity);
            }
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    double count = 0;
                    foreach (var item in shoppingSource)
                    {
                        count += item.Num * item.Price;
                    }
                    ShopCountPrice = count;
                }
            });
        }
        private void addShop()
        {
            ShoppingEntity shoppingEntity = new ShoppingEntity()
            {
                Name = "百世可乐",
                Num = 1,
                Price = 5.00,
                CountPrice = 5.00
            };
            shoppingSource.Add(shoppingEntity);
            //var ss = shoppingSource.Where((a) => a.Name == shoppingEntity.Name);

            //if (ss.Count() >= 1)
            //{
            //    List<ShoppingEntity> shoppingEntities = shoppingSource.Where(a => a.Name == shoppingEntity.Name).ToList<ShoppingEntity>();
            //    shoppingEntities[0].Num++;
            //    shoppingEntities[0].CountPrice = shoppingEntities[0].Num * shoppingEntities[0].Price;
            //}
            //else
            //{
            //    shoppingSource.Add(shoppingEntity);
            //}
        }

        /// <summary>
        /// 商品数量减一
        /// </summary>
        /// <param name="obj"></param>
        private void rem(object obj)
        {
            ContentPresenter b = obj as ContentPresenter;
            ShoppingEntity ss = b.DataContext as ShoppingEntity;
            if (ss != null)
            {
                if (ss.Num > 1)
                {
                    ss.Num--;
                    ss.CountPrice = ss.Price * ss.Num;
                }

                Console.WriteLine(ss.Name);
            }
        }

        private void add(object obj)
        {
            ContentPresenter b = obj as ContentPresenter;

            ShoppingEntity ss = b.DataContext as ShoppingEntity;
            if (ss != null)
            {

                ss.Num++;
                ss.CountPrice = ss.Price * ss.Num;


                Console.WriteLine(ss.Name);
            }
        }

        private void test(object obj)
        {
            ContentPresenter b = obj as ContentPresenter;

            ShoppingEntity ss = b.DataContext as ShoppingEntity;
            if (ss != null)
            {
                //ss.Num++;
                ss.CountPrice = ss.Price * ss.Num;
                Console.WriteLine(ss.Name);
            }

            // ShoppingEntity shoppingEntity11= b.DataContext as ShoppingEntity;



            ////MessageBox.Show(selectindex.ToString());
            //ShoppingEntity shoppingEntity = shoppingSource[selectindex];
            ////MessageBox.Show(shoppingEntity.Name);
        }
    }
}
