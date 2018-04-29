

using System;

namespace LardiApp.Models
{
    public class ApplicationTimer
    {
        private static ApplicationTimer applicationTimer;
         
        private int Interval;


        private ApplicationTimer()
        {
        }

        public TimeSpan GetInterval()
        {
            return TimeSpan.FromSeconds(Interval);
        }

        public void SetInterval(int interval)
        {
            Interval = interval;
        }



        public static ApplicationTimer Instance
        {
            get
            {
                if (applicationTimer == null)
                {
                    applicationTimer = new ApplicationTimer();
                }
                return applicationTimer;
            }
        }
    }
}
