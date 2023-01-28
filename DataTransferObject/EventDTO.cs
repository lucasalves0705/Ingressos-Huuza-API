using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class EventDTO
    {

        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Active { get; set; }

    }
}
