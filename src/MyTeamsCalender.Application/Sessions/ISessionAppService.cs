using System.Threading.Tasks;
using Abp.Application.Services;
using MyTeamsCalender.Sessions.Dto;

namespace MyTeamsCalender.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
