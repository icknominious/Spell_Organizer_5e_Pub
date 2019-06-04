using System;
using SQLite;

namespace Spell_Organizer_5E.Models
{
    public class Spell
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Time { get; set; }
        public int Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        public string School { get; set; }
        public string Race { get; set; }
        public string SpellType { get; set; }
        public string OnHigherLevelCast { get; set; }

    }
}
