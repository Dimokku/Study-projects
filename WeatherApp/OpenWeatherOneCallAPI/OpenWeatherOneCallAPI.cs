using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeatherOneCallAPI
{
    public class OpenWeatherOneCallAPI
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Timezone { get; set; }
        public Current Current { get; set; }
        public Hourly[] Hourly { get; set; }
        public Daily[] Daily { get; set; }
    }
}
