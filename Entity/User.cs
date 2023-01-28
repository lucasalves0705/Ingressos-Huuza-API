using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class User
    {
        public User()
        {
            Logins = new HashSet<Login>();
        }

        public int Id { get; set; }
        public int IdUserType { get; set; }
        public string Cpf { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Active { get; set; }

        public virtual UsersType IdUserTypeNavigation { get; set; } = null!;
        public virtual ICollection<Login> Logins { get; set; }
    }
}
