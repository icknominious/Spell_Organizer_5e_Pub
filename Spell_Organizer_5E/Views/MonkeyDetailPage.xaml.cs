using Xamarin.Forms;
using Spell_Organizer_5E.ViewModels;

namespace Spell_Organizer_5E.Views
{
    public partial class MonkeyDetailPage : ContentPage
    {
        public MonkeyDetailPage()
        {
            InitializeComponent();
            BindingContext = new MonkeyDetailViewModel();
        }
    }
}
