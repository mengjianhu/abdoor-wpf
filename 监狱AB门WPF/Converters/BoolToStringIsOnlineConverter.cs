using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  BoolToStringIsOnline
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/12/2 15:32:49
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/12/2 15:32:49
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Converters
{
    public class BoolToStringIsOnlineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is bool)
                {
                    if ((bool)value)
                    {
                        return "在线";
                    }
                    else
                    {
                        return "离线";
                    }
                }
            }
            return "未知";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value.ToString() == "在线")
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
