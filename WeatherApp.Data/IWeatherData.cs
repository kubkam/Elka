using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Core;

namespace WeatherApp.Data
{
    public interface IWeatherData
    {
        IEnumerable<Core.City> GetWeathersByCity(string city);
    }
}
