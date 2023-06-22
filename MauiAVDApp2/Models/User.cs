using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAVDApp2.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int userId { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool behost { get; set; }
        public bool hasLicense { get; set; }
    }
}
