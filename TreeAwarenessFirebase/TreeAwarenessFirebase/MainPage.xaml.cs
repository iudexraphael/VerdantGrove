using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using TreeAwarenessFirebase.Services;

namespace TreeAwarenessFirebase
{
    public partial class MainPage : ContentPage
    {
        iAuth auth;
        public MainPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<iAuth>();

        }

        async void LoginClicked(object sender, EventArgs e)
        {

            try
            {
                if(EmailInput.Text !=null)
                {
                    Application.Current.MainPage = new NavigationPage();

                }
            }
            catch (NullReferenceException ex)
            {
                await DisplayAlert("Authentication Failed", "Email or Password field are Empty", "OK");
            }

            string token = await auth.LoginWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
            if (token != string.Empty)
            {
                Application.Current.MainPage = new NavigationPage(new View.HomePage()); 
            }

            else
            {
                await DisplayAlert("Authentication Failed", "Email or Password are Inccorect", "OK");
             

        }
    }

        void SignUpClicked(object sender, EventArgs e)
        {
            var signOut = auth.SignOut();
            if (signOut)
            {
                Application.Current.MainPage = new View.SignUpPage();
            }
        }

    }

}
