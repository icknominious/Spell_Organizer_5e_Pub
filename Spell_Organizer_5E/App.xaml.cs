﻿using Spell_Organizer_5E.Data;
using Spell_Organizer_5E.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Spell_Organizer_5E
{

    /// <summary>
    /// Main app class definition
    /// </summary>
    public partial class App : Application
    {
        static SODatabase database;
        static SpellList defaultSpellList;
        public static SpellList activeSpellList;

        readonly XMLReader myReader = new XMLReader();
        /// <summary>
        /// Iniatilizes DB if undefined
        /// </summary>
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
        /// <summary>
        /// Makes a default spell list if there is no spell list
        /// </summary>
        public static SpellList DefaultSpellList
        {
            get
            {
                defaultSpellList = App.Database.GetSpellListAsync("Default Spell List").Result;

                if (defaultSpellList != null)
                {
                    _ = App.Database.SaveSpellListAsync(defaultSpellList);
                }
                else
                {
                    defaultSpellList = new SpellList { Name = "Default Spell List" };
                    _ = App.Database.SaveSpellListAsync(defaultSpellList);
                }

                return defaultSpellList;
            }
        }
        /// <summary>
        /// App constructor
        /// </summary>
        public App()
        {
            LoadData();
            InitializeComponent();
            MainPage = new AppShell();
        }

        /// <summary>
        /// Reads spell contents of xml file and builds the App DB
        /// temp: activeSpellList becomes DefaultSpellList
        /// </summary>
        private async void LoadData()
        {
            await myReader.ReadFileAsync();
            activeSpellList = DefaultSpellList;
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


        //private async void SpellButton_Toggled(object sender, ToggledEventArgs e)
        //{
        //    if (e.Value)
        //    {
        //        Button button = (Button)sender;
        //        Spell spell = database.GetSpellAsync(button.CommandParameter.ToString()).Result;
        //        activeSpellList.Spells += (spell.Name) + ", ";
        //        await database.SaveSpellListAsync(activeSpellList);
        //        //Console.WriteLine(activeSpellList.Spells);
        //        //MessagingCenter.Send(this, "UpdateButton", spell.Name);
        //    }
        //    else
        //    {
        //        Button button = (Button)sender;
        //        Spell spell = database.GetSpellAsync(button.CommandParameter.ToString()).Result;
        //        activeSpellList.Spells = activeSpellList.Spells.Replace(spell.Name + ", ", "");
        //        await database.SaveSpellListAsync(activeSpellList);
        //        //Console.WriteLine(activeSpellList.Spells);
        //        //MessagingCenter.Send(this, "UpdateButton", spell.Name);
        //    }
        //}
    }
}
