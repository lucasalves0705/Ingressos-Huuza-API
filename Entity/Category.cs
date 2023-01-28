using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Category
    {
        public Category()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
