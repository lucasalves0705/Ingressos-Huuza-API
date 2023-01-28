using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class TicketDTO
    {

        public int Id { get; set; }
        public int IdSeat { get; set; }
        public int IdMovieRoom { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }

    }
}
