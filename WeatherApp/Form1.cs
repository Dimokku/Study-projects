using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;
using System.Threading;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        Weather weather;
        OpenWeatherOneCallAPI.OpenWeatherOneCallAPI openWeatherOneAPI;
        GeoCoordinateWatcher watcher;
        GeoCoordinate coordinate;

        bool geoDetected = false;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Enabled = false;
            weather = new Weather();
            watcher = new GeoCoordinateWatcher();

            watcher.Start();

            Task.Run(() => GeoDetect());
        }

        private void GeoDetect()
        {
            if (coordinate == null)
            {
                label16.Text = "Status: device geodata definition...";
                label16.ForeColor = Color.Gray;
            }

            int seconds = 10;
            int step = progressBar1.Maximum / seconds;

            for (int i = 0; i < seconds; i++)
            {
                if (geoDetected == false)
                {
                    if (watcher.Status == GeoPositionStatus.Ready && !watcher.Position.Location.IsUnknown)
                    {
                        coordinate = watcher.Position.Location;
                        openWeatherOneAPI = weather.GetWeather(coordinate);

                        if (InvokeRequired)
                            Invoke(new Action(() => SetParameters()));
                        else SetParameters();

                        geoDetected = true;
                        break;
                    }
                }

                if (InvokeRequired)
                    Invoke(new Action(() => ProgressBar_Change(i * step)));
                else ProgressBar_Change(i * step);

                Thread.Sleep(1000);
            }

            if (geoDetected == false)
            {
                MessageBox.Show("Failed to determine your device’s location.\n" +
                                    "Please select a city yourself.");

                if (label16.InvokeRequired)
                    label16.Invoke(new Action(() =>
                    {
                        label16.Text = "Status: device geodata not defined.";
                        label16.ForeColor = Color.Red;
                    }));
                else
                {
                    label16.Text = "Status: device geodata not defined.";
                    label16.ForeColor = Color.Red;
                }
            }

            if (comboBox1.InvokeRequired)
                comboBox1.Invoke(new Action(() => comboBox1.Enabled = true));
            else
                comboBox1.Enabled = true;

            if (progressBar1.InvokeRequired)
                progressBar1.Invoke(new Action(() => progressBar1.Value = 0));
            else
                progressBar1.Value = 0;
        }

        private void ProgressBar_Change(int value)
        {
            progressBar1.Value = value;
        }

        private void SetParameters()
        {
            if (openWeatherOneAPI != null)
            {
                // Get OpenWeather to get info about the city (OpenWeatherOneCallAPI doesn't have it).
                GeoCoordinate coordinate = new GeoCoordinate(openWeatherOneAPI.Lat, openWeatherOneAPI.Lon);
                OpenWeather.OpenWeather openWeather = weather.GetOpenWeatherByCoord(coordinate);

                // Set current forecast.
                MainLabel.Text = "Condition: " + openWeatherOneAPI.Current.Weather[0].Main;
                DescriptionLabel.Text = "Description: " + openWeatherOneAPI.Current.Weather[0].Description;
                TemperatureLabel.Text = "Temperature: " + openWeatherOneAPI.Current.Temp + " ℃, feels like " + openWeatherOneAPI.Current.Feels_Like + " ℃";
                CityLabel.Text = "City: " + openWeather.Name + ", " + openWeather.Sys.Country;
                WeatherPicture.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Current.Weather[0].Icon}.png");
                DateLabel.Text = "Date: " + UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Current.Dt, openWeatherOneAPI.Timezone);

                HumidityLabel.Text = "Humidity: " + Convert.ToString(openWeatherOneAPI.Current.Humidity) + "%";
                PressureLabel.Text = "Pressure: " + Convert.ToString(openWeatherOneAPI.Current.Pressure) + " hPa";
                SpeedLabel.Text = "Speed: " + Convert.ToString(openWeatherOneAPI.Current.Wind_Speed) + "m/s";
                DegLabel.Text = "Deg: " + Convert.ToString(openWeatherOneAPI.Current.Wind_Deg) + "°";

                // Set hourly forecast.
                pictureBox1.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Hourly[0].Weather[0].Icon}.png");
                HourlyTempLabel1.Text = Convert.ToString(openWeatherOneAPI.Hourly[0].Temp) + " ℃";
                groupBox5.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Hourly[0].Dt, openWeatherOneAPI.Timezone).ToString("HH:mm");

                pictureBox2.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Hourly[3].Weather[0].Icon}.png");
                HourlyTempLabel2.Text = Convert.ToString(openWeatherOneAPI.Hourly[3].Temp) + " ℃";
                groupBox6.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Hourly[3].Dt, openWeatherOneAPI.Timezone).ToString("HH:mm");

                pictureBox3.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Hourly[6].Weather[0].Icon}.png");
                HourlyTempLabel3.Text = Convert.ToString(openWeatherOneAPI.Hourly[6].Temp) + " ℃";
                groupBox7.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Hourly[6].Dt, openWeatherOneAPI.Timezone).ToString("HH:mm");

                pictureBox4.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Hourly[9].Weather[0].Icon}.png");
                HourlyTempLabel4.Text = Convert.ToString(openWeatherOneAPI.Hourly[9].Temp) + " ℃";
                groupBox8.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Hourly[9].Dt, openWeatherOneAPI.Timezone).ToString("HH:mm");

                pictureBox5.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Hourly[12].Weather[0].Icon}.png");
                HourlyTempLabel5.Text = Convert.ToString(openWeatherOneAPI.Hourly[12].Temp) + " ℃";
                groupBox9.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Hourly[12].Dt, openWeatherOneAPI.Timezone).ToString("HH:mm");

                pictureBox6.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Hourly[15].Weather[0].Icon}.png");
                HourlyTempLabel6.Text = Convert.ToString(openWeatherOneAPI.Hourly[15].Temp) + " ℃";
                groupBox10.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Hourly[15].Dt, openWeatherOneAPI.Timezone).ToString("HH:mm");

                pictureBox7.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Hourly[18].Weather[0].Icon}.png");
                HourlyTempLabel7.Text = Convert.ToString(openWeatherOneAPI.Hourly[18].Temp) + " ℃";
                groupBox11.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Hourly[18].Dt, openWeatherOneAPI.Timezone).ToString("HH:mm");

                pictureBox8.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Hourly[21].Weather[0].Icon}.png");
                HourlyTempLabel8.Text = Convert.ToString(openWeatherOneAPI.Hourly[21].Temp) + " ℃";
                groupBox12.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Hourly[21].Dt, openWeatherOneAPI.Timezone).ToString("HH:mm");

                // Set daily forecast.
                pictureBox9.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Daily[0].Weather[0].Icon}.png");
                groupBox13.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Daily[0].Dt, openWeatherOneAPI.Timezone).ToString("dd.MM");
                label2.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[0].Temp.Min)) + " ℃";
                label3.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[0].Temp.Max)) + " ℃";

                pictureBox10.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Daily[1].Weather[0].Icon}.png");
                groupBox14.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Daily[1].Dt, openWeatherOneAPI.Timezone).ToString("dd.MM");
                label4.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[1].Temp.Min)) + " ℃";
                label5.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[1].Temp.Max)) + " ℃";

                pictureBox11.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Daily[2].Weather[0].Icon}.png");
                groupBox15.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Daily[2].Dt, openWeatherOneAPI.Timezone).ToString("dd.MM");
                label6.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[2].Temp.Min)) + " ℃";
                label7.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[2].Temp.Max)) + " ℃";

                pictureBox12.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Daily[3].Weather[0].Icon}.png");
                groupBox16.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Daily[3].Dt, openWeatherOneAPI.Timezone).ToString("dd.MM");
                label8.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[3].Temp.Min)) + " ℃";
                label9.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[3].Temp.Max)) + " ℃";

                pictureBox13.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Daily[4].Weather[0].Icon}.png");
                groupBox17.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Daily[4].Dt, openWeatherOneAPI.Timezone).ToString("dd.MM"); ;
                label10.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[4].Temp.Min)) + " ℃";
                label11.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[4].Temp.Max)) + " ℃";

                pictureBox14.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Daily[5].Weather[0].Icon}.png");
                groupBox18.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Daily[5].Dt, openWeatherOneAPI.Timezone).ToString("dd.MM");
                label12.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[5].Temp.Min)) + " ℃";
                label13.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[5].Temp.Max)) + " ℃";

                pictureBox15.Load($"http://openweathermap.org/img/w/{openWeatherOneAPI.Daily[6].Weather[0].Icon}.png");
                groupBox19.Text = UnixConverter.ConvertFromUnixTimestamp(openWeatherOneAPI.Daily[6].Dt, openWeatherOneAPI.Timezone).ToString("dd.MM");
                label14.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[6].Temp.Min)) + " ℃";
                label15.Text = Convert.ToString(Convert.ToInt32(openWeatherOneAPI.Daily[6].Temp.Max)) + " ℃";

                label16.Text = "Status: data ready.";
                label16.ForeColor = Color.Green;
                comboBox1.Enabled = true;
                progressBar1.Value = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label16.Text = "Status: defining weather data for a selected city...";
            label16.ForeColor = Color.Gray;

            string city = Convert.ToString(comboBox1.SelectedItem);

            Task.Run(() =>
            {
                OpenWeather.OpenWeather openWeather = weather.GetOpenWeatherByCity(city);

                if (openWeather != null)
                {
                    coordinate = new GeoCoordinate(openWeather.Coord.Lat, openWeather.Coord.Lon);

                    openWeatherOneAPI = weather.GetWeather(coordinate);

                    if (InvokeRequired)
                        Invoke(new Action(() => SetParameters()));
                    else SetParameters();
                }
                else
                {
                    label16.Text = "Status: city geodata not defined.";
                    label16.ForeColor = Color.Red;
                }
            });
        }
    }
}
