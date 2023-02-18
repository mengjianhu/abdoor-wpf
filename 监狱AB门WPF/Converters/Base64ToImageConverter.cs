using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  Base64ToImage
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/30 8:58:50
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/30 8:58:50
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Converters
{
    public class Base64ToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var base64String = (String)value;
            if (string.IsNullOrEmpty(base64String))
                return null;
            byte[] bytes = System.Convert.FromBase64String(base64String);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            ImageSource source = null;
            source = (ImageSource)imageSourceConverter.ConvertFrom(ms);

            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
