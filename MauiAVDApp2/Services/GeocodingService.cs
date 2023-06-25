using MauiAVDApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAVDApp2.Services
{
    public class GeocodingService : IGeocodingService
    {
        public async Task<GeocodeResult> GeocodeAddress(string address)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(address);

                if (locations?.Any() == true)
                {
                    var location = locations.First();
                    return new GeocodeResult { Latitude = location.Latitude, Longitude = location.Longitude };
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                await App.Current.MainPage.DisplayAlert("Invalid device", "This device is not eligble for the locations feature. Use another device.", "OK");
            }
            catch (Exception ex)
            {
                // Unable to get location
                await App.Current.MainPage.DisplayAlert("Unable to get location", "We were unable to get the location.", "OK");
            }

            return null;
        }
    }
}
