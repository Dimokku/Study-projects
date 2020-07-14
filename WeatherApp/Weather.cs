using Newtonsoft.Json;
using System;
using System.Device.Location;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WeatherApp
{
    public class Weather
    {
        public OpenWeatherOneCallAPI.OpenWeatherOneCallAPI GetWeather(GeoCoordinate coordinate)
        {
            string appid = "e67f327620e3cc056d936f8d1fbf20fd";

            string url;

            if (coordinate != null)
                url = $"https://api.openweathermap.org/data/2.5/onecall?units=metric&lat={coordinate.Latitude}&lon={coordinate.Longitude}&appid={appid}";
            else
                throw new Exception();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = streamReader.ReadToEnd()) != null)
                    {
                        OpenWeatherOneCallAPI.OpenWeatherOneCallAPI weather = 
                            JsonConvert.DeserializeObject<OpenWeatherOneCallAPI.OpenWeatherOneCallAPI>(line);
                        return weather;
                    }
                }
            }
            catch
            {
               MessageBox.Show("Failed to connect to the service. Check your internet connection. You may need a VPN.");
            }

            return null;
        }

        public OpenWeather.OpenWeather GetOpenWeatherByCoord(GeoCoordinate coord)
        {
            try
            {
                string appid = "e67f327620e3cc056d936f8d1fbf20fd";
                string url = $"http://api.openweathermap.org/data/2.5/weather?units=metric&lat={coord.Latitude}&lon={coord.Longitude}&appid={appid}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = streamReader.ReadToEnd()) != null)
                    {
                        OpenWeather.OpenWeather weather =
                            JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(line);
                        return weather;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to connect to the service.Check your internet connection.You may need a VPN.", "Warning");
            }

            return null;
        }

        public OpenWeather.OpenWeather GetOpenWeatherByCity(string city)
        {
            try
            {
                string appid = "e67f327620e3cc056d936f8d1fbf20fd";
                string url = $"http://api.openweathermap.org/data/2.5/weather?units=metric&q={city}&appid={appid}";


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = streamReader.ReadToEnd()) != null)
                    {
                        OpenWeather.OpenWeather weather =
                            JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(line);
                        return weather;
                    }
                }
            }

            catch
            {
                MessageBox.Show("Failed to connect to the service.Check your internet connection.You may need a VPN.", "Warning");             
            }

            return null;
        }
    }
}
