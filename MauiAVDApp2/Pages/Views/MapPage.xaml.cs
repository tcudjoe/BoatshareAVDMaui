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

        public MapPage(List<Boat> boats)
        {
            InitializeComponent();

            this.boats = boats;

            foreach (var boat in boats)
            {
                boatMap.Pins.Add(new Pin
                {
                    Label = "Boat: " + boat.BoatName,
                    Location = new Location(boat.BoatLatitude, boat.BoatLongitude)
                });
            }
        }
    }
}
