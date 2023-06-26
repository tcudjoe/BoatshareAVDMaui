using MauiAVDApp2.Models;
using MauiAVDApp2.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;

namespace MauiAVDApp2.Pages.Views
{
    public partial class MapPage : ContentPage
    {
        private readonly List<Boat> boats;
        private readonly IGeocodingService geocodingService;

        public MapPage(List<Boat> boats, IGeocodingService geocodingService)
        {
            InitializeComponent();

            this.boats = boats;
            this.geocodingService = geocodingService;

            LoadBoatPinsAsync();
        }

        private async void LoadBoatPinsAsync()
        {
            foreach (var boat in boats)
            {
                GeocodeResult geocodeResult = await geocodingService.GeocodeAddress(boat.BoatCity);

                if (geocodeResult != null)
                {
                    Location location = new Location(geocodeResult.Latitude, geocodeResult.Longitude);

                    boatMap.Pins.Add(new Pin
                    {
                        Label = "Boat: " + boat.BoatName,
                        Location = location
                    });
                }
                else
                {
                    // Handle the case when geocoding fails or no result is obtained
                    await App.Current.MainPage.DisplayAlert("Geocoding Failed", "Unable to retrieve latitude and longitude for the specified address.", "OK");
                }
            }
        }
    }
}
