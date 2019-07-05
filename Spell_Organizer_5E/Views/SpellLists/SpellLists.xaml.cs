using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Views
{  
    public partial class SpellLists : ContentPage
    {
        public SpellLists()
        {
            InitializeComponent();
            //Shell.SetBackButtonBehavior(this, new BackButtonBehavior { Command = new Command(() => _ = Shell.Current.GoToAsync("homepage")) });   xamarin bug, won't work
            SpellListsView.ItemsSource = App.Database.GetSpellListsAsync().Result;
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spellList = (e.CurrentSelection.FirstOrDefault() as SpellList).Name;
            await Shell.Current.GoToAsync("spelllistcards");
        }
        private void ActivateButton_Clicked(object sender, EventArgs e)
        {

        }
        //protected override bool OnBackButtonPressed()
        //{
        //    return Shell.Current.GoToAsync("homepage").IsCompleted;
        //}

    }
}