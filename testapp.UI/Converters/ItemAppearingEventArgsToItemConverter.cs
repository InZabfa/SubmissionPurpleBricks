using System;
using System.Globalization;
using Xamarin.Forms;

namespace testapp.UI.Converters
{
    public class ItemAppearingEventArgsToItemConverter : IValueConverter
    {
        public static ItemAppearingEventArgsToItemConverter Instance = new ItemAppearingEventArgsToItemConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as ItemVisibilityEventArgs;
            return eventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
