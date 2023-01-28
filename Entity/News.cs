using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class News
    {
        public int Id { get; set; }
        public int? IdEvent { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public DateTime? DateModification { get; set; }
        public DateTime? DatePublication { get; set; }
        public bool? Active { get; set; }

        public virtual Event? IdEventNavigation { get; set; }
    }
}
