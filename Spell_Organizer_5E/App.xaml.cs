using Spell_Organizer_5E.Data;
using Spell_Organizer_5E.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System;
using System.Windows.Input;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Spell_Organizer_5E
{
    public partial class App : Application
    {
        static SODatabase database;
        public static SpellList activeSpellList;

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

        public App()
        {
            LoadData();
            InitializeComponent();

            MainPage = new AppShell();
        }

        private async void LoadData()
        {
            await myReader.ReadFileAsync();
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

        private void SpellButton_Pressed(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Spell spell = database.GetSpellAsync(button.CommandParameter.ToString()).Result;
            activeSpellList.Spells+=(spell.Name)+", ";
            Console.WriteLine(activeSpellList.Spells);
            
        }
    }
}
