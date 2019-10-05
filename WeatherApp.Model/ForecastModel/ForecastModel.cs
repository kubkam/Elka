using System.Collections.Generic;

namespace WeatherApp.Model.ForecastModel
{
    public class ForecastModel
    {
        public List<Forecast> list { get; set; }

        public City city { get; set; }

    }
}
