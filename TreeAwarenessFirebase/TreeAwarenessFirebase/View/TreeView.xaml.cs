using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAwarenessFirebase.ViewModel;
using TreeAwarenessFirebase.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreeAwarenessFirebase.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TreeView : ContentPage
    {
        public TreeView()
        {
            InitializeComponent();
            BindingContext = new TreesViewModel();
        }
        public async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var trees = args.Item as TreeInfo;
            if (trees == null) return;

            await Navigation.PushAsync(new TreeDetailPage(trees));
            lstTrees.SelectedItem = null;

        }
        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddTree());
        }
    }
}