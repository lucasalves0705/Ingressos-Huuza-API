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
    public class CategoryDomain : ICategoryDomain
    {

        private ICategoryRepository _repository { get; set; }

        private IErrorDomain Erro { get; set; }

        public CategoryDomain(ICategoryRepository repository, IErrorDomain error)
        {

            this._repository = repository;
            this.Erro = error;

        }

        public void Dispose()
        {

            this._repository.Dispose();

        }

        public ReturnDTO<List<CategoryDTO>> ListAll()
        {

            var result = new ReturnDTO<List<CategoryDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Category>();

                list = _repository.ListAll();

                result.Result = mapper.Map<List<CategoryDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }
        public ReturnDTO<List<CategoryDTO>> ListActive()
        {

            var result = new ReturnDTO<List<CategoryDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Category>();

                list = _repository.FindAll(x => x.Active == true);

                result.Result = mapper.Map<List<CategoryDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListActive");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<CategoryDTO> Find(int id)
        {

            var result = new ReturnDTO<CategoryDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new Category();

                list = _repository.Find(x => x.Id == id);

                result.Result = mapper.Map<CategoryDTO>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Find");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<CategoryDTO> Save(CategoryDTO category)
        {

            var result = new ReturnDTO<CategoryDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var entity = new Category();

                entity = mapper.Map<Category>(category);

                if (entity.Id > 0)
                {

                    var saved = this._repository.FindAsNoTracking(x => x.Id == entity.Id);

                    if (saved != null)
                    {

                        entity.Active = saved.Active;

                        this._repository.Update(entity);

                    }

                }
                else
                {

                    entity.Active = true;

                    this._repository.Insert(entity);

                }

                this._repository.Save();

                result.Result = mapper.Map<CategoryDTO>(entity);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Save");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<CategoryDTO> Inactivate(int id)
        {

            var result = new ReturnDTO<CategoryDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var category = new Category();

                category = _repository.Find(x => x.Id == id);

                if (category.Id > 0)
                {

                    category.Active = !category.Active;

                    this._repository.Update(category);

                    this._repository.Save();

                }
                else
                {

                    result.Error = "Código do item não encontrado!";
                    result.Success = false;

                }

                result.Result = mapper.Map<CategoryDTO>(category);

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
