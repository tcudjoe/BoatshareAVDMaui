using MauiAVDApp2.Models;
using MauiAVDApp2.Services;
using MauiAVDApp2.Pages.Views;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;

namespace MauiAVDApp2
{
    public partial class MainPage : ContentPage
    {
        private IBoatService boatService;
        private readonly IGeocodingService geocodingService;
        public ObservableCollection<Boat> Boats { get; set; }

        public MainPage()
        {
            InitializeComponent();
            boatService = new BoatService();
            geocodingService = new GeocodingService(); 
            Boats = new ObservableCollection<Boat>();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadBoats();
        }

        private async Task LoadBoats()
        {
            // Call the boat service to get all boats
            var boatList = await boatService.GetAllBoats();

            // Clear the existing boat collection
            Boats.Clear();

            // Add boats to the collection
            foreach (var boat in boatList)
            {
                Boats.Add(boat);
            }
        }

        private void StackLayout_Tapped(object sender, EventArgs e)
        {
            if (sender is ContentView contentView && contentView.BindingContext is Boat selectedBoat)
            {
                Navigation.PushAsync(new BoatDetail(selectedBoat));
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Navigate to the map page and pass the list of boats and the geocoding service
            Navigation.PushAsync(new MapPage(Boats.ToList(), geocodingService));
        }
    }
}
