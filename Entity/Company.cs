using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Company
    {
        public Company()
        {
            Employeers = new HashSet<Employeer>();
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Employeer> Employeers { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
