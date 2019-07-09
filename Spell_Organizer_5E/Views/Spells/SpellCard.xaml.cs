using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

namespace Spell_Organizer_5E.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("Name", "name")]
    public partial class SpellCard : ContentPage
    {
        public string Name
        {
            set => BindingContext = App.Database.GetSpellAsync(Uri.UnescapeDataString(value)).Result;
        }

        public SpellCard()
        {
            InitializeComponent();

            

            //ScrollView.Scrolled += (object sender, ScrolledEventArgs e) => {
            //    AddButton.TranslationY = e.ScrollY;
            //};
            //ScrollView.Scrolled += (object sender, ScrolledEventArgs e) => {
            //    RemoveButton.TranslationY = e.ScrollY;
            //};    derlict code, might reuse
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        /// <summary>
        /// Event handler for add button,
        /// Checks if the spell is in the list and if not add it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnAddButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (App.activeSpellList.Spells.Contains(button.CommandParameter.ToString()))
            {
                SCToast(0);
                //Console.WriteLine("Spell already in list!");
            }
            else
            {
                SCToast(1);
                App.activeSpellList.Spells += button.CommandParameter.ToString() + ", ";
                await App.Database.SaveSpellListAsync(App.activeSpellList);
                MessagingCenter.Send<SpellCard>(this, "UpdateSpellListsViewSC");
                //Console.WriteLine("Spell added to list!");
                //Console.WriteLine(App.activeSpellList.Spells);
            }
        }

        /// <summary>
        /// Event handler for remove button,
        /// Checks if spell is in the list and if so, removes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnRemoveButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (App.activeSpellList.Spells.Contains(button.CommandParameter.ToString()))
            {
                SCToast(2);
                App.activeSpellList.Spells = App.activeSpellList.Spells.Replace(button.CommandParameter.ToString() + ", ", "");
                await App.Database.SaveSpellListAsync(App.activeSpellList);
                MessagingCenter.Send<SpellCard>(this, "UpdateSpellListsViewSC");
                //Console.WriteLine(App.activeSpellList.Spells);
                //Console.WriteLine("Spell removed from list!");
            }
            else
            {
                SCToast(3);
                //Console.WriteLine("Spell not in list!");
            }
        }

        /// <summary>
        /// Puts a popup at the bottom of the display that confirms to the user their spell add/remove action
        /// </summary>
        /// <param name="arg"></param>
        private static void SCToast(int arg)
        {
            ToastConfig toastConfig;
            switch(arg)
            {
                case 0:
                    toastConfig = new ToastConfig("Spell already in list");
                    SetConfigs();
                    break;  
                case 1:
                    toastConfig = new ToastConfig("Spell added to list");
                    SetConfigs();
                    break;  
                case 2:
                    toastConfig = new ToastConfig("Spell removed from list");
                    SetConfigs();
                    break;  
                case 3:
                    toastConfig = new ToastConfig("Spell not in list");
                    SetConfigs();
                    break;  
            }
            
            void SetConfigs()
            {
                toastConfig.SetDuration(1000);
                toastConfig.SetBackgroundColor(Color.DimGray);
                UserDialogs.Instance.Toast(toastConfig);
            }
        }
    }
}
