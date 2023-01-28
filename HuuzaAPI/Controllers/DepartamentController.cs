using DataTransferObject;
using HuuzaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HuuzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : Controller
    {
        [HttpGet]
        [Route("ListAll")]
        public ReturnDTO<List<DepartamentDTO>> ListAll()
        {

            var model = new DepartamentModel();

            var result = model.ListAll();

            return result;

        }

    }
}
