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
 * 文 件 名:  NoDataStringConverter
 * 描    述:  转换器，用于当datagrid 数据源为空时   显示暂无数据
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/29 13:52:02
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/29 13:52:02
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Converters
{
    public class NoDataStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) == 0 ? "暂无数据" : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          return null;
        }
    }
}
