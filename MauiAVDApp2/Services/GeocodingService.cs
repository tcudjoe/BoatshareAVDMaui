using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MauiAVDApp2.Models;

namespace MauiAVDApp2.Services
{
    public class GeocodingService : IGeocodingService
    {
        public async Task<GeocodeResult> GeocodeAddress(string address)
        {
            try
            {
                IEnumerable<Location> locations = await Geocoding.GetLocationsAsync(address);
                Location location = locations?.FirstOrDefault();

                if (location != null)
                {
                    return new GeocodeResult
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude
                    };
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                await App.Current.MainPage.DisplayAlert("Invalid device", "This device is not eligible for the locations feature. Use another device.", "OK");
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
