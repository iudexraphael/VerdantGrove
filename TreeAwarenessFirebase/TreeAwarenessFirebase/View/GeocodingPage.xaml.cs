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
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;

namespace TreeAwarenessFirebase.View
{
    public partial class GeocodingPage : ContentPage
    {
        public GeocodingPage()
        {
            InitializeComponent();
            GetAddressCommand = new Command(async () => await OnGetAddress());
            GetPositionCommand = new Command(async () => await OnGetPosition());
            BindingContext = this;
        }

        string lat = "47.673988";
        string lon = "-122.121513";
        string address = "227b MacArthur Hwy, Angeles, Pampanga, Philippines";
        string geocodeAddress;
        string geocodePosition;

        public ICommand GetAddressCommand { get; }

        public ICommand GetPositionCommand { get; }

        public string Latitude
        {
            get => lat;
            set => SetProperty(ref lat, value);
        }

        public string Longitude
        {
            get => lon;
            set => SetProperty(ref lon, value);
        }

        public string GeocodeAddress
        {
            get => geocodeAddress;
            set => SetProperty(ref geocodeAddress, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public string GeocodePosition
        {
            get => geocodePosition;
            set => SetProperty(ref geocodePosition, value);
        }

        async Task OnGetPosition()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {

                var locations = await Geocoding.GetLocationsAsync(Address);
                Location location = locations.FirstOrDefault();
                if (location == null)
                {
                    GeocodePosition = "Unable to detect locations";
                }
                else
                {
                    GeocodePosition =
                        $"{nameof(location.Latitude)}: {location.Latitude}\n" +
                        $"{nameof(location.Longitude)}: {location.Longitude}\n";
                }
            }
            catch (Exception ex)
            {
                GeocodePosition = $"Unable to detect locations: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task OnGetAddress()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                double.TryParse(lat, out var lt);
                double.TryParse(lon, out var ln);

                var placemarks = await Geocoding.GetPlacemarksAsync(lt, ln);
                Placemark placemark = placemarks.FirstOrDefault();
                if (placemark == null)
                {
                    GeocodeAddress = "Unable to detect placemarks.";
                }
                else
                {
                    GeocodeAddress =
                        $"{nameof(placemark.AdminArea)}: {placemark.AdminArea}\n" +
                        $"{nameof(placemark.CountryCode)}: {placemark.CountryCode}\n" +
                        $"{nameof(placemark.CountryName)}: {placemark.CountryName}\n" +
                        $"{nameof(placemark.FeatureName)}: {placemark.FeatureName}\n" +
                        $"{nameof(placemark.Locality)}: {placemark.Locality}\n" +
                        $"{nameof(placemark.PostalCode)}: {placemark.PostalCode}\n" +
                        $"{nameof(placemark.SubAdminArea)}: {placemark.SubAdminArea}\n" +
                        $"{nameof(placemark.SubLocality)}: {placemark.SubLocality}\n" +
                        $"{nameof(placemark.SubThoroughfare)}: {placemark.SubThoroughfare}\n" +
                        $"{nameof(placemark.Thoroughfare)}: {placemark.Thoroughfare}\n";
                }
            }
            catch (Exception ex)
            {
                GeocodeAddress = $"Unable to detect placemarks: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected virtual bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null, Func<T, T, bool> validateValue = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            if (validateValue != null && !validateValue(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        bool isGettingLocation;
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            isGettingLocation = true;
            while (isGettingLocation)
            {
                var result = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
                resultLocation.Text = $"lat: {result.Latitude}, lng: {result.Longitude}{Environment.NewLine}";
                await Task.Delay(1000);
            }
        }

        private void Button_StopAction(System.Object sender, System.EventArgs e)
        {
            isGettingLocation = false;
        }

    }
}