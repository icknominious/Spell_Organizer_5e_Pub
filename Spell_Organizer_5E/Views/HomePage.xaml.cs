using Spell_Organizer_5E.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spell_Organizer_5E.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        static bool firstAppearance = true;
        XMLReader myReader = new XMLReader();
        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            if (firstAppearance)
            {
                await myReader.ReadFileAsync();
                firstAppearance = false;//does not work
            }
                
        }
    }
}