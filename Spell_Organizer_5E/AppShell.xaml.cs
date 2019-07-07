using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spell_Organizer_5E.Views;

namespace Spell_Organizer_5E
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public ICommand HelpCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }


        void RegisterRoutes()
        {
            //routes.Add("spelllists", typeof(SpellLists));
            routes.Add("spelllistcards", typeof(SpellListCard));
            routes.Add("spellcards", typeof(SpellCard));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }


       

        //    ShellNavigationState state = Shell.Current.CurrentState;
        //    await Shell.Current.GoToAsync($"{state.Location}/{destinationRoute}?name={animalName}");
        //    Shell.Current.FlyoutIsPresented = false;

        void OnNavigating(Object sender, ShellNavigatingEventArgs e)
        {
            
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
            
        }

    }
}
