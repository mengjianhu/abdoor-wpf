using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  ConvertList2ObserveableCollectionHelp
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/12/12 14:44:05
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/12/12 14:44:05
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 智能AB门WPF.Common.Help
{
    public class ConvertList2ObserveableCollectionHelp
    {
        public static ObservableCollection<T> ConvertList2ObserveableCollection<T>(List<T> temp)
        {
            ObservableCollection<T> scheduleInProcessOwner = new ObservableCollection<T>();
            List<T> tempList = new List<T>();
            if (temp != null && temp.Count() > 0)
            {
                tempList = temp.ToList();
            }
            tempList.ForEach(p => scheduleInProcessOwner.Add(p));

            return scheduleInProcessOwner;
        }
    }
}
