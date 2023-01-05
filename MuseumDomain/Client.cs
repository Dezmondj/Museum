using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumDomain
{
    public class Client : Person
    {
        public string Status { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
