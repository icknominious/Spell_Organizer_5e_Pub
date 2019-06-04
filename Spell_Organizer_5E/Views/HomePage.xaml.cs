 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spell_Organizer_5E.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spell_Organizer_5E.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        XMLReader myReader = new XMLReader();
        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await myReader.ReadFileAsync();
        }
    }
}