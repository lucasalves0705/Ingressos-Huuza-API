using AutoMapper;
using DataTransferObject;
using DataTransferObject.EnumAndLabels;
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
    public class AuthenticationDomain : IAuthenticationDomain
    {

        private IAuthenticationRepository _repository { get; set; }

        private IErrorDomain Erro { get; set; }

        public AuthenticationDomain(IAuthenticationRepository repository, IErrorDomain error)
        {

            this._repository = repository;
            this.Erro = error;

        }

        public void Dispose()
        {

            this._repository.Dispose();

        }

        public ReturnDTO<LoginDTO> Find(LoginDTO login, int type)
        {

            var result = new ReturnDTO<LoginDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var entity = new Login();

                entity = _repository.FindAuthenticate(x => x.UserName == login.UserName && x.Password == login.Password && x.IdUserNavigation.IdUserType == type);

                result.Result = mapper.Map<LoginDTO>(entity);
                
                if (result.Result == null)
                {

                    result.Message = "Usuário e/ou senha inválido!";
                    result.Success = false;

                }

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Find");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<PermissionDTO> GetPermissionUser(int id)
        {

            var result = new ReturnDTO<PermissionDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var entity = new Permission();

                entity = _repository.GetPermissionUser(x => x.Id == id);

                result.Result = mapper.Map<PermissionDTO>(entity);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "GetPermissionUser");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

    }
}
