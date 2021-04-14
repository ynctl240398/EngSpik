using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Dictionary
    {
        public int Id { get; set; }
        public uint WordId { get; set; }

        public virtual Word Word { get; set; }
    }
}
