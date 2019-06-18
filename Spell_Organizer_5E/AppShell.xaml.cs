﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Spell_Organizer_5E.Data;
using Spell_Organizer_5E.Views;

namespace Spell_Organizer_5E
{
    public partial class AppShell : Shell
    {
        //Random rand = new Random();
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public ICommand HelpCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));
        //public ICommand RandomPageCommand => new Command(async () => await NavigateToRandomPageAsync());

        XMLReader myReader = new XMLReader();

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }


        void RegisterRoutes()
        {
            routes.Add("monkeydetails", typeof(MonkeyDetailPage));
            routes.Add("spelllists", typeof(SpellLists));
            routes.Add("spellcards", typeof(SpellCard));
            routes.Add("dogdetails", typeof(DogDetailPage));
            routes.Add("elephantdetails", typeof(ElephantDetailPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }


       

        //    ShellNavigationState state = Shell.Current.CurrentState;
        //    await Shell.Current.GoToAsync($"{state.Location}/{destinationRoute}?name={animalName}");
        //    Shell.Current.FlyoutIsPresented = false;

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}
