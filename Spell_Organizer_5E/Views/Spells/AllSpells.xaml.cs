using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spell_Organizer_5E.Models;


namespace Spell_Organizer_5E.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllSpells : ContentPage
    {
        private readonly IList<Spell> Spells = App.Database.GetSpellsAsync().Result;

        /// <summary>
        /// Constructor, sets page collection view and search handler to target spells from the DB
        /// </summary>
        public AllSpells()
        {
            InitializeComponent();
            AllSpellsView.ItemsSource = Spells; 
            AllSpellSearchHandler.Spells = Spells;
        }

        protected override void OnAppearing()                       
        {
            base.OnAppearing();
        }

        /// <summary>
        /// Event handler for spell selected in the collection view,
        /// navigates to selected spell card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllSpellsView.SelectedItem != null)
            {
                string spell = (e.CurrentSelection.FirstOrDefault() as Spell).Name;
                await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/allspells/spellcards?name={spell}");
                AllSpellsView.SelectedItem = null;
            }
        }

        /// <summary>
        /// Event handler for the sorting picker,
        /// orders the collection view according to selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            AllSpellsView.ItemsSource = sortedList;
        }
    }
}
