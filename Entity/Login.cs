using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Login
    {
        public Login()
        {
            Assessments = new HashSet<Assessment>();
            Employeers = new HashSet<Employeer>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPermission { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Permission IdPermissionNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<Employeer> Employeers { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
