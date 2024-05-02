using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyTeamsCalender.Configuration.Dto;

namespace MyTeamsCalender.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyTeamsCalenderAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
