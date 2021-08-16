using HelloWorldWebApp.Models;

namespace HelloWorldWebApp.Services
{
    public interface ITeamService
    {
        TeamInfo GetTeamInfo();

        Member AddTeamMember(Member member);

        Member UpdateTeamMember(Member member);

        void DeleteTeamMember(int id);
    }

}