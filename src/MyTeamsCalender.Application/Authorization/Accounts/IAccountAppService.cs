using System.Threading.Tasks;
using Abp.Application.Services;
using MyTeamsCalender.Authorization.Accounts.Dto;

namespace MyTeamsCalender.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
