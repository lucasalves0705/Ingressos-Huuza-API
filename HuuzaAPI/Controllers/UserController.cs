using DataTransferObject;
using HuuzaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HuuzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        [HttpPost]
        [Route("ListAll")]
        public ReturnDTO<List<UserDTO>> ListAll()
        {

            var model = new UserModel();

            var result = model.ListAll();

            return result;

        }

        [HttpPost]
        [Route("Find")]
        public ReturnDTO<UserDTO> Find(int idUser)
        {

            var model = new UserModel();

            var result = model.Find(idUser);

            return result;

        }

        [HttpGet]
        [Route("FindEmployee")]
        public ReturnDTO<CreateEmployersDTO> FindEmployee(int id)
        {

            var model = new UserModel();

            var result = model.FindEmployee(id);

            return result;

        }

        [HttpGet]
        [Route("ListAllEmployers")]
        public ReturnDTO<List<ListEmployersDTO>> ListAllEmployers()
        {

            var model = new UserModel();

            var result = model.ListAllEmployers();

            return result;

        }

        [HttpGet]
        [Route("ListPermissions")]
        public ReturnDTO<List<PermissionDTO>> ListPermissions()
        {

            var model = new UserModel();

            var result = model.ListPermissions();

            return result;

        }

        [HttpPost]
        [Route("EmployersSave")]
        //[Authorize(Roles = "Administrador")]
        public ReturnDTO<EmployeerDTO> EmployersSave(CreateEmployersDTO employeer)
        {

            var model = new UserModel();

            var result = model.EmployersSave(employeer);

            return result;

        }

    }
}
