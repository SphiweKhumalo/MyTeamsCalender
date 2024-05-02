using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyTeamsCalender.Configuration;

namespace MyTeamsCalender.Web.Host.Startup
{
    [DependsOn(
       typeof(MyTeamsCalenderWebCoreModule))]
    public class MyTeamsCalenderWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyTeamsCalenderWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTeamsCalenderWebHostModule).GetAssembly());
        }
    }
}
