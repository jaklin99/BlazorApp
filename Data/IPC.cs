namespace BlazorApp.Data
{
    public class IPC
    {
        public string? Ipc { get; set; }

        public int DataFactory { get; set; }

        public DateOnly Date { get; set; }

        public double AvgValue { get; set; }

        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string? MetricId { get; set; }
        public int CpuMHz { get; set; }

    }
}
