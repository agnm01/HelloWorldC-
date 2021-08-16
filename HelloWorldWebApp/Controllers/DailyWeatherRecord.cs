using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Controllers
{
    public class DailyWeatherRecord
    {

        public DailyWeatherRecord(DateTime Day, double temperature, WeatherType Type)
        {
            this.Day = Day;
            this.Temperature = Temperature;
            this.Type = Type;
        }

        public float Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Day { get; set; }
    }
}
