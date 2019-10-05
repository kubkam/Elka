namespace WeatherApp.Model.ForecastModel
{
    public class MainForecast
    {
        public decimal temp { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }
        public decimal pressure { get; set; }
        public decimal sea_level { get; set; }
        public decimal grnd_level { get; set; }
        public decimal humidity { get; set; }
        public decimal temp_kf { get; set; }
    }
}
