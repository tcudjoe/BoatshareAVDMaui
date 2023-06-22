using MauiAVDApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAVDApp2.Services
{
    internal interface IBoatService
    {
        Task<List<Boat>> GetBoatListAsync(Boat boat);
        Task<int> AddBoat(Boat boat);
        Task<int> UpdateBoat(Boat boat);
        Task<int> DeleteBoat(Boat boat);

    }
}
