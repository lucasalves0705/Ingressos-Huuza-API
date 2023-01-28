using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Departament
    {
        public Departament()
        {
            Employeers = new HashSet<Employeer>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Employeer> Employeers { get; set; }
    }
}
