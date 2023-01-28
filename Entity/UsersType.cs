using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class UsersType
    {
        public UsersType()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
