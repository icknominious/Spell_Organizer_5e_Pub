using System;
using System.Collections.Generic;
using SQLite;

namespace Spell_Organizer_5E.Models
{
    public class SpellList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public static IList<Spell> Spells { get; set; }

        public SpellList()
        {
            Name = "";
            Date = DateTime.UtcNow;
            Spells.Clear();

        }
    }
}
