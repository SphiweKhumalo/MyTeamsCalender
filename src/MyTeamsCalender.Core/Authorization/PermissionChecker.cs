using Abp.Authorization;
using MyTeamsCalender.Authorization.Roles;
using MyTeamsCalender.Authorization.Users;

namespace MyTeamsCalender.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
