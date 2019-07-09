using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// Class for spells cards loaded from a spell list
    /// </summary>
    public partial class SpellListCard : CarouselPage
    {
        IList<Spell> SpellList = new List<Spell>();
        /// <summary>
        /// Constructor, loads spells into CarouselPage template
        /// </summary>
        public SpellListCard()
        {
            InitializeComponent();
            ItemsSource = SplitSpellList();

        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        /// <summary>
        /// Pulls spells param from the spell list and converts it from a csv string into a list of spells(class)
        /// </summary>
        /// <returns>IList<Spell></returns>
        public IList<Spell> SplitSpellList()
        {
         
            string[] separator = new string[] { ", " };
            foreach (string Spell in App.activeSpellList.Spells.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                SpellList.Add(App.Database.GetSpellAsync(Spell).Result);

            return SpellList;
        }

        async void OnRemoveButtonClicked(object sender, EventArgs args)
        {
            //TODO
            Button button = (Button)sender;

            SpellList.Remove(App.Database.GetSpellAsync(button.CommandParameter.ToString()).Result);
            App.activeSpellList.Spells = App.activeSpellList.Spells.Replace(button.CommandParameter.ToString() + ", ", "");
            await App.Database.SaveSpellListAsync(App.activeSpellList);

            //ItemsSource = SplitSpellList();
            MessagingCenter.Send<SpellListCard>(this, "UpdateSpellListsViewSLC");
            SLCToast();
        }

        private static void SLCToast()
        {
            ToastConfig toastConfig = new ToastConfig("Spell removed from list");
            toastConfig.SetDuration(1000);
            toastConfig.SetBackgroundColor(Color.DimGray);
            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}