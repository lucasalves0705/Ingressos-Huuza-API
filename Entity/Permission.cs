using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Permission
    {
        public Permission()
        {
            Logins = new HashSet<Login>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
