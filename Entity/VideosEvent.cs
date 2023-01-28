using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class VideosEvent
    {
        public int Id { get; set; }
        public int? IdEvent { get; set; }
        public string? Src { get; set; }
        public bool? Active { get; set; }

        public virtual Event? IdEventNavigation { get; set; }
    }
}
