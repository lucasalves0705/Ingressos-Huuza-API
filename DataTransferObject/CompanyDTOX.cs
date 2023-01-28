using System;
using System.Collections.Generic;

namespace DataTransferObject
{
    public partial class CompanyDTOX
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public bool Active { get; set; }

    }
}
