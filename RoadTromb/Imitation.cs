using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TrafficJam
{
    class Imitation
    {
        static int t;
        static Road r;
        static DispatcherTimer timer = null;
        static bool isPlaying;
        static Canvas canvas;
        static TextBox statistic;
        public static void SetParameters(Canvas canv, TextBox stat)
        {
            canvas = canv;
            statistic = stat;
            t = 0;
            r = new Road(canvas, statistic);
            isPlaying = false;
        }

        public static void StartImitation()
        {
            if(isPlaying == false)
            {
                isPlaying = true;
                timer = new DispatcherTimer();
                timer.Tick += new EventHandler(model);
                timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
                timer.Start();
            }
        }

        public static void StopImitation()
        {
            timer?.Stop();
            isPlaying = false;
        }

        static void model(object sender, EventArgs e)
        {
            r.NextTime(ref t);
            t++;
            Statistics.GetInstance.ImitationTime++;
            if(t >= (Settings.ImitationTime * 20))
            {
                StopImitation();
                if (Settings.Unlimit == true)
                    StartImitation();
                else t = 0;
            }
        }
    }
}
