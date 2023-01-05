using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumDomain
{
    public class Hall
    {
        public int HallID { get; set; }
        public string Adress_of_museum { get; set; }
        public Museum Museum { get; set; }
        public string Type_of_hall { get; set; }
        public int Count_of_exhibit { get; set; }

        public List<Exhibit> Exhibits { get; set; } = new();
    }
}
