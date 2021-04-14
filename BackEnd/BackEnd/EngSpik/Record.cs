using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Record
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public uint AccountSendId { get; set; }
        public uint AccountReceiveId { get; set; }

        public virtual Account AccountReceive { get; set; }
        public virtual Account AccountSend { get; set; }
    }
}
