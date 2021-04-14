using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class RegisterRoom
    {
        public int Id { get; set; }
        public uint RoomId { get; set; }
        public uint AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Room Room { get; set; }
    }
}
