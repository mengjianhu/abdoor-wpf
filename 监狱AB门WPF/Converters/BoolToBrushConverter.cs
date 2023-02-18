using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  BoolToBrushConverter
 * 描    述:  把bool 转为Brush
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/30 13:45:57
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/30 13:45:57
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is bool)
                {
                    if ((bool)value)
                    {
                        return new SolidColorBrush(Colors.Orange);
                    }
                    else
                    {
                        return new SolidColorBrush(Colors.Red);
                    }
                }
            }
            return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
