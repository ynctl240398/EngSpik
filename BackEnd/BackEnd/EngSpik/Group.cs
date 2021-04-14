using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Group
    {
        public Group()
        {
            GroupAccounts = new HashSet<GroupAccount>();
            Notifications = new HashSet<Notification>();
        }

        public uint Id { get; set; }
        public uint MessageId { get; set; }

        public virtual Message Message { get; set; }
        public virtual ICollection<GroupAccount> GroupAccounts { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
