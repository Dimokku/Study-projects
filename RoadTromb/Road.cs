using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TrafficJam
{
    class Road
    {
        public Queue<Car> Cars { get; set; }
        public Queue<Rectangle> RCars { get; set; }
        double TimeToCar; //time to next car
        Random rnd;
        Canvas canv;
        TextBox stat;

        public Road(Canvas canvas, TextBox statistic)
        {
            Cars = new Queue<Car>();
            RCars = new Queue<Rectangle>();
            TimeToCar = 0;
            rnd = new Random();
            canv = canvas;
            stat = statistic;
        }

        void AddCar()
        {
            Cars.Enqueue(new Car());
        }

        void RemoveCar()
        {
            Cars.Dequeue();
        }

        public void NextTime(ref int t) //next road condition
        {
            Car PrevCar = null;
            if (TimeToCar <= 0)
            {
                AddCar();
                Statistics.GetInstance.CarCount++;
                TimeToCar = Settings.Interval * 20;
            }
            else TimeToCar--;


            foreach (var x in Cars)
            {
                double min = Double.MaxValue;
                double max = 0;
                x.Move();
                foreach (var car in Cars)
                {
                    if (car.CurrentSpeed > max)
                        max = car.CurrentSpeed;
                    if (min > car.CurrentSpeed && car.CurrentSpeed != 0)
                        min = car.CurrentSpeed;
                }
                if (Statistics.GetInstance.MinSpeed > min)
                    Statistics.GetInstance.MinSpeed = (int)min;
                if (Statistics.GetInstance.ImitationTime % 20 == 0)
                    Statistics.GetInstance.MaxDiff = (int)(max / min);
                stat.Text = "Time imitation: " + (Statistics.GetInstance.ImitationTime / 20 + 1) + " s\n"
                + "Maximum fixed speed: " + Statistics.GetInstance.MaxSpeed + " km/h\n"
                + "Minimum fixed speed: " + Statistics.GetInstance.MinSpeed + " km/h\n"
                + "Car count: " + Statistics.GetInstance.CarCount;
                if (Convert.ToInt32(x.CurrentSpeed) > Statistics.GetInstance.MaxSpeed)
                    Statistics.GetInstance.MaxSpeed = Convert.ToInt32(x.CurrentSpeed);
                stat.Text += $"\nUniform flow {Statistics.GetInstance.MaxDiff} times faster than pulsating";

                if (PrevCar != null)
                {
                    if (x.Status != 's') //if doesn't standing
                    {
                        if (x.CurrentSpeed > 30) //speed limit for free road
                        {
                            x.Status = 'd';
                            x.ExpectedSpeed = 30;
                        }
                        else
                        {
                            if (x.KeepDistance) //if this car keeps a distance (it just keep more distance to the next car)
                            {
                                if (Math.Abs(PrevCar.Coordinate - 3 - x.Coordinate) <= 10)
                                {
                                    x.Status = 's';
                                    x.StopTime = 6;
                                    x.CurrentSpeed = 0;
                                }
                                else
                                if (Math.Abs(PrevCar.Coordinate - 3 - x.Coordinate) <= 25)
                                {
                                    x.Status = 'd';
                                    x.ExpectedSpeed = PrevCar.CurrentSpeed;
                                }
                                else
                                if ((Math.Abs(PrevCar.Coordinate - 3 - x.Coordinate) > 25) && (x.Status != 'u') && (x.CurrentSpeed < x.StartSpeed + 5))
                                {
                                    x.Status = 'u';
                                    x.ExpectedSpeed = x.CurrentSpeed + 3;
                                }

                                if (x.Status == 'd' && Math.Abs(PrevCar.Coordinate - 3 - x.Coordinate) > 20)
                                {
                                    x.Status = 'u';
                                    x.ExpectedSpeed = x.StartSpeed;
                                }
                            }

                            else //this car is trying to drive close 
                            {
                                if (Math.Abs(PrevCar.Coordinate - 3 - x.Coordinate) <= 5)
                                {
                                    x.Status = 's';
                                    x.StopTime = 6;
                                    x.CurrentSpeed = 0;
                                }
                                else if (Math.Abs(PrevCar.Coordinate - 3 - x.Coordinate) < 6)
                                {
                                    x.Status = 'd';
                                    x.ExpectedSpeed = PrevCar.CurrentSpeed + 1;
                                }
                                else if (Math.Abs(PrevCar.Coordinate - 3 - x.Coordinate) <= 10)
                                {
                                    x.Status = 'd';
                                    x.ExpectedSpeed = PrevCar.CurrentSpeed + 5;
                                }
                                else
                                if ((Math.Abs(PrevCar.Coordinate - 3 - x.Coordinate) > 10) && (x.Status != 'u'))
                                {
                                    x.Status = 'u';
                                    x.ExpectedSpeed = x.CurrentSpeed + 5;
                                }

                                if (x.Status == 'd' && Math.Abs(PrevCar.Coordinate - 3 - x.Coordinate) > 10)
                                {
                                    x.Status = 'u';
                                    x.ExpectedSpeed = x.StartSpeed;
                                }
                            }
                        }
                    }
                }

                PrevCar = x;
            }

            if (Cars.Count != 0 && Cars.Peek().Coordinate >= 185) //if road ended
            {
                RemoveCar();
            }

            Refresh();
        }

        private void Refresh() // refresh the road (visually)
        {
            foreach (var x in RCars)
            {
                canv.Children.Remove(x);
            }
            foreach (var x in Cars)
            {
                Rectangle r;
                SolidColorBrush scb = null;
                switch (x.Status)
                {
                    case 's':
                        scb = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        break;
                    case 'd':
                        scb = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                        break;
                    case 'u':
                        scb = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                        break;
                    case 'n':
                        scb = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        break;
                }
                if (x.KeepDistance == true)
                    scb.Color = Color.FromRgb(0, 0, 255);
                r = new Rectangle()
                {
                    Fill = scb,
                    Width = 6,
                    Height = 12
                };
                Canvas.SetTop(r, canv.Height - (x.Coordinate) * 3);
                Canvas.SetLeft(r, 15);
                RCars.Enqueue(r);
                canv.Children.Add(r);
            }
        }
    }
}
