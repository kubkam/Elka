using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WeatherApp.Core;
using WeatherApp.Model.WeatherModel;

namespace WeatherApp.Data
{
    public class SqlCityData : IWeatherData
    {
        private readonly CityDbContext _db;

        public SqlCityData(CityDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Core.City> GetWeathersByCity(string city)
        {
            var query = _db.Cities
                .Include(c => c.coord)
                .Where(c => string.IsNullOrEmpty(city) || c.name.Contains(city))
                .OrderBy(c => c.name);

            return query;
        }
    }
}
