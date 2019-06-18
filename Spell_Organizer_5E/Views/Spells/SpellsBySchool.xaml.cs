using System.Linq;
using System;
using Xamarin.Forms;
using Spell_Organizer_5E.Models;
using System.Collections.Generic;

namespace Spell_Organizer_5E.Views
{
    public partial class SpellsBySchool : ContentPage
    {
        private IList<Spell> Spells = App.Database.GetSpellsAsync().Result;
        public SpellsBySchool()
        {
            InitializeComponent();
            SpellsBySchoolView.ItemsSource = Spells;  //workaround
            BySchoolSpellSearchHandler.Spells = Spells;
        }

        async void OnSchoolPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Spells = await App.Database.GetSpellsbySchoolAsync(SchoolPicker.SelectedItem.ToString());
            SpellsBySchoolView.ItemsSource = Spells;
            BySchoolSpellSearchHandler.Spells = Spells;
            OnSortingPickerSelectedIndexChanged(this, EventArgs.Empty);
        }

        void OnSortingPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<Spell> sortedList = Spells;
            switch (SortingPicker.SelectedIndex)
            {
                case 0: sortedList = Spells.OrderBy(spell => spell.Name); break;            //"Name (Ascending)"
                case 1: sortedList = Spells.OrderByDescending(spell => spell.Name); break;  //"Name (Descending)"
                case 2: sortedList = Spells.OrderBy(spell => spell.Level); break;           //"Level (Ascending)"
                case 3: sortedList = Spells.OrderByDescending(spell => spell.Level); break; //"Level (Descending)"
            }
            SpellsBySchoolView.ItemsSource = sortedList;
        }

        //protected override async void OnAppearing()                               //doesnt work, Xamarin bug
        //{
        //    base.OnAppearing();

        //    //SpellsBySchoolView.ItemsSource = await App.Database.GetSpellsAsync();
        //}

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spell = (e.CurrentSelection.FirstOrDefault() as Spell).Name;
            await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/spellsbyschool/spellcards?name={spell}");
        }
    }
}
