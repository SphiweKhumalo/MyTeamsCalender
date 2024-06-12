using Abp.Dependency;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using MyTeamsCalender.Authorization.Users;
using MyTeamsCalender.Domain.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamsCalender.Domain.Messages
{
    public class Message : AuditedEntity<Guid>
    {
        public string MessageContent { get; set; }
        public User Sender { get; set; }
        public Channel? Channel { get; set; }
        public User? Reciever { get; set; }
        //public virtual string CreatedByPerson
        //{
        //    get
        //    {
        //        var personRepo = IocManager.Instance.Resolve<IRepository<User, long>>();
        //        var person = personRepo.FirstOrDefault(a => a.Id == CreatorUserId);

        //        return person.FullName;
        //    }
        //}
    }
}
