using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficJam
{
    class Settings
    {
        public static int MinSpeed { get; set; }
        public static int MaxSpeed { get; set; }
        public static double Interval { get; private set; } 
        public static int ImitationTime { get; private set; } //imitation time
        public static bool Unlimit { get; set; } //time limit
        public static double KeepDistanceChance { get; set; } //with this probability cars that keep a distance appear 

        public static int[] values = new int[100]; //probability array
        public static void UpdateSettings(int minspeed, int maxspeed, double interval,
            int imitationtime, bool unlimit, double keepdistancechance)
        {
            MinSpeed = minspeed;
            MaxSpeed = maxspeed;
            Interval = interval;
            ImitationTime = imitationtime;
            Unlimit = unlimit;
            KeepDistanceChance = keepdistancechance;

            if (MinSpeed < 5)
                MinSpeed = 5;
            if (MinSpeed > 15)
                MinSpeed = 15;
            if (MaxSpeed > 15)
                MaxSpeed = 15;
            if (MaxSpeed < MinSpeed)
                MaxSpeed = MinSpeed;
            if (KeepDistanceChance > 1)
                KeepDistanceChance = 1;
            if (KeepDistanceChance < 0)
                KeepDistanceChance = 0;
            if (Interval < 0.5)
                Interval = 0.5;

            for (int i = 0; i < values.Length; i++)
                values[i] = 0;
            for(int i = 0; i < keepdistancechance*100; i++)
            {
                values[i] = 1;
            }
        }
    }
}
