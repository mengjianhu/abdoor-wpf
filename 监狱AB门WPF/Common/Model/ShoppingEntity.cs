using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2023  All Rights Reserved.
 * 文 件 名:  ShoppingEntity
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2023-2-10 16:04:20
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2023-2-10 16:04:20
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 智能AB门WPF.Common.Model
{
    public class ShoppingEntity:BindableBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;RaisePropertyChanged(); }
        }
        private int _num;

        public int Num
        {
            get { return _num; }
            set { _num = value; RaisePropertyChanged(); }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; RaisePropertyChanged(); }
        }

        private double _countPrice;

        public double CountPrice
        {
            get { return _countPrice; }
            set { _countPrice = value; RaisePropertyChanged(); }
        }

       
    }
}
