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
        public Type SelectedItemNavigationTarget { get; set; }

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
            await Task.Delay(1000);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
            Console.WriteLine(state.Location.Host + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            // Note: strings will be URL encoded for navigation (e.g. "Blue Monkey" becomes "Blue%20Monkey"). Therefore, decode at the receiver.
            // This works because route names are unique in this application.
            //Console.WriteLine(SelectedItemNavigationTarget.Name.ToLower());
            //await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/{SelectedItemNavigationTarget.Name.ToLower()}/spellcards?name={((Spell)item).Name}");
            await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/allspells/spellcards?name={((Spell)item).Name}");
        }

        string GetNavigationTarget()
        {
            return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
        }
    }
}
