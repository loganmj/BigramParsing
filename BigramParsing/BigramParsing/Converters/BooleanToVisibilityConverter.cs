using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BigramParser.Converters
{
    /// <summary>
    /// Converts boolean values to Visibility values. This is used for data binding when the visibility
    /// of a control is dependent on boolean data from its viewmodel.
    /// </summary>
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a Visibility value.
        /// Allows the option to invert the bool.
        /// "true" = "Visibility.Visible".
        /// "false" = "Visibility.Collapsed".
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the invert parameter value, if available
            bool tempValue = (value is bool v && v) || value == null;
            bool invert;

            // If "true" is passed in, invert the bool
            try
            {
                invert = bool.Parse((string)parameter);
            }
            catch
            {
                invert = false;
            }

            return tempValue && !invert || !tempValue && invert ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a Visibility value into a boolean.
        /// "Visibility.Visible" = "true".
        /// "Visibility.Collapsed" = "false".
        /// "Visibility.Hidden" = "false".
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility visibility && visibility == Visibility.Visible;
        }
    }
}
