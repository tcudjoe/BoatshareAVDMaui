using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAVDApp2.Models
{
    public class Host : User
    {
        public List<Boat> BoatList { get; set; }
    }
}
