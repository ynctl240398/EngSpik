using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Room
    {
        public Room()
        {
            Notifications = new HashSet<Notification>();
            RegisterRooms = new HashSet<RegisterRoom>();
        }

        public uint Id { get; set; }
        public uint TopicId { get; set; }
        public uint SpeakerId { get; set; }
        public int Max { get; set; }
        public int Count { get; set; }
        public DateTime BeginAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Account Speaker { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<RegisterRoom> RegisterRooms { get; set; }
    }
}
