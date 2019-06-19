using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;



namespace NumberBox.Converters
{
    public class NullableBooleanToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool?)
            {
                return (bool)value;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is bool)
                return (bool)value;
            return false;
        }
    }

    public class StringToNumberBoxSpinButtonPlacementModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is String)
            {
                switch (value)
                {
                    case "Hidden":
                        return NumberBoxSpinButtonPlacementMode.Hidden;
                    case "Inline":
                        return NumberBoxSpinButtonPlacementMode.Inline;
                }
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is NumberBoxSpinButtonPlacementMode)
            {
                switch (value)
                {
                    case NumberBoxSpinButtonPlacementMode.Hidden:
                        return "Hidden";
                    case NumberBoxSpinButtonPlacementMode.Inline:
                        return "Inline";
                }
            }
            return false;
        }
    }


    public class StringToNumberBoxMinMaxModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is String)
            {
                switch (value)
                {
                    case "None":
                        return NumberBoxMinMaxMode.None;
                    case "MinEnabled":
                        return NumberBoxMinMaxMode.MinEnabled;
                    case "MaxEnabled":
                        return NumberBoxMinMaxMode.MaxEnabled;
                    case "MinAndMaxEnabled":
                        return NumberBoxMinMaxMode.MinAndMaxEnabled;
                    case "WrapEnabled":
                        return NumberBoxMinMaxMode.WrapEnabled;
                }
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is NumberBoxMinMaxMode)
            {
                switch (value)
                {
                    case NumberBoxMinMaxMode.None:
                        return "None";
                    case NumberBoxMinMaxMode.MinEnabled:
                        return "MinEnabled";
                    case NumberBoxMinMaxMode.MaxEnabled:
                        return "MaxEnabled";
                    case NumberBoxMinMaxMode.MinAndMaxEnabled:
                        return "MinAndMaxEnabled";
                    case NumberBoxMinMaxMode.WrapEnabled:
                        return "WrapEnabled";
                }
            }
            return false;
        }
    }


}