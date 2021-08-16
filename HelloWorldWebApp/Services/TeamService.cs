using HelloWorldWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorldWebApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly TimeService timeService;

        public TeamService()
        {
            teamInfo = new TeamInfo
            {
                TeamName = "name",
                TeamMembers = new List<Member>()
                    { new Member(1, "Gabi", timeService), new Member(2, "Delia", timeService), new Member(3, "Rares", timeService), new Member(4, "Catalin", timeService) }
            };
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public Member AddTeamMember(Member member)
        {
            int id = teamInfo.TeamMembers.Max(member => member.Id);
            member.Id = id + 1;
            teamInfo.TeamMembers.Add(member);
            return member;
        }

        public Member UpdateTeamMember(Member member)
        {
            // List<Member> teamMembers = teamInfo.TeamMembers.Select(r => { if (r.Id == member.Id) { r = member; }; return r; }).ToList();
            // teamInfo.TeamMembers = teamMembers;
            teamInfo.TeamMembers.ForEach(r => { if (r.Id == member.Id) { r.Name = member.Name; }; });
            return member;
        }

        public void DeleteTeamMember(int id)
        {
            Member member = teamInfo.TeamMembers.Single(r => r.Id == id);
            teamInfo.TeamMembers.Remove(member);
        }
    }
}
