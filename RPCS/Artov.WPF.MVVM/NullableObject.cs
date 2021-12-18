using Artov.WPF.MVVM.Core.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace Artov.WPF.MVVM
{
    public class NullableObject : MultiConverterBase<NullableObject>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 3)
                throw new ArgumentOutOfRangeException(nameof(values), "values count should be equal to 3");

            if (values[0] == DependencyProperty.UnsetValue ||
                values[1] == DependencyProperty.UnsetValue ||
                values[2] == DependencyProperty.UnsetValue)
            {
                return DependencyProperty.UnsetValue;
            }

            return values[0] == null ? values[1] : values[2];
        }
    }
}
