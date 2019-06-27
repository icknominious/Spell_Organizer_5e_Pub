using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using Spell_Organizer_5E.Models;
using Spell_Organizer_5E.ViewModels;

namespace Spell_Organizer_5E.Views
{
    public partial class AllSpells : ContentPage
    {
        private IList<Spell> Spells = App.Database.GetSpellsAsync().Result;

        public AllSpells()
        {
            InitializeComponent();
            //BindingContext = new SpellsViewModel(); beta code
            AllSpellsView.ItemsSource = Spells; 
            AllSpellSearchHandler.Spells = Spells;
        }

        protected override void OnAppearing()                       
        {
            base.OnAppearing();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spell = (e.CurrentSelection.FirstOrDefault() as Spell).Name;
            await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/allspells/spellcards?name={spell}");
        }
    }
}
