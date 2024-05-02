using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyTeamsCalender.Configuration;
using MyTeamsCalender.EntityFrameworkCore;
using MyTeamsCalender.Migrator.DependencyInjection;

namespace MyTeamsCalender.Migrator
{
    [DependsOn(typeof(MyTeamsCalenderEntityFrameworkModule))]
    public class MyTeamsCalenderMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyTeamsCalenderMigratorModule(MyTeamsCalenderEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MyTeamsCalenderMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MyTeamsCalenderConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTeamsCalenderMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
