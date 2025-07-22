using Syncfusion.Maui.Toolkit.Charts;
using System.Globalization;

namespace CircularTooltip
{
    public class ItemsSourceConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var data = value as List<object>;
                if (data != null && data.Count > 5)
                {
                    var data_list = data.Where(x => data.IndexOf(x) < 6).ToList();

                    string name = "Others";
                    double yvalue = data.Where(x => data.IndexOf(x) >= 6).Sum(x => (x is ChartDataModel model) ? model.Value : 0);
                    double size = data.Where(x => data.IndexOf(x) >= 6).Sum(x => (x is ChartDataModel model) ? model.Size : 0);
                    data_list.Add(new ChartDataModel(name, yvalue, size));

                    return data_list;
                }
                else if (data != null)
                    return data;
                else
                {
                    return new List<object>() { value };
                }
            }

            return new List<object>();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class StringFormatConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null && value is ChartDataModel model)
            {
                if (parameter is PieSeries series)
                {
                    switch (series.GroupMode)
                    {
                        case PieGroupMode.Percentage:
                            return string.Format("{0:P0}", model.Size);
                        default:
                            return string.Format("${0:F2} T", model.Value);
                    }
                }
            }

            return "";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
