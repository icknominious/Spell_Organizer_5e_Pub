using System.Collections.Generic;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Data
{
    public static class SpellData
    {
        public static IList<Spell> Spells { get; private set; }

        static SpellData()
        {
            GetSpellList();
        }

        private static async void GetSpellList()
        {
            Spells = await App.Database.GetSpellsAsync();
        }
    }
}
