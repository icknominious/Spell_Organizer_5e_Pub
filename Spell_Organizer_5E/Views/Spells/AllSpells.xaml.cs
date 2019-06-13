using System.Linq;
using Xamarin.Forms;
using Spell_Organizer_5E.Models;
using System.Collections.Generic;

namespace Spell_Organizer_5E.Views
{
    public partial class AllSpells : ContentPage
    {
        private IList<Spell> Spells = App.Database.GetSpellsAsync().Result;
        public AllSpells()
        {
            InitializeComponent();
            AllSpellsView.ItemsSource = Spells; //workaround 
            AllSpellSearchHandler.Spells = Spells;
        }

        //protected override async void OnAppearing()                       //doesnt work, xamarin bug
        //{
        //    base.OnAppearing();

        //    //AllSpellsView.ItemsSource = await App.Database.GetSpellsAsync();
        //}

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spell = (e.CurrentSelection.FirstOrDefault() as Spell).Name;
            await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/allspells/spellcards?name={spell}");
        }
    }
}
