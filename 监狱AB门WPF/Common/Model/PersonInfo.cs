using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  PersonInfo
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/28 10:06:01
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/28 10:06:01
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Common.Model
{
    public  class PersonInfo:BindableBase
    {
		private string _name;

		public string name
		{
			get { return _name; }
			set { _name = value; RaisePropertyChanged(); }
		}
		private DateTime _hyTime;

		public DateTime hyTime
        {
			get { return _hyTime; }
			set { _hyTime = value; RaisePropertyChanged(); }
		}


		private string _sex;

        public string sex
        {
            get { return _sex; }
            set { _sex = value; RaisePropertyChanged(); }
        }

		private string _phone;

		public string phone
        {
			get { return _phone; }
			set { _phone = value; RaisePropertyChanged(); }
		}
		private string _bh;

		public string bh
		{
			get { return _bh; }
			set { _bh = value; RaisePropertyChanged(); }
		}


	}
}
