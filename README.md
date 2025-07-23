# How to bind the .NET MAUI Circular Chart tooltip to the values of the others categorys
In this article, we can learn how to show tooltips for the "Others" category in a [.NET MAUI Circular Chart](https://www.syncfusion.com/maui-controls/maui-circular-charts). We'll use a custom tooltip template to display information when hovering over chart segments.


**Step 1: Initializing the PieSeries**

First, we set up the PieSeries in the Circular Chart with [**GroupTo**](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.PieSeries.html#Syncfusion_Maui_Toolkit_Charts_PieSeries_GroupTo) support. The [**GroupTo**](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.PieSeries.html#Syncfusion_Maui_Toolkit_Charts_PieSeries_GroupTo) property helps group smaller segments into a single "Others" category.

**XAML**

 ```xaml
<chart:SfCircularChart>
    ....
    <chart:SfCircularChart.Series>
        <chart:PieSeries GroupTo="10"
                         ItemsSource="{Binding GroupToData}"
                         XBindingPath="Name" YBindingPath="Value">
        </chart:PieSeries>
    </chart:SfCircularChart.Series>
</chart:SfCircularChart> 
 ```


**Step 2: Explaining the Default Tooltip with "Others"**

We have data segments that fall below a certain threshold, they are grouped together into the **"Others"** category. The default tooltip view for this "Others" category provides users with a summarized insight into these grouped segments.

When data segments are too small (fall below the [**GroupTo**](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.PieSeries.html#Syncfusion_Maui_Toolkit_Charts_PieSeries_GroupTo) value), they are grouped into an "Others" category. The default tooltip for this "Others" category gives a summary of these grouped segments.

![image.png](https://support.syncfusion.com/kb/agent/attachment/article/15959/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIyNzM2Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.wkC97m7xyxshcGoROR9U34Z8Z1hS0n5w6MTXKee64lo)


**Step 3: Define the Custom Tooltip Template**

Next, we create a custom tooltip template called **"tooltipTemplate"**. This template uses a vertical stack layout to display data dynamically.


**XAML**
 
 ```XAML
<ContentPage.Resources>
    <ResourceDictionary>
        <!-- Define converters -->
        <local:ItemsSourceConverter x:Key="valueConvert"/>
        <local:StringFormatConverter x:Key="StingConvert"/>

        <!-- Define tooltip template -->
        <DataTemplate x:Key="tooltipTemplate">
            <VerticalStackLayout BindableLayout.ItemsSource="{Binding Item, Converter={StaticResource valueConvert}}">
                <BindableLayout.ItemTemplate>
                    <DataTemplate>
                        <Grid ColumnDefinitions="*,Auto">
                            <Label Text="{Binding Name}" Grid.Column="0"/>
                            <Label Text="{Binding Converter={StaticResource StingConvert}, ConverterParameter={x:Reference pieSeries1}}" Grid.Column="2" />
                        </Grid>
                    </DataTemplate>
                </BindableLayout.ItemTemplate>
            </VerticalStackLayout>
        </DataTemplate>
    </ResourceDictionary>
</ContentPage.Resources>

 ```



**Step 4: Implement Converters**

We need two converters in C# for handling data and formatting the tooltip text.

The **ItemsSourceConverter** is designed to manipulate the data source bound to the chart's tooltip. Its primary goal is to handle the grouping of smaller data segments into the "Others" category and prepare the data for display in the tooltip.

The **StringFormatConverter** is aimed at formatting the tooltip text based on the selected group mode of the pie series in the chart. It ensures that the tooltip displays data values in a user-friendly and understandable format.

**C#**
 
 ```C#
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
 ```


**Step 5: Integrate Custom Tooltip with the Chart**

Finally, we add the custom tooltip template to the Circular Chart by setting the  [**TooltipTemplate**](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.ChartSeries.html#Syncfusion_Maui_Toolkit_Charts_ChartSeries_TooltipTemplate) property of the [**PieSeries**](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.PieSeries.html).

**XAML**
 ```XAML
<!-- XAML Circular Chart -->
<chart:PieSeries TooltipTemplate="{StaticResource tooltipTemplate}" 
                 GroupTo="10"
                 ItemsSource="{Binding GroupToData}" XBindingPath="Name" YBindingPath="Value">
</chart:PieSeries>

 ```

**Output**

![Presentation](https://github.com/user-attachments/assets/b75cd396-cde2-499a-898d-d6e3fe0b8839)

### Troubleshooting
**Path too long exception**

If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to a shorter name before building the project.

For more details, refer to the KB on [how to bind the .NET MAUI Circular Chart tooltip to the values of the others categorys]()

