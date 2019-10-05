using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherApp.Model.ForecastModel;

namespace WeatherApp.Pages.Forecast
{
    public class ForecastCallModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public ForecastModel ForecastModel { get; set; }

        public string RequestContent { get; set; }

        public ForecastCallModel(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public void OnGet()
        {

        }

        public async Task OnGetDownload()
        {
            var apiKey = _configuration.GetSection("ApiKey").Value;

            string url = "https://api.openweathermap.org/data/2.5/forecast?q=Warsaw,PL&units=metric";

            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["APPID"] = apiKey;
            uriBuilder.Query = query.ToString();
            url = uriBuilder.ToString();

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(new Uri(url));

            if (response.IsSuccessStatusCode)
            {
                RequestContent = await response.Content.ReadAsStringAsync();

                JObject requestObject = JObject.Parse(RequestContent);
                var value = requestObject.ToString(Formatting.None);

                ForecastModel = JsonConvert.DeserializeObject<ForecastModel>(value);
            }
            else
            {
                Response.Redirect("../Shared/NotFound");
            }
        }
    }
}