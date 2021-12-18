using Artov.WPF.MVVM.Core.Converter;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Windows;

namespace Artov.WPF.MVVM
{
    internal sealed class ArithmeticCombinatorConverter : MultiConverterBase<ArithmeticCombinatorConverter>
    {
        public enum ArithmeticOperations
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Mod
        }

        public override object Convert([NotNull] object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (values.Length == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(values));

            if (!(Enum.IsDefined(typeof(ArithmeticOperations), parameter)))
            {
                throw new ArgumentException("parameter should be of type Operations", nameof(parameter));
            }

            if (values.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(values), "values count should be equal to 2");
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
                ArithmeticOperations.Add => leftOperand + rightOperand,
                ArithmeticOperations.Subtract => leftOperand - rightOperand,
                ArithmeticOperations.Multiply => leftOperand * rightOperand,
                ArithmeticOperations.Divide => leftOperand / rightOperand,
                ArithmeticOperations.Mod => leftOperand % rightOperand,
                _ => throw new ArgumentException("Invalid operation", nameof(parameter))
            };
        }
    }
}
