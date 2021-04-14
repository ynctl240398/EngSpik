using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public uint SpeakerId { get; set; }
        public uint AccountId { get; set; }
        public uint TopicId { get; set; }
        public string Content { get; set; }
        public DateTime BeginAt { get; set; }

        public virtual Account Account { get; set; }
        public virtual Account Speaker { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
