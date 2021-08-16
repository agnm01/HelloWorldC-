using System;

namespace HelloWorldWebApp.Services
{
    public class TimeService : ITimeService
    {
        public DateTime Now()
        {
           return DateTime.Now;
        }
    }
}
