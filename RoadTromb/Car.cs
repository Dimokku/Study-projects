using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TrafficJam
{
    class Car
    {
        public double StartSpeed { get; set; }
        public double CurrentSpeed { get; set; }
        public double ExpectedSpeed { get; set; }
        public double Coordinate { get; set; }

        public bool KeepDistance { get; set; } //indicates whether the driver is keeping a distance

        static Random rnd = new Random();

        /*
         * Status - vehicle condition
         * n - normal, keeps speed
         * d - deceleration, speed decreases every second
         * u - acceleration, speed increases every second
         * s - the car is in stop state
         * */
        public char Status { get; set; }
        public int StopTime { get; set; }

        public Car()
        {
            StartSpeed = rnd.Next(Settings.MinSpeed, Settings.MaxSpeed);
            CurrentSpeed = StartSpeed;
            Coordinate = 0;
            Status = 'n';
            StopTime = 0;
            if (Settings.values[rnd.Next(0, 100)] == 1) //imitation of the chance that the driver keeps a distance
                KeepDistance = true;
            else
                KeepDistance = false;
        }

        public void Move()
        {
            switch (Status)
            {
                case 'd':
                    SpeedDown();
                    Coordinate += CurrentSpeed / 20;
                    break;
                case 'u':
                    SpeedUp();
                    Coordinate += CurrentSpeed / 20;
                    break;
                case 's':
                   StopTime -= 1;
                    if (StopTime == 0)
                    {
                        Status = 'u';
                        ExpectedSpeed = StartSpeed;
                    }
                    break;
                case 'n':
                    Coordinate += CurrentSpeed / 20;
                    break;
            }
        }

        private void SpeedDown() // deceleraton
        {
            if (CurrentSpeed - ExpectedSpeed <= 5)
            {
                CurrentSpeed = ExpectedSpeed;
                Status = 'n';
            }
            else
                CurrentSpeed -= 5;
        }

        private void SpeedUp() // acceleration
        {
            if (ExpectedSpeed - CurrentSpeed <= 5)
            {
                CurrentSpeed = ExpectedSpeed;
                Status = 'n';
            }
            else
                CurrentSpeed += 5;
        }
    }
}
