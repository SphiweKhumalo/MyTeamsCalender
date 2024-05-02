using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using MyTeamsCalender.EntityFrameworkCore.Seed;

namespace MyTeamsCalender.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyTeamsCalenderCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class MyTeamsCalenderEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<MyTeamsCalenderDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        MyTeamsCalenderDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        MyTeamsCalenderDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTeamsCalenderEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
