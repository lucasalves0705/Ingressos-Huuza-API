using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Domain
{
    public interface IErrorDomain
    {

        List<ErrorDTO> getError();

        bool Success();

        void Add(Exception exception, string origem);

    }
}
