using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyTeamsCalender.Authorization;

namespace MyTeamsCalender
{
    [DependsOn(
        typeof(MyTeamsCalenderCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyTeamsCalenderApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyTeamsCalenderAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyTeamsCalenderApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
