using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

namespace TrafficJam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool pause = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartBut_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            if (!pause)
            {
                pause = true;
                bool unlimit;            
                unlimit = Convert.ToBoolean(checkImitTime.IsChecked);

                try
                {
                    Settings.UpdateSettings(Convert.ToInt32(minSpeed.Text), Convert.ToInt32(maxSpeed.Text),
                        Convert.ToDouble(Interval.Text),Convert.ToInt32(imitTime.Text), unlimit, 
                        Convert.ToDouble(KeepDistance_TextBox.Text));
                    minSpeed.Text = Convert.ToString(Settings.MinSpeed);
                    maxSpeed.Text = Convert.ToString(Settings.MaxSpeed);
                    Interval.Text = Convert.ToString(Settings.Interval);
                    Imitation.SetParameters(RoadCanvas, StatTextBox);
                    Imitation.StartImitation();
                }

                catch (Exception)
                {
                    MessageBox.Show("Invalid input parameters");
                    StartButton.IsEnabled = true;
                    Imitation.StopImitation();
                    Statistics.GetInstance.Clear();
                    RoadCanvas.Children.Clear();
                    pause = false;
                    StartButton.IsEnabled = true;
                    StatTextBox.Text = "";
                }
            }
            else Imitation.StartImitation();
        }

        private void StopBut_Click(object sender, RoutedEventArgs e)
        {
            Imitation.StopImitation();
            StartButton.IsEnabled = true;
        }

        private void RefreshBut_Click(object sender, RoutedEventArgs e)
        {
            Imitation.StopImitation();
            Statistics.GetInstance.Clear();
            RoadCanvas.Children.Clear();
            pause = false;
            StartButton.IsEnabled = true;
            StatTextBox.Text = "";        
        }

        private void HelpBut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "\tSpeed: from 5 to 15 km/h\n" +
                "\tInterval of appearance of cars from 0,5\n"+
                "\tUse \',\' to separate the fractional part of a number.\n" +
                "\tProportion of drivers observing the distance is between 0 and 1" +
                " where 0 is there are no drivers observing the distance and 1 is there are only these drivers");
        }

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("statistics.txt");
            streamWriter.Write(StatTextBox.Text);
            streamWriter.Close();

            XmlSerializer formatter = new XmlSerializer(typeof(Statistics));
            using(FileStream fs = new FileStream("statistics.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Statistics.GetInstance);
            }

            MessageBox.Show("Information have saved to \"statistics.txt\" and \"statistics.xml\". Check the root catalog.");
        }
    }
}
