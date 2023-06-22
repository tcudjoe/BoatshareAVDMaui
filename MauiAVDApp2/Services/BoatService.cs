using MauiAVDApp2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAVDApp2.Services
{
    internal class BoatService : IBoatService
    {
        private SQLiteAsyncConnection _dbConnection;

        public BoatService()
        {
            SetupDb();
        }

        private async void SetupDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BoatApplication.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Boat>();
            }
        }
        public async Task<int> AddBoat(Boat boat)
        {
            return await _dbConnection.InsertAsync(boat);
        }

        public async Task<int> DeleteBoat(Boat boat)
        {
            return await _dbConnection.DeleteAsync(boat);
        }

        public async Task<int> UpdateBoat(Boat boat)
        {
            return await _dbConnection.UpdateAsync(boat);
        }

        public async Task<List<Boat>> GetAllBoats()
        {
            var boatList = await _dbConnection.Table<Boat>().ToListAsync();
            return boatList;
        }
    }
}
