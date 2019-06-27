using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Spell_Organizer_5E.Data;
using Spell_Organizer_5E.Models;
using System.Collections.Generic;

namespace Spell_Organizer_5E.ViewModels
{
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
