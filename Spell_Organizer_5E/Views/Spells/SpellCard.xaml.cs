using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spell_Organizer_5E.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
            //};    derlict code, might reuse
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        /// <summary>
        /// Event handler for add button,
        /// Checks if the spell is in the list and if not add it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
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

        /// <summary>
        /// Event handler for remove button,
        /// Checks if spell is in the list and if so, removes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
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
