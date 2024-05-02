using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyTeamsCalender.Controllers
{
    public abstract class MyTeamsCalenderControllerBase: AbpController
    {
        protected MyTeamsCalenderControllerBase()
        {
            LocalizationSourceName = MyTeamsCalenderConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
