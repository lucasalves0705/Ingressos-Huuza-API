using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class LoggedDTO
    {


        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public string Token { get; set; } = null!;
        public int IdUser { get; set; }
        public int IdLogin { get; set; }
        public string User { get; set; } = null!;
        public string Username { get; set; } = null!;

    }
}
