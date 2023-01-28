using DataTransferObject;
using HuuzaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HuuzaAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : Controller
    {

        [Route("ListAll")]
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public ReturnDTO<List<CategoryDTO>> ListAll()
        {

            var model = new CategoryModel();

            var result = model.ListAll();

            return result;

        }

        [Route("ListActive")]
        [HttpGet]
        public ReturnDTO<List<CategoryDTO>> ListActive()
        {

            var model = new CategoryModel();

            var result = model.ListActive();

            return result;

        }

        [Route("Find")]
        [HttpGet]
        public ReturnDTO<CategoryDTO> Find(int id)
        {

            var model = new CategoryModel();

            var result = model.Find(id);

            return result;

        }

        [Route("Save")]
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public ReturnDTO<CategoryDTO> Save(CategoryDTO category)
        {

            var model = new CategoryModel();

            var result = model.Save(category);

            return result;

        }

        [Route("Inactivate")]
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public ReturnDTO<CategoryDTO> Inactivate(int id)
        {

            var model = new CategoryModel();

            var result = model.Inactivate(id);

            return result;

        }

    }
}
