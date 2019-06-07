using Spell_Organizer_5E.Data;
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
            InitializeComponent();

            MainPage = new AppShell();
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
