using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class WordList
    {
        public WordList()
        {
            Likes = new HashSet<Like>();
            Notifications = new HashSet<Notification>();
        }

        public uint Id { get; set; }
        public uint WordId { get; set; }
        public uint TopicId { get; set; }
        public uint AccountId { get; set; }
        public string Name { get; set; }
        public sbyte Privacy { get; set; }

        public virtual Account Account { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Word Word { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
