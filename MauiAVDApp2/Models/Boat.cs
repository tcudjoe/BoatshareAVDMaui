using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAVDApp2.Models
{
    public class Boat
    {
        [PrimaryKey, AutoIncrement]
        public int BoatId { get; set; }
        public string BoatName { get; set; }
        public string BoatDescription { get; set; }
        public string BoatCity { get; set; }
        public BoatType BoatType { get; set; }
        public string BoatManufacturer { get; set; }
        public string BoatModel { get; set; }
        public string BoatImage { get; set; }
        public int BoatSeats { get; set; }
        public double BoatPrice { get; set; }
        public Boolean BoatWithSkipper { get; set; }
        public Boolean BoatWithLicense { get; set; }
        public double BoatLatitude { get; set; }
        public double BoatLongitude { get; set;}
        public double BoatDistance { get; set; }
        public Host BoatHost { get; set; }
    }
}
