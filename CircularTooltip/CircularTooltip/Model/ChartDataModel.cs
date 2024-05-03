namespace CircularTooltip
{
    public class ChartDataModel
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double Size { get; set; }

        public ChartDataModel(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }

    }
}