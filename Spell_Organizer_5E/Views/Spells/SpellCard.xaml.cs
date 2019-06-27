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

            ScrollView.Scrolled += (object sender, ScrolledEventArgs e) => {
                AddButton.TranslationY = e.ScrollY;
            };
            ScrollView.Scrolled += (object sender, ScrolledEventArgs e) => {
                RemoveButton.TranslationY = e.ScrollY;
            };
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}
