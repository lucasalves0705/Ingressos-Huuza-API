using DataTransferObject;
using HuuzaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HuuzaAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RoomController : Controller
    {

        [HttpGet]
        [Route("ListAll")]
        //[Authorize]
        public ReturnDTO<List<RoomDTO>> ListAll(int id)
        {

            var model = new RoomModel();

            var result = model.ListAll(id);

            return result;

        }

        [Route("Find")]
        [HttpGet]
        public ReturnDTO<RoomDTO> Find(int id)
        {

            var model = new RoomModel();

            var result = model.Find(id);

            return result;

        }

        [HttpPost]
        [Route("Save")]
        //[Authorize(Roles = "Administrador")]
        public ReturnDTO<RoomDTO> Save(RoomDTO room)
        {

            var model = new RoomModel();

            var result = model.Save(room);

            return result;

        }

    }
}
