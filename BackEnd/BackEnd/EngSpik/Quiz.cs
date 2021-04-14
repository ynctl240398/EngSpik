using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Quiz
    {
        public Quiz()
        {
            Notifications = new HashSet<Notification>();
        }

        public uint Id { get; set; }
        public uint TopicId { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
