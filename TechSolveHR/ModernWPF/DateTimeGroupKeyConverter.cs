﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace TechSolveHR.ModernWPF;

public class DateTimeGroupKeyconverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        ((DateTimeOffset)value).ToString("MMMM");

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}