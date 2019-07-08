using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spell_Organizer_5E.Models;
using Spell_Organizer_5E.ViewModels;


namespace Spell_Organizer_5E.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// Content page for spells filtered by class,
    /// same functionality as AllSpells page excent has an additional picker for character classes
    /// </summary>
    public partial class SpellsByClass : ContentPage
    {
        private IList<Spell> Spells = App.Database.GetSpellsAsync().Result;
        public SpellsByClass()
        {
            InitializeComponent();
            SpellsByClassView.ItemsSource = Spells;  
            ByClassSpellSearchHandler.Spells = Spells;
        }

        async void OnClassPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Spells = await App.Database.GetSpellsbyClassAsync(ClassPicker.SelectedItem.ToString());
            SpellsByClassView.ItemsSource = Spells;
            ByClassSpellSearchHandler.Spells = Spells;
            OnSortingPickerSelectedIndexChanged(this, EventArgs.Empty);
        }

        void OnSortingPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<Spell> sortedList = Spells;
            switch (SortingPicker.SelectedIndex)
            {
                case 0: sortedList = Spells.OrderBy(spell => spell.Name); break;             //"Name (Ascending)"
                case 1: sortedList = Spells.OrderByDescending(spell => spell.Name); break;  //"Name (Descending)"
                case 2: sortedList = Spells.OrderBy(spell => spell.Level); break;           //"Level (Ascending)"
                case 3: sortedList = Spells.OrderByDescending(spell => spell.Level); break;//"Level (Descending)"
            }
            SpellsByClassView.ItemsSource = sortedList;
        }

        //protected override async void OnAppearing()                        
        //{
        //}

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spell = (e.CurrentSelection.FirstOrDefault() as Spell).Name;
            SpellsByClassView.SelectedItem = null;
            await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/spellsbyclass/spellcards?name={spell}");
        }
    }
}
