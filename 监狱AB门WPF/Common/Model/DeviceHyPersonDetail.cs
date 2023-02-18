using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  DeviceHyPersonDetail
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/12/12 13:57:47
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/12/12 13:57:47
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 智能AB门WPF.Common.Model
{
    public  class DeviceHyPersonDetail:BindableBase
    {
		private string _mac;

		public string mac
		{
			get { return _mac; }
			set { _mac = value;RaisePropertyChanged(); }
		}
        private string _deviceIp;

        public string ipaddress
        {
            get { return _deviceIp; }
            set { _deviceIp = value; RaisePropertyChanged(); }
        }
		private string _name;

		public string name
		{
			get { return _name; }
			set { _name = value; RaisePropertyChanged(); }
		}
		private string _des;
		/// <summary>
		/// 设备描述
		/// </summary>
		public string des
		{
			get { return _des; }
			set { _des = value; RaisePropertyChanged(); }
		}
		private string _lastTime;

		public string lastTime
        {
			get { return _lastTime; }
			set { _lastTime = value; RaisePropertyChanged(); }
		}
        private string _faceId;

        public string faceId
        {
            get { return _faceId; }
            set { _faceId = value; RaisePropertyChanged(); }
        }
        private string _similarity;

        public string similarity
        {
            get { return _similarity; }
            set { _similarity = value; RaisePropertyChanged(); }
        }
        private string _dateTime;

        public string dateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; RaisePropertyChanged(); }
        }
		private string _deviceName;

		public string deviceName
        {
			get { return _deviceName; }
			set { _deviceName = value; RaisePropertyChanged(); }
		}

	}
}
