using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeatherOneCallAPI
{
    public class Current
    {
        public long Dt { get; set; }
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public int Pressure { get; set; }
        public double Humidity { get; set; }
        public double Wind_Speed { get; set; }
        public double Wind_Deg { get; set; }
        public Weather[] Weather { get; set; }
    }
}
