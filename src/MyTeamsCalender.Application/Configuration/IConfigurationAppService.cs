using System.Threading.Tasks;
using MyTeamsCalender.Configuration.Dto;

namespace MyTeamsCalender.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
