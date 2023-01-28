using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class EventInitialDTO
    {

        public int IdEvent { get; set; }
        public int IdCategory { get; set; }
        public int IdRoom { get; set; }
        public int IdLogin { get; set; }
        public int RemainingSeat { get; set; }
        public int Note { get; set; }
        public int QuantitySeat { get; set; }
        public string NameRoom { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public string NameCategory { get; set; } = null!;
        public string NameEvent { get; set; } = null!;
        public string? DescriptionEvent { get; set; }
        public DateTime DatePresetion { get; set; }
        public DateTime DataBuy { get; set; }
        public DateTime EndPresentation { get; set; }
        public bool ActiveEvent { get; set; }

    }
}
