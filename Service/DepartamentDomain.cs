using AutoMapper;
using DataTransferObject;
using Entity;
using Interface.Domain;
using Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DepartamentDomain : IDepartamentDomain
    {

        private IDepartamentRepository _repository { get; set; }

        private IErrorDomain Erro { get; set; }

        public DepartamentDomain(IDepartamentRepository repository, IErrorDomain error)
        {

            this._repository = repository;
            this.Erro = error;

        }

        public void Dispose()
        {

            this._repository.Dispose();

        }

        public ReturnDTO<List<DepartamentDTO>> ListAll()
        {

            var result = new ReturnDTO<List<DepartamentDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Departament>();

                list = _repository.ListAll();

                result.Result = mapper.Map<List<DepartamentDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

    }
}
