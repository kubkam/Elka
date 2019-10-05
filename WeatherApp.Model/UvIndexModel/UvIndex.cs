namespace WeatherApp.Model.UvIndexModel
{
    public class UvIndex
    {
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string date_iso { get; set; }
        public string date { get; set; }
        public decimal value { get; set; }
    }
}
