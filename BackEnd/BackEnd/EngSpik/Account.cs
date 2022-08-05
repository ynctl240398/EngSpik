using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Account
    {
        public Account()
        {
            AppointmentAccounts = new HashSet<Appointment>();
            AppointmentSpeakers = new HashSet<Appointment>();
            GroupAccounts = new HashSet<GroupAccount>();
            Likes = new HashSet<Like>();
            Notifications = new HashSet<Notification>();
            RecordAccountReceives = new HashSet<Record>();
            RecordAccountSends = new HashSet<Record>();
            RegisterRooms = new HashSet<RegisterRoom>();
            Rooms = new HashSet<Room>();
            WordLists = new HashSet<WordList>();
        }

        public uint Id { get; set; }
        public string FullName { get; set; }
        public int Role { get; set; }
        public string Avatar { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public sbyte Privated { get; set; }
        public string Occupation { get; set; }
        public string Country { get; set; }
        public DateTime CreateAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Appointment> AppointmentAccounts { get; set; }
        public virtual ICollection<Appointment> AppointmentSpeakers { get; set; }
        public virtual ICollection<GroupAccount> GroupAccounts { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Record> RecordAccountReceives { get; set; }
        public virtual ICollection<Record> RecordAccountSends { get; set; }
        public virtual ICollection<RegisterRoom> RegisterRooms { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<WordList> WordLists { get; set; }
    }
}
