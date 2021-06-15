
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;

namespace FingerPrintAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           var Isavaliable =  await CrossFingerprint.Current.IsAvailableAsync();
            if(!Isavaliable)
            {
                await DisplayAlert("Warning", "No fingerprint is found", "Ok");
                return;
            }
            var AuthFinger = await CrossFingerprint.Current.AuthenticateAsync
                (new AuthenticationRequestConfiguration("Heads up!", "Use the Fingerprint to unlock the button!,Please!"));
            if(AuthFinger.Authenticated)
            {
                await DisplayAlert("Yaay!", "Finger Print Matched", "Thanks");
            }
        }
    }
}
