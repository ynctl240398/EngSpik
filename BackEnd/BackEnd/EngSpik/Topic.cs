using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Topic
    {
        public Topic()
        {
            Appointments = new HashSet<Appointment>();
            Quizzes = new HashSet<Quiz>();
            Rooms = new HashSet<Room>();
            WordLists = new HashSet<WordList>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<WordList> WordLists { get; set; }
    }
}
