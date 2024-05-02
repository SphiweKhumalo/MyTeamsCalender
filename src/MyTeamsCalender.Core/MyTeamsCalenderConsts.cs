using MyTeamsCalender.Debugging;

namespace MyTeamsCalender
{
    public class MyTeamsCalenderConsts
    {
        public const string LocalizationSourceName = "MyTeamsCalender";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ca81aeedcee449af93d3331445e8fd69";
    }
}
