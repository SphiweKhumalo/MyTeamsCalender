using Abp.Application.Services;
using MyTeamsCalender.MultiTenancy.Dto;

namespace MyTeamsCalender.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

