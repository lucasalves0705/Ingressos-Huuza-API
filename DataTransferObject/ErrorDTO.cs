using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ErrorDTO
    {

        public Exception Error { get; set; }

        public string Message { get; set; }

        public string Origem { get; set; }

        public ErrorDTO (Exception error, string message, string origem = "")
        {

            this.Error = error;
            this.Message = message;
            this.Origem = origem;

        }

    }
}
