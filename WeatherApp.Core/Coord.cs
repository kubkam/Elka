using System.Runtime.Serialization;

namespace WeatherApp.Core
{
    public class Coord
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        public float lon { get; set; }
        public float lat { get; set; }
    }
}