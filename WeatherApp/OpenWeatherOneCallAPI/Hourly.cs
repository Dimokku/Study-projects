using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeatherOneCallAPI
{
    public class Hourly
    {
        public long Dt { get; set; }
        public double Temp { get; set; }
        public double Wind_Speed { get; set; }
        public Weather[] Weather { get; set; }
    }
}
