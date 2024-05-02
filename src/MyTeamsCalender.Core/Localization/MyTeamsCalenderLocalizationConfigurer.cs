using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MyTeamsCalender.Localization
{
    public static class MyTeamsCalenderLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MyTeamsCalenderConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MyTeamsCalenderLocalizationConfigurer).GetAssembly(),
                        "MyTeamsCalender.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
