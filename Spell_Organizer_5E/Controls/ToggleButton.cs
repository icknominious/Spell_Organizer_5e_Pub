//https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Spell_Organizer_5E.Controls
{
    class ToggleButton : Button
    {
        public event EventHandler<ToggledEventArgs> Toggled;

        public static BindableProperty IsToggledProperty =
            BindableProperty.Create("IsToggled", typeof(bool), typeof(ToggleButton), false,
                                    propertyChanged: OnIsToggledChanged);

        public ToggleButton()
        {
            Clicked += (sender, args) => IsToggled ^= true;

            //MessagingCenter.Subscribe<App, string>(this, "UpdateButton", (sender, arg) => {
            //    Label spellLabel = (Label)this.Parent.FindByName("SpellName");

            //    if (spellLabel.Text == arg)
            //    {
            //        //like put stuff here
            //        //Console.WriteLine(spellLabel.Text);
            //    }                  
            //});
        }

        public bool IsToggled
        {
            set { SetValue(IsToggledProperty, value); }
            get { return (bool)GetValue(IsToggledProperty); }
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            VisualStateManager.GoToState(this, "ToggledOff");
        }

        static void OnIsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ToggleButton toggleButton = (ToggleButton)bindable;
            bool isToggled = (bool)newValue;

            // Fire event
            toggleButton.Toggled?.Invoke(toggleButton, new ToggledEventArgs(isToggled));

            // Set the visual state
            VisualStateManager.GoToState(toggleButton, isToggled ? "ToggledOn" : "ToggledOff");
        }
    }
}
