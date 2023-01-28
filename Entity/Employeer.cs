using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Employeer
    {
        public int Id { get; set; }
        public int IdLogin { get; set; }
        public int IdDepartament { get; set; }
        public int IdCompany { get; set; }
        public bool Active { get; set; }

        public virtual Company IdCompanyNavigation { get; set; } = null!;
        public virtual Departament IdDepartamentNavigation { get; set; } = null!;
        public virtual Login IdLoginNavigation { get; set; } = null!;
    }
}
