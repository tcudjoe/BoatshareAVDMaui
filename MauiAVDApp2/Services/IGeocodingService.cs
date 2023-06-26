using MauiAVDApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAVDApp2.Services
{
    public interface IGeocodingService
    {
        Task<GeocodeResult> GeocodeAddress(string address);
    }
}
