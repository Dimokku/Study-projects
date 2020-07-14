using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeather
{
    public class OpenWeather
    {
        public int Id { get; set; }
        public double Dt { get; set; } 
        public string Name { get; set; }
        public Weather[] Weather { get; set; }
        public Coord Coord { get; set; }
        public Sys Sys { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
    }
}
