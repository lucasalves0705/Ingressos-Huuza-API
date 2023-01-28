using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Assessment
    {
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public int IdLogin { get; set; }
        public int Note { get; set; }
        public string Comment { get; set; } = null!;

        public virtual Event IdEventNavigation { get; set; } = null!;
        public virtual Login IdLoginNavigation { get; set; } = null!;
    }
}
