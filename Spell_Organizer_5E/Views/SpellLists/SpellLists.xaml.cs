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
        private SpellList defaultSpellList;
        private readonly IList<SpellList> spellListOfLists;
        public SpellLists()
        {
            InitializeComponent();
            App.activeSpellList = LoadDefaultSpellList();
            spellListOfLists = App.Database.GetSpellListsAsync().Result;
            SpellListsView.ItemsSource = spellListOfLists;
        }
        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string spellList = (e.CurrentSelection.FirstOrDefault() as SpellList).Name;
            //await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/allspells/spellcards?name={spell}");
        }
        SpellList LoadDefaultSpellList()
        {
            if (defaultSpellList == null)
            {
                defaultSpellList = new SpellList{ Name = "Default Spell List" };
                _ = App.Database.SaveSpellListAsync(defaultSpellList);
            }
            return defaultSpellList;
        }
    }
}