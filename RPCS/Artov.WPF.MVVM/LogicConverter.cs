using Artov.WPF.MVVM.Core.Converter;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Windows;

namespace Artov.WPF.MVVM
{
    public class LogicalConverter : MultiConverterBase<LogicalConverter>
    {
        public enum LogicalOperations
        {
            Or,
            And,
            Not
        }

        public override object Convert([NotNull] object[] values, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (values.Length == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(values));

            if (!(Enum.IsDefined(typeof(LogicalOperations), parameter)))
            {
                throw new ArgumentException("parameter should be of type Order Relation Operations",
                    nameof(parameter));
            }

            if (values.Length == 1 && parameter == (object)LogicalOperations.Not)
            {
                if (values[0] == DependencyProperty.UnsetValue)
                    return DependencyProperty.UnsetValue;
                else
                    return !(dynamic)values[0];
            }

            if (values[0] == DependencyProperty.UnsetValue ||
                values[1] == DependencyProperty.UnsetValue)
            {
                return DependencyProperty.UnsetValue;
            }

            var leftOperand = (dynamic)values[0];
            var rightOperand = (dynamic)values[1];

            return parameter switch
            {
                LogicalOperations.Or => leftOperand || rightOperand,
                LogicalOperations.And => leftOperand && rightOperand,
                _ => throw new ArgumentException("Invalid operation", nameof(parameter))
            };
        }
    }
}
