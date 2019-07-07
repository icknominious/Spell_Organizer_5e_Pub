using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// Class for spells cards loaded from a spell list
    /// </summary>
    public partial class SpellListCard : CarouselPage
    {
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
            IList<Spell> SpellList = new List<Spell>();
            string[] separator = new string[] { ", " };
            foreach (string Spell in App.activeSpellList.Spells.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                SpellList.Add(App.Database.GetSpellAsync(Spell).Result);

            return SpellList;
        }

        async void OnRemoveButtonClicked(object sender, EventArgs args)
        {
            //TODO
        }
    }
}