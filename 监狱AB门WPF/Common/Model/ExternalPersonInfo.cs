using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  ExternalPersonInfo
 * 描    述:  外来人员审批类
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/29 11:25:58
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/29 11:25:58
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Common.Model
{
    public class ExternalPersonInfo:BindableBase
    {
		private string _name;
		/// <summary>
		/// 姓名
		/// </summary>
		public string name
		{
			get { return _name; }
			set { _name = value;RaisePropertyChanged(); }
		}
		private string _typeExternalPerson;
		/// <summary>
		/// 人员类型
		/// </summary>
		public string typeExternalPerson
        {
			get { return _typeExternalPerson; }
			set { _typeExternalPerson = value; }
		}

		private string _idCardNum;
		/// <summary>
		/// 身份证号
		/// </summary>
		public string idCardNum
        {
			get { return _idCardNum; }
			set { _idCardNum = value; RaisePropertyChanged(); }
		}
		private string _sex;
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			get { return _sex; }
			set { _sex = value;RaisePropertyChanged(); }
		}
		private string _busNum;
		/// <summary>
		/// 车牌号
		/// </summary>
		public string busNum
        {
			get { return _busNum; }
			set { _busNum = value; RaisePropertyChanged(); }
		}
		private bool? _isPass;
		/// <summary>
		/// 是否允许通过
		/// </summary>
		public bool? isPass
		{
			get { return _isPass; }
			set { _isPass = value; RaisePropertyChanged(); }
		}
		private string _base64RealPhoto;
		/// <summary>
		/// 实时照片（base64位）
		/// </summary>
		public string base64RealPhoto
        {
			get { return _base64RealPhoto; }
			set { _base64RealPhoto = value; RaisePropertyChanged(); }
        }
		private string _identiPhoto;
        /// <summary>
        /// 证件照片（base64位）
        /// </summary>
        public string identiPhoto
        {
			get { return _identiPhoto; }
			set { _identiPhoto = value; RaisePropertyChanged(); }
        }
		private string _phone;

		public string phone
		{
			get { return _phone; }
			set { _phone = value;RaisePropertyChanged(); }
		}
		private string _applicationReason;
		/// <summary>
		/// 申请理由
		/// </summary>
		public string applicationReason
        {
			get { return _applicationReason; }
			set { _applicationReason = value; RaisePropertyChanged(); }
		}
        private string _refuseReason;
        /// <summary>
        /// 拒绝理由 
        /// </summary>
        public string refuseReason
        {
            get { return _refuseReason; }
            set { _refuseReason = value; RaisePropertyChanged(); }
        }

    }
}
