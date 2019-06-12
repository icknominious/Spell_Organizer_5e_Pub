using System;
using Xamarin.Forms;

namespace Spell_Organizer_5E.Views
{
    [QueryProperty("Name", "name")]
    public partial class SpellCard : ContentPage
    {
        public string Name
        {
            set => BindingContext = App.Database.GetSpellAsync(Uri.UnescapeDataString(value)).Result; //CatData.Cats.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
        }
        public SpellCard()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}
