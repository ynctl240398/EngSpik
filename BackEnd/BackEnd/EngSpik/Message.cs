using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Message
    {
        public Message()
        {
            Groups = new HashSet<Group>();
        }

        public uint Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
