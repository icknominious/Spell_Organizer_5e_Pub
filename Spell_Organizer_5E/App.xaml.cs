using Spell_Organizer_5E.Data;
using Spell_Organizer_5E.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.IO;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Spell_Organizer_5E
{
    public partial class App : Application
    {
        static SODatabase database;
        static SpellList defaultSpellList;
        //public static IList<Spell> Spells { get; set; }

        readonly XMLReader myReader = new XMLReader();
        public static SODatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SODatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spells.db"));
                }
                return database;
            }
        }

        public static SpellList SpellList
        {
            get
            {
                if (defaultSpellList == null)
                {
                    defaultSpellList = new SpellList();
                    defaultSpellList.Name = "Default Spell List";
                    _ = Database.SaveSpellListAsync(defaultSpellList);
                }
                return defaultSpellList;
            }
        }

        public App()
        {
            LoadData();
            InitializeComponent();

            MainPage = new AppShell();
        }

        private async void LoadData()
        {
            await myReader.ReadFileAsync();
            //Spells = Database.GetSpellsAsync().Result;
    }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
