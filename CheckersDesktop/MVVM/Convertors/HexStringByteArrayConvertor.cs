using System;
using System.Globalization;

namespace CheckersDesktop.MVVM.Convertors;

public class HexStringByteArrayConvertor : BaseValueConverter<HexStringByteArrayConvertor>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is byte[] bytes)
            return System.Convert.ToHexString(bytes);
        return null!; // its bad, but...
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string str)
            return System.Convert.FromHexString(str);
        return null!; // its bad, but...
    }
}