using System;
using Xamarin.Forms;

namespace Spell_Organizer_5E.Views
{
    [QueryProperty("Name", "name")]
    public partial class SpellCard : ContentPage
    {
        public string Name
        {
            set => BindingContext = App.Database.GetSpellAsync(Uri.UnescapeDataString(value)).Result;
        }

        public SpellCard()
        {
            InitializeComponent();

            //ScrollView.Scrolled += (object sender, ScrolledEventArgs e) => {
            //    AddButton.TranslationY = e.ScrollY;
            //};
            //ScrollView.Scrolled += (object sender, ScrolledEventArgs e) => {
            //    RemoveButton.TranslationY = e.ScrollY;
            //};
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        async void OnAddButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (App.activeSpellList.Spells.Contains(button.CommandParameter.ToString()))
            {
                Console.WriteLine("Spell already in list!");
            }
            else
            {
                App.activeSpellList.Spells += button.CommandParameter.ToString() + ", ";
                await App.Database.SaveSpellListAsync(App.activeSpellList);
                Console.WriteLine("Spell added to list!");
                Console.WriteLine(App.activeSpellList.Spells);
            }
        }
        async void OnRemoveButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (App.activeSpellList.Spells.Contains(button.CommandParameter.ToString()))
            {
                App.activeSpellList.Spells = App.activeSpellList.Spells.Replace(button.CommandParameter.ToString() + ", ", "");
                await App.Database.SaveSpellListAsync(App.activeSpellList);
                Console.WriteLine(App.activeSpellList.Spells);
                Console.WriteLine("Spell removed from list!");
            }
            else
            {
                Console.WriteLine("Spell not in list!");
            }
        }
    }
}
