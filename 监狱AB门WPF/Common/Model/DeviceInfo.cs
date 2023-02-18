using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  DeviceInfo
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/12/2 10:51:24
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/12/2 10:51:24
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Common.Model
{
    public class DeviceInfo:BindableBase
    {
		private string _deviceName;

		public string name
		{
			get { return _deviceName; }
			set { _deviceName = value;RaisePropertyChanged(); }
		}

        private string _deviceIp;

        public string ipaddress
        {
            get { return _deviceIp; }
            set { _deviceIp = value; RaisePropertyChanged(); }
        }
        private string _deviceState;

        public string lastTime
        {
            get { return _deviceState; }
            set { _deviceState = value; RaisePropertyChanged(); }
        }
        private string _mac;

        public string mac
        {
            get { return _mac; }
            set { _mac = value; RaisePropertyChanged(); }
        }

        private bool _isOnLine;

        public bool isOnLine
        {
            get { return _isOnLine; }
            set { _isOnLine = value; RaisePropertyChanged(); }
        }

    }
}
