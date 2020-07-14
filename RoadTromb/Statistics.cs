using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficJam
{
    [Serializable]
    public class Statistics
    {
        public int ImitationTime { get; set; }
        public int CarCount { get; set; }
        public int MaxSpeed { get; set; } //maximum fixed car speed
        public int MinSpeed = Int32.MaxValue; //minimum fixed car speed
        public int MaxDiff { get; set; } //how many times the uniform flow is faster than the pulsating
        public void Clear()
        {
            ImitationTime = 0;
            MaxSpeed = 0;
            CarCount = 0;
            MaxDiff = 0;
        }

        private static Statistics _instance = null;

        protected Statistics()
        {
            ImitationTime = 0;
            MaxSpeed = 0;
            CarCount = 0;
            MaxDiff = 0;
        }

        public static Statistics GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Statistics();

                return _instance;
            }
        }
    }
}
