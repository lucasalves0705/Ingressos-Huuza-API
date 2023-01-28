using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ReturnDTO<T>
    {

        public bool Success { get; set; } = true;
        public string Error { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

    }
}
