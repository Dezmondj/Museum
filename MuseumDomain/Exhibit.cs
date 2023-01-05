using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumDomain
{
    public class Exhibit
    {
        public int ExhibitID { get; set; }
        public int HallID { get; set; }
        public Hall Hall { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Storage_conditions { get; set; }
    }
}
