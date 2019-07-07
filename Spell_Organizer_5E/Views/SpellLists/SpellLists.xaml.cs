using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Views
{  
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// View page that shows all available spell lists, currently only default enabled
    /// </summary>
    public partial class SpellLists : ContentPage
    {
        /// <summary>
        /// Constructor, links page display contents to list of spell lists from DB 
        /// </summary>
        public SpellLists()
        {
            InitializeComponent();
            //Shell.SetBackButtonBehavior(this, new BackButtonBehavior { Command = new Command(() => _ = Shell.Current.GoToAsync("homepage")) });   xamarin bug, won't work
            SpellListsView.ItemsSource = App.Database.GetSpellListsAsync().Result;
        }
        /// <summary>
        /// Event handler for item selected within the collection view,
        /// Navigates to individual spell card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spellList = (e.CurrentSelection.FirstOrDefault() as SpellList).Name;
            await Shell.Current.GoToAsync("spelllistcards");
        }
        private void ActivateButton_Clicked(object sender, EventArgs e)
        {
            //TODO
        }

    }
}