using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyTeamsCalender.Authorization.Roles;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.MultiTenancy;
using Microsoft.EntityFrameworkCore.Internal;
using MyTeamsCalender.Domain.Teams;
using MyTeamsCalender.Domain.Channels;
using MyTeamsCalender.Domain.Messages;
using MyTeamsCalender.Domain.MessageReceipts;
using MyTeamsCalender.Domain.TeamMembers;

namespace MyTeamsCalender.EntityFrameworkCore
{
    public class MyTeamsCalenderDbContext : AbpZeroDbContext<Tenant, Role, User, MyTeamsCalenderDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public MyTeamsCalenderDbContext(DbContextOptions<MyTeamsCalenderDbContext> options)
            : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageReadReceipt> MessageReadReceipts { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }
    }
}
