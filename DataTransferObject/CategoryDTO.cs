using System;
using System.Collections.Generic;

namespace DataTransferObject
{
    public partial class CategoryDTO
    {
        
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

    }
}
