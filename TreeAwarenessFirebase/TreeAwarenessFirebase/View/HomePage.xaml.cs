using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TreeAwarenessFirebase.Services;

namespace TreeAwarenessFirebase.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        iAuth auth;

        public HomePage()
        {
            InitializeComponent();

            auth = DependencyService.Get<iAuth>();
        }

        private async void ProjNextPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TreeView());
        }
        private async void MessageNextPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MessageView());
        }
        private async void AboutNextPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutInfo());
        }
        private async void PlantAtGardenPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMessagePage());
        }

        void SignOutButton_Clicked(object sender, EventArgs e)
        {
            var signOut = auth.SignOut();
            {
                Application.Current.MainPage = new MainPage();
            }
        }

        public Command LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PopAsync();
                });
            }
        }
    }
}