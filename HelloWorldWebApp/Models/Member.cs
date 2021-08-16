using HelloWorldWebApp.Services;
using System;

namespace HelloWorldWebApp.Models
{
    public class Member
    {
        private readonly ITimeService timeService;

        public Member(string name, ITimeService timeService)
        {
            this.Id = 0;
            this.Name = name;
            this.timeService = timeService;
        }

        public Member(int id, string name, ITimeService timeService)
        {
            this.Id = id;
            this.Name = name;
            this.timeService = timeService;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public int GetAge()
        {
            int age = timeService.Now().Subtract(Birthdate).Days;
            age /= 365;
            return age;
        }
    }
}
