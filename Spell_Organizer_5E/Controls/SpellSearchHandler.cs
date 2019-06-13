using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Controls
{
    public class SpellSearchHandler : SearchHandler
    {
        public IList<Spell> Spells { get; set; }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Spells.Where(spell => spell.Name.ToLower().Contains(newValue.ToLower())).ToList<Spell>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await Task.Delay(500);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
            await Shell.Current.GoToAsync($"{state.Location.OriginalString}/spellcards?name={((Spell)item).Name}");
        }

        protected override void OnFocused()
        {
            base.OnFocused();
        }
    }
}
