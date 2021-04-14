using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class GroupAccount
    {
        public int Id { get; set; }
        public uint GroupId { get; set; }
        public uint AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Group Group { get; set; }
    }
}
