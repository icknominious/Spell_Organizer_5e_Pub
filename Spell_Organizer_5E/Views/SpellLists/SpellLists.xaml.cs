using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Views
{ 
    public partial class SpellLists : ContentPage
    {
        private IList<SpellList> spellList = App.Database.GetSpellListsAsync().Result;
        public SpellLists()
        {
            InitializeComponent();
            SpellListsView.ItemsSource = spellList;
        }
        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spellList = (e.CurrentSelection.FirstOrDefault() as SpellList).Name;
            //await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/allspells/spellcards?name={spell}");
        }
    }
}