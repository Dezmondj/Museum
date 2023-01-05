using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumDomain
{
    public class Worker : Person
    {
        public string Mobile_number { get; set; }
        public string Adress_of_museum { get; set; }
        public Museum Museum { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
    }
}
