using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestArbitageBotOnAPI.Converters
{
    public class ConverterIsRunToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = "Остановлен | Start";

            if (value is bool)
            {
                if ((bool)value == true)
                {
                    str = "Запущен | Stop";
                }

            }
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
