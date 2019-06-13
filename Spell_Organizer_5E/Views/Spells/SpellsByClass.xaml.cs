using System.Linq;
using System;
using Xamarin.Forms;
using Spell_Organizer_5E.Models;
using System.Collections.Generic;

namespace Spell_Organizer_5E.Views
{
    public partial class SpellsByClass : ContentPage
    {
        private IList<Spell> Spells = App.Database.GetSpellsAsync().Result;
        public SpellsByClass()
        {
            InitializeComponent();
            SpellsByClassView.ItemsSource = Spells;   //workaround
            ByClassSpellSearchHandler.Spells = Spells;
        }

        async void OnClassPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Spells = await App.Database.GetSpellsbyClassAsync(ClassPicker.SelectedItem.ToString());
            SpellsByClassView.ItemsSource = Spells;
            ByClassSpellSearchHandler.Spells = Spells;
            SortingPicker.SelectedIndex = 0;
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

        //protected override async void OnAppearing()                               //doesnt work, Xamarin bug
        //{
        //    base.OnAppearing();

        //    //SpellsByClassView.ItemsSource = await App.Database.GetSpellsAsync();
        //}

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spell = (e.CurrentSelection.FirstOrDefault() as Spell).Name;
            await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/spellsbyclass/spellcards?name={spell}");
        }
    }
}
