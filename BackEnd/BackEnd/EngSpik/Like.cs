using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Like
    {
        public int Id { get; set; }
        public uint AccountId { get; set; }
        public uint WordListId { get; set; }

        public virtual Account Account { get; set; }
        public virtual WordList WordList { get; set; }
    }
}
