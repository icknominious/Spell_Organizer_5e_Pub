using Spell_Organizer_5E.Models;
using System.Collections.Generic;

namespace Spell_Organizer_5E.ViewModels
{
    /// <summary>
    /// Not in use
    /// </summary>
    public class SpellsViewModel
    {
        static public IList<Spell> SpellListMV = App.Database.GetSpellsAsync().Result; 
        SpellsViewModel()
        {
            //foreach (Spell spell in SpellListMV)
            //{
            //    if (App.activeSpellList.Spells.Contains(spell.Name))
            //    {
            //    }
            //}
        }
    }
}
