using DataTransferObject;
using Interface.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ErrorDomain : IErrorDomain
    {

        private List<ErrorDTO> Error { get; set; }

        public ErrorDomain()
        {

            this.Error = new List<ErrorDTO>();

        }

        public List<ErrorDTO> getError()
        {

            return this.Error;

        }

        public bool Success()
        {

            return !this.Error.Any();

        }

        public void Add(Exception exception, string origem)
        {

            this.Error.Add(new ErrorDTO(exception, origem));

        }

    }
}
