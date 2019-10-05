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
using WeatherApp.Model.WeatherModel;

namespace WeatherApp.Pages.Weather
{
    public class DetailsModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;

        public WeatherModel WeatherModel { get; set; }
        public string RequestContent { get; set; }

        public DetailsModel(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> OnGet(int cityId)
        {
            var apiKey = _configuration.GetSection("ApiKey").Value;

            string url = $"https://api.openweathermap.org/data/2.5/weather?";

            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["id"] = cityId.ToString();
            query["units"] = "metric";
            query["appid"] = apiKey;
            uriBuilder.Query = query.ToString();
            url = uriBuilder.ToString();

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(new Uri(url));


            if (response.IsSuccessStatusCode)
            {
                RequestContent = await response.Content.ReadAsStringAsync();

                JObject requestObject = JObject.Parse(RequestContent);
                var value = requestObject.ToString(Formatting.None);

                WeatherModel = JsonConvert.DeserializeObject<WeatherModel>(value);

                return Page();
            }
            else
            {
                return RedirectToPage("../Shared/NotFound");
            }
        }
    }
}