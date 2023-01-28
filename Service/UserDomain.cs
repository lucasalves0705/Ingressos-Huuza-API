using Entity;
using Interface.Repository;
using Interface.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using AutoMapper;
using System.Linq.Expressions;
using DataTransferObject.EnumAndLabels;

namespace Domain
{
    public class UserDomain : IUserDomain
    {

        #region Init

        private IUserRepository _repository { get; set; }

        private IErrorDomain Erro { get; set; }

        public UserDomain (IUserRepository repository, IErrorDomain erro)
        {

            _repository = repository;
            Erro = erro;

        }

        #endregion

        #region Methods
        public ReturnDTO<EmployeerDTO> EmployersSave(CreateEmployersDTO obj)
        {

            var result = new ReturnDTO<EmployeerDTO>();

            try
            {

                if (obj != null)
                {

                    var loginResponsable = this._repository.GetUserLoginCompany(x => x.IdLogin == obj.IdResponsible);

                    if (loginResponsable != null)
                    {

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                        var user = this._repository.Find(x => x.Cpf == obj.Cpf);

                        if (user == null)
                        {

                            var newUser = new User();

                            newUser.Name = obj.Name;
                            newUser.Cpf = obj.Cpf;
                            newUser.IdUserType = EnumAndLabels.ID_USER_TYPE_ADMINISTRADOR;
                            newUser.Active = obj.ActiveUser;

                            this._repository.Insert(newUser);
                            this._repository.Save();

                            user = newUser;

                        }
                        else
                        {

                            user.Name = obj.Name;
                            user.Cpf = obj.Cpf;
                            user.Active = obj.ActiveUser;

                            this._repository.Update(user);
                            this._repository.Save();

                        }

                        if (obj.IdEmployee == 0)
                        {

                            if (loginResponsable.IdCompany > 0)
                            {

                                var loginCompany = this._repository.GetUserLoginCompany(x => x.IdLoginNavigation.IdUser == user.Id && x.IdCompany == loginResponsable.IdCompany);

                                if (loginCompany == null)
                                {

                                    var newLogin = new Login();
                                    newLogin.IdUser = user.Id;
                                    newLogin.UserName = obj.UserName;
                                    newLogin.Password = obj.Password;
                                    newLogin.IdPermission = obj.IdPermission;

                                    newLogin = this._repository.InsertLogin(newLogin);
                                    this._repository.Save();

                                    var newEmployer = new Employeer();
                                    newEmployer.IdLogin = newLogin.Id;
                                    newEmployer.IdDepartament = obj.IdDepartament;
                                    newEmployer.IdCompany = loginResponsable.IdCompany;
                                    newEmployer.Active = obj.ActiveEmployee;

                                    newEmployer = this._repository.InsertEmployeer(newEmployer);
                                    this._repository.Save();

                                    var employeerDTO = new EmployeerDTO();

                                    result.Result = mapper.Map<EmployeerDTO>(newEmployer);

                                }
                                else
                                {

                                    result.Success = false;
                                    result.Message = "Usuário já cadastrado no empresa!";

                                }

                            }
                            else
                            {

                                result.Success = false;
                                result.Message = "Empresa não informada!";

                            }

                        }
                        else
                        {

                            var loginCompany = this._repository.GetUserLoginCompany(x => x.IdLoginNavigation.IdUser == user.Id && x.IdCompany == loginResponsable.IdCompany);

                            if (loginCompany != null)
                            {
                                var updateLogin = this._repository.GetLogin(x => x.Id == loginCompany.IdLogin);
                                updateLogin.UserName = obj.UserName;
                                updateLogin.IdPermission = obj.IdPermission;

                                updateLogin = this._repository.UpdateLogin(updateLogin);
                                this._repository.Save();

                                var updateEmployer = this._repository.GetEmployee(x => x.Id == loginCompany.Id);
                                updateEmployer.IdDepartament = obj.IdDepartament;
                                updateEmployer.Active = obj.ActiveEmployee;

                                updateEmployer = this._repository.UpdateEmployeer(updateEmployer);
                                this._repository.Save();

                                var employeerDTO = new EmployeerDTO();

                                result.Result = mapper.Map<EmployeerDTO>(updateEmployer);

                            }
                            else
                            {

                                result.Success = false;
                                result.Message = "Usuário não cadastrado no empresa para atualizar!";

                            }

                        }
                                                
                    }
                    else
                    {

                        result.Success = false;
                        result.Message = "Responsavel não cadastrado na empresa!";

                    }

                }

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Save");
                result.Success = false;
                result.Message = ex.Message;

            }

            return result;

        }

        public ReturnDTO<UserDTO> Find(Expression<Func<User, bool>> expression)
        {

            var result = new ReturnDTO<UserDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new User();

                list = _repository.Find(expression);

                result.Result = mapper.Map<UserDTO>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Find");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<CreateEmployersDTO> FindEmployee(int idUser)
        {

            var result = new ReturnDTO<CreateEmployersDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var item = new Employeer();
                var employee = new CreateEmployersDTO();

                item = _repository.FindEmployee(x => x.Id == idUser);

                if (item != null)
                {

                    employee.IdEmployee = item.Id;
                    employee.Name = item.IdLoginNavigation.IdUserNavigation.Name;
                    employee.Cpf = item.IdLoginNavigation.IdUserNavigation.Cpf;
                    employee.UserName = item.IdLoginNavigation.UserName;
                    employee.IdDepartament = item.IdDepartament;
                    employee.IdPermission = item.IdLoginNavigation.IdPermission;
                    employee.ActiveEmployee = item.Active;

                }

                result.Result = employee;

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Find");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<UserDTO>> FindAll(Expression<Func<User, bool>> expression)
        {

            var result = new ReturnDTO<List<UserDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<User>();

                list = _repository.FindAll(expression);

                result.Result = mapper.Map<List<UserDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "FindAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<UserDTO>> ListAll()
        {

            var result = new ReturnDTO<List<UserDTO>>();

            try
            {
                
                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<User>();

                list = _repository.ListAll();

                result.Result = mapper.Map<List<UserDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<ListEmployersDTO>> ListAllEmployers()
        {

            var result = new ReturnDTO<List<ListEmployersDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Employeer>();
                var employers = new List<ListEmployersDTO>();

                list = _repository.ListAllEmployers();

                foreach(Employeer item in list)
                {

                    var employeer = new ListEmployersDTO();

                    employeer.Id = item.Id;
                    employeer.Departament = item.IdDepartamentNavigation.Description;
                    employeer.Name = item.IdLoginNavigation.IdUserNavigation.Name;
                    employeer.NameCompany = item.IdCompanyNavigation.Name;
                    employeer.IdLogin = item.IdLogin;
                    employeer.Active = item.Active;
                    employeer.IdCompany = item.IdCompany;

                    employers.Add(employeer);

                }
                
                result.Result = employers;

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListAllEmployers");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<PermissionDTO>> ListPermissions()
        {

            var result = new ReturnDTO<List<PermissionDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Permission>();

                list = _repository.ListPermissions();

                result.Result = mapper.Map<List<PermissionDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListPermissions");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public void Dispose()
        {

            this._repository.Dispose();

        }

        #endregion

    }
}
