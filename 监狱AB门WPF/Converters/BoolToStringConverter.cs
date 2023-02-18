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
 * 文 件 名:  BoolToStringConverter
 * 描    述:  bool 类型转换器 ；用于把bool 类型转换为string   当为true时 显示同意  当为FALSE 是显示拒绝
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/29 13:54:40
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/29 13:54:40
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Converters
{
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is bool)
                {
                    if ((bool)value)
                    {
                        return "同意";
                    }
                    else
                    {
                        return "拒绝";
                    }
                }
            }
            return "未处理";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value.ToString() == "同意")
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
