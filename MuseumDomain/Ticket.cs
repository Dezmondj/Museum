using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumDomain
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public string Adress_of_museum { get; set; }
        public Museum Museum { get; set; }
        public int WorkerID { get; set; }
        public Worker Worker { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
    }
}
