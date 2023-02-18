using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  Result
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/12/2 14:27:16
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/12/2 14:27:16
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Common.Model
{
    public class Result<T>
    {
        /// <summary>
        /// code 状态码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public ObservableCollection<T> data { get; set; }
    }
}
