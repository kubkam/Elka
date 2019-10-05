using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherApp.Core;
using WeatherApp.Data;
using WeatherApp.Model.WeatherModel;

namespace WeatherApp.Pages.Weather
{
    public class WeatherCallModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly IWeatherData _weatherData;
        public IEnumerable<Core.City> Cities { get; set; }

        public WeatherModel WeatherModel { get; set; }

        public string RequestContent { get; set; }

        [BindProperty(SupportsGet = true)]

        public string SearchTerm { get; set; } = "Warsaw";

        public WeatherCallModel(IHttpClientFactory clientFactory, IConfiguration configuration,
            IWeatherData weatherData)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _weatherData = weatherData;
        }

        public void OnGet()
        {
            if (SearchTerm.Length >= 3)
                Cities = _weatherData.GetWeathersByCity(SearchTerm);

        }
    }
}