using System;
using System.Collections.Generic;
using SQLite;

namespace Spell_Organizer_5E.Models
{
    /// <summary>
    /// DB insertable objects that holds SpellList functional and application data 
    /// </summary>
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
