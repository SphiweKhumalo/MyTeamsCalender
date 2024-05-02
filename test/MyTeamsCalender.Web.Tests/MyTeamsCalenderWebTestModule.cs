using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyTeamsCalender.EntityFrameworkCore;
using MyTeamsCalender.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyTeamsCalender.Web.Tests
{
    [DependsOn(
        typeof(MyTeamsCalenderWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyTeamsCalenderWebTestModule : AbpModule
    {
        public MyTeamsCalenderWebTestModule(MyTeamsCalenderEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTeamsCalenderWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyTeamsCalenderWebMvcModule).Assembly);
        }
    }
}