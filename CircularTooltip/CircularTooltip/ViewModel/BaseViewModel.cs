using System.Collections.ObjectModel;

namespace CircularTooltip
{
    public class BaseViewModel 
    {
        public ObservableCollection<ChartDataModel> GroupToData { get; set; }
        public List<Brush> CustomBrushes { get; set; }

        [Obsolete]
        public BaseViewModel()
        {
            GroupToData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("US",51.30,0.39),
                new ChartDataModel("China",20.90,0.16),
                new ChartDataModel("Japan",11.00,0.08),
                new ChartDataModel("France",4.40,0.03),
                new ChartDataModel("UK",4.30,0.03),
                new ChartDataModel ("Canada",4.00,0.03),
                new ChartDataModel("Germany",3.70,0.03),
                new ChartDataModel("Italy",2.90,0.02),
                new ChartDataModel("Brazil",2.40,0.02),
                new ChartDataModel("South Korea",2.20,0.02),
                new ChartDataModel("Australia",2.20,0.02),
                new ChartDataModel("Netherlands",1.90,0.01),
                new ChartDataModel("Spain",1.90,0.01),
                new ChartDataModel("India",1.30,0.01),
                new ChartDataModel("Ireland",1.00,0.01),
                new ChartDataModel("Mexico",1.00,0.01),
                new ChartDataModel("Luxembourg",0.90,0.01),
            };

            CustomBrushes = new List<Brush>();
            CustomBrushes.Add(new SolidColorBrush(Color.FromHex("#92229A")));
            CustomBrushes.Add(new SolidColorBrush(Color.FromHex("#2F8627")));
            CustomBrushes.Add(new SolidColorBrush(Color.FromHex("#F6991E")));
            CustomBrushes.Add(new SolidColorBrush(Color.FromHex("#A4382D")));
        }
    }
}
