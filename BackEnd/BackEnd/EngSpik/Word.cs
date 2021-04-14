using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.EngSpik
{
    public partial class Word
    {
        public Word()
        {
            Dictionaries = new HashSet<Dictionary>();
            WordLists = new HashSet<WordList>();
        }

        public uint Id { get; set; }
        public string Content { get; set; }
        public string Meaning { get; set; }
        public string Voice { get; set; }
        public string Prononciation { get; set; }

        public virtual ICollection<Dictionary> Dictionaries { get; set; }
        public virtual ICollection<WordList> WordLists { get; set; }
    }
}
