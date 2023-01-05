using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumDomain
{
    public class Museum
    {
        [Key]
        public string Adress { get; set; }
        public string Name { get; set; }
        public int Count_of_employees { get; set; }
        public int Count_of_exhibit { get; set; }
        public int Count_of_hall { get; set; }
        public List<Hall> Halls { get; set; } = new();
        public List<Ticket> Tickets { get; set; } = new();
        public List<Worker> Workers { get; set; } = new();
    }
}
