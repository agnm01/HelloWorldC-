using HelloWorldWebApp.Models;
using HelloWorldWebApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        private Mock<ITimeService> timeMock;

        

        private void InitializeTimeServiceMock()
        {
            timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.Now()).Returns(new DateTime(2021, 08, 11));
            
        }

        [Fact]
        public void GettingAge()
        {
            // Assume
            InitializeTimeServiceMock();
            var timeService = timeMock.Object;
            var newTeamMember = new Member("Delia", timeService);
            newTeamMember.Birthdate = new DateTime(1990, 09, 30);
            
            // Act

            int age = newTeamMember.GetAge();

            // Assert

            timeMock.Verify(_ => _.Now(), Times.AtMostOnce());
            Assert.Equal(30,age);

        }
    }

    
}
