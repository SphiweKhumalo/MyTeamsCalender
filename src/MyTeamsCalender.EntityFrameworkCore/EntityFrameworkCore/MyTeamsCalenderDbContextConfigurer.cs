using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyTeamsCalender.EntityFrameworkCore
{
    public static class MyTeamsCalenderDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyTeamsCalenderDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyTeamsCalenderDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
