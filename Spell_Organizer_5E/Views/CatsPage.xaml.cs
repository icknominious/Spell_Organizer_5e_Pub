using System.Linq;
using Xamarin.Forms;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Views
{
    public partial class CatsPage : ContentPage
    {
        public CatsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.Database.GetSpellsAsync();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spell = (e.CurrentSelection.FirstOrDefault() as Spell).Name;
            await Shell.Current.GoToAsync($"app://xamarin.com/menu/spells/allspells/spellcards?name={spell}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/cats/catdetails?name={catName}");
        }
    }
}
