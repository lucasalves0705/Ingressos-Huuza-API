using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class InitialEvent
    {
        public int Id { get; set; }
        public int? IdEvent { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? Active { get; set; }

        public virtual Event? IdEventNavigation { get; set; }
    }
}
