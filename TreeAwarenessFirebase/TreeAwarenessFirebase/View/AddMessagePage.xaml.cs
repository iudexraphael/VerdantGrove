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
    public partial class AddMessagePage : ContentPage
    {
        public AddMessagePage()
        {
            InitializeComponent();
            BindingContext = new MessageViewModel();
        }
    }
}