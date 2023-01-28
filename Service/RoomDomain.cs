using AutoMapper;
using DataTransferObject;
using Entity;
using Interface.Domain;
using Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RoomDomain : IRoomDomain
    {

        private IRoomRepository _repository { get; set; }

        private IErrorDomain Erro { get; set; }

        public RoomDomain(IRoomRepository repository, IErrorDomain error)
        {

            this._repository = repository;
            this.Erro = error;

        }
        
        public void Dispose()
        {

            this._repository.Dispose();

        }

        public ReturnDTO<RoomDTO> Save(RoomDTO obj)
        {

            var result = new ReturnDTO<RoomDTO>();

            try
            {

                if(obj != null)
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                    var entity = new Room();

                    entity = mapper.Map<Room>(obj);

                    if (entity.Id == 0)
                    {

                        var employeer = this._repository.GetEmployeer(x => x.IdLogin == obj.IdLogin);

                        entity.IdCompany = employeer.IdCompany;

                        this._repository.Insert(entity);
                        this._repository.Save();

                        obj = mapper.Map<RoomDTO>(entity);

                        result.Result = obj;

                    }
                    else
                    {

                        var returnFind = this._repository.FindAsNoTracking(x => x.Id == entity.Id);

                        if(returnFind != null)
                        {

                            entity.IdCompany = returnFind.IdCompany;

                            this._repository.Update(entity);
                            this._repository.Save();

                        }
                        else
                        {

                            result.Success = false;
                            result.Message = "Sala não encontrado para alteração!";

                        }


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

        public ReturnDTO<RoomDTO> Find(int id)
        {

            var result = new ReturnDTO<RoomDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new Room();

                list = _repository.Find(x => x.Id == id);

                result.Result = mapper.Map<RoomDTO>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Find");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<RoomDTO>> FindAll(Expression<Func<Room, bool>> expression)
        {

            var result = new ReturnDTO<List<RoomDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Room>();

                list = _repository.FindAll(expression);

                result.Result = mapper.Map<List<RoomDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "FindAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<RoomDTO>> ListAll(int id)
        {

            var result = new ReturnDTO<List<RoomDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Room>();

                var employeer = this._repository.GetEmployeer(x => x.IdLogin == id);

                list = _repository.FindAll(x => x.IdCompany == employeer.IdCompany);

                result.Result = mapper.Map<List<RoomDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<RoomDTO> Inactivate(int id)
        {

            var result = new ReturnDTO<RoomDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var Roomx = new Room();

                Roomx = _repository.Find(x => x.Id == id);

                if (Roomx.Id > 0)
                {

                    Roomx.Active = !Roomx.Active;

                    this._repository.Update(Roomx);
                    this._repository.Save();

                }
                else
                {

                    result.Error = "Código do item não encontrado!";
                    result.Success = false;

                }

                result.Result = mapper.Map<RoomDTO>(Roomx);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Inactivate");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

    }
}
