using System.Collections.Generic;

namespace WeatherApp.Model.ForecastModel
{
    public class Forecast
    {
        public double dt { get; set; }

        public MainForecast main { get; set; }

        public List<Weather> weather { get; set; }

        public Clouds clouds { get; set; }

        public Wind wind { get; set; }

        public Rain rain { get; set; }

        public Snow snow { get; set; }

        public string dt_txt { get; set; }

    }
}
