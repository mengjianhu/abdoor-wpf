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
 * 文 件 名:  IntToStringSexConverter
 * 描    述:  int 类型转为string类型 当int为 0 时 转为男  1转为女
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/29 14:01:51
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/29 14:01:51
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Converters
{
    /// <summary>
    /// 性别转换器
    /// </summary>
    public class IntToStringSexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int result))
            {
                if (result == 0)
                    return "男";
                if (result == 1)
                    return "女";
            }
            return "未知";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
