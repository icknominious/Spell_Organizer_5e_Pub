using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("Name", "name")]
    public partial class SpellListCard : CarouselPage
    {
        public string Name
        {
            //set => BindingContext = App.Database.GetSpellAsync(Uri.UnescapeDataString(value)).Result;

            set => BindingContext = SplitSpellList();
        }
        public SpellListCard()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        public IList<Spell> SplitSpellList()
        {
            IList<Spell> SpellList = new List<Spell>();
            string[] separator = new string[] { ", " };
            foreach (string Spell in App.activeSpellList.Spells.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                SpellList.Add(App.Database.GetSpellAsync(Spell).Result);

            return SpellList;
        }
    }
}