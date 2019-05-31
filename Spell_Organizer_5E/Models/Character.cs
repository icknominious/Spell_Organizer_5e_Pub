using System;
using SQLite;

namespace Spell_Organizer_5E.Models
{
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string SubClass { get; set; }
        public string Level { get; set; }
        public string SpellsKnown { get; set; }
    }
}
