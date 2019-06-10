using System.Collections.Generic;
using SQLite;

namespace Spell_Organizer_5E.Models
{
    class SpellList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Spell> Spells { get; private set; }
    }
}
