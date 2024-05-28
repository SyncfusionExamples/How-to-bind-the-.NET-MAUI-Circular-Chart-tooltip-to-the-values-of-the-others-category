# How to bind the .NET MAUI Circular Chart tooltip to the values of the others categorys
This repository contains a sample project demonstrating how to bind the .NET MAUI Circular Chart tooltip to the value of the **"Others"** category using Syncfusion controls.

**Syncfusion Circular Chart Control**

The [.NET MAUI Circular Charts](https://www.syncfusion.com/maui-controls/maui-circular-charts) provides a perfect way to visualize data with a high level of user involvement that focuses on development, productivity, and simplicity of use. Chart also provides a wide variety of charting features that can be used to visualize large quantities of data, as well as flexibility in data binding and user customization.

**Define the Custom Tooltip Template**

Create a custom tooltip template in XAML, consisting of a vertical stack layout with a bindable layout for dynamic data population.

**Implement Converters**

 Develop C# converters to handle data manipulation and formatting for the tooltip, including managing the tooltip data and formatting text based on selected group mode.

**Integrate Custom Tooltip with the Chart**

 Incorporate the custom tooltip template into the circular chart by assigning the TooltipTemplate property of the chart series.

**Output**

![Presentation](https://github.com/SyncfusionExamples/How-to-bind-the-.NET-MAUI-Circular-Chart-tooltip-to-the-values-of-the-others-category/assets/113962276/40c8b5c5-a6c3-43ab-b0db-58d7e33e34ea)


For a step-by-step procedure, refer to the Knowledge base: [How to bind the .NET MAUI Circular Chart tooltip to the values of the "Others" category(SfCircularChart)?]()

### Troubleshooting
**Path too long exception**

If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to a shorter name before building the project.

