using Newtonsoft.Json;

namespace WeatherApp.Model
{
    public class Rain
    {
        [JsonProperty("1h")]
        public decimal OneHour { get; set; }

        [JsonProperty("3h")]
        public decimal ThreeHour { get; set; }
    }
}
