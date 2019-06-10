using Spell_Organizer_5E.Data;
using Spell_Organizer_5E.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Spell_Organizer_5E
{
    public partial class App : Application
    {
        static SODatabase database;
        static SpellList spellList;

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
                if (spellList == null)
                {
                    spellList = new SpellList();
                    spellList.Name = "Default Spell List";
                    Database.SaveSpellListAsync(spellList);
                }
                return spellList;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            await myReader.ReadFileAsync();
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
