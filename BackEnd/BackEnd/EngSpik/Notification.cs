using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public sbyte Readed { get; set; }
        public string Content { get; set; }
        public DateTime CreatAt { get; set; }
        public uint? RoomId { get; set; }
        public uint? AccountId { get; set; }
        public uint? GroupId { get; set; }
        public uint? QuizId { get; set; }
        public uint? WordListId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Group Group { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual Room Room { get; set; }
        public virtual WordList WordList { get; set; }
    }
}
