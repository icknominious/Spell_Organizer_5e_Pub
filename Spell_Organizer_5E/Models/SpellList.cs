using System;
using System.Collections.Generic;
using SQLite;

namespace Spell_Organizer_5E.Models
{
    public class SpellList
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Spells { get; set; }
        public SpellList()
        {
            Spells = "";
        }
    }
}
