using System;
using System.Collections.Generic;

namespace DataTransferObject
{
    public partial class LoginDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPermission { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
