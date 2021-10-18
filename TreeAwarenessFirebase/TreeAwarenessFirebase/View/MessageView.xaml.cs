using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TreeAwarenessFirebase.Model;
using TreeAwarenessFirebase.ViewModel;

namespace TreeAwarenessFirebase.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageView : ContentPage
    {
        public MessageView()
        {
            InitializeComponent();
            BindingContext = new MessageViewModel();
        }

        public async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var user = args.Item as UserMessages;
            if (user == null) return;

            await Navigation.PushAsync(new MessageDetailPage(user));
            lstMessage.SelectedItem = null;

        }
    }
}
