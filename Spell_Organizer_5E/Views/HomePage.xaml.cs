using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Spell_Organizer_5E.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async private void NC_Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("app://xamarin.com/menu/characters/newcharacter");
        }

        async private void SC_Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("app://xamarin.com/menu/characters/savedcharacter");
        }

        async private void SP_Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("app://xamarin.com/menu/spells/allspells");
        }

        async private void SbC_Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("app://xamarin.com/menu/spells/spellsbyclass");
        }

        async private void SbS_Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("app://xamarin.com/menu/spells/spellsbyschool");
        }

        async private void SL_Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("app://xamarin.com/menu/spelllists");
        }
    }
}