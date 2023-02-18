using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  TimeHelp
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/12/2 15:15:03
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/12/2 15:15:03
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Common.Help
{
    public static class TimeHelp
    {
        public static int GetDiffSecond(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan ts = dateTime1.Subtract(dateTime2).Duration();
            return Convert.ToInt32( ts.TotalSeconds);
        }
        public static int CompanyDate(DateTime  dateStr1, DateTime dateStr2 )
        {
            //将日期字符串转换为日期对象
            DateTime t1 = Convert.ToDateTime(dateStr1);
            DateTime t2 = Convert.ToDateTime(dateStr2);
            //通过DateTIme.Compare()进行比较（）
            int compNum = DateTime.Compare(t1, t2);
            return compNum;
            //t1> t2
            //if (compNum > 0)
            //{
            //    msg = "t1:(" + dateStr1 + ")大于" + "t2(" + dateStr2 + ")";
            //}
            ////t1= t2
            //if (compNum == 0)
            //{
            //    msg = "t1:(" + dateStr1 + ")等于" + "t2(" + dateStr2 + ")";
            //}
            ////t1< t2
            //if (compNum < 0)
            //{
            //    msg = "t1:(" + dateStr1 + ")小于" + "t2(" + dateStr2 + ")";
            //}
        }
    }
}
