using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TreeAwarenessFirebase.Model;
using TreeAwarenessFirebase.ViewModel;
using TreeAwarenessFirebase.Services;
namespace TreeAwarenessFirebase.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TreeDetailPage : ContentPage
    {
        public TreeDetailPage()
        {

            InitializeComponent();
        }
        DBFirebase services;
        public TreeDetailPage(TreeInfo trees)
        {
            InitializeComponent();
            BindingContext = trees;
            services = new DBFirebase();
        }
        public async void BtnDelete(object sender, EventArgs e)
        {
            await services.DeleteTree(
                int.Parse(TreeCode.Text), Name.Text, InitialIdentification.Text, Notes.Text,
               GPSCoordinates.Text,
               Location.Text,
               Landmark.Text,
              Height.Text,
              Canopy.Text
              );
            await Navigation.PushAsync(new TreeView());
        }

        public async void BtnUpdate(object sender, EventArgs e)
        {
            await services.UpdateTree(
                 int.Parse(TreeCode.Text), Name.Text, InitialIdentification.Text, Notes.Text,
               GPSCoordinates.Text,
               Location.Text,
               Landmark.Text,
              Height.Text,
              Canopy.Text);
            await Navigation.PushAsync(new TreeView());
        }


    }
}