using DataTransferObject;
using HuuzaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HuuzaAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EventController : Controller
    {

        [HttpGet]
        [Route("ListAll")]
        //[Authorize]
        public ReturnDTO<List<EventDTO>> ListAll()
        {

            var model = new EventModel();
            
            var result = model.ListAll();

            return result;

        }

        [HttpGet]
        [Route("GetEventInitial")]
        //[Authorize]
        public ReturnDTO<List<EventInitialDTO>> GetEventInitial()
        {

            var model = new EventModel();

            var result = model.GetEventInitial();

            return result;

        }

        [HttpGet]
        [Route("ListBought")]
        //[Authorize]
        public ReturnDTO<List<EventInitialDTO>> ListBought(int id)
        {

            var model = new EventModel();

            var result = model.ListBought(id);

            return result;

        }

        [HttpPost]
        [Route("Assessments")]
        //[Authorize]
        public ReturnDTO<EventInitialDTO> Assessments(EventInitialDTO @event)
        {

            var model = new EventModel();

            var result = model.Assessments(@event);

            return result;

        }

        [Route("Find")]
        [HttpGet]
        public ReturnDTO<EventDTO> Find(int id)
        {

            var model = new EventModel();

            var result = model.Find(id);

            return result;

        }

        [Route("FindEventInitial")]
        [HttpGet]
        public ReturnDTO<EventInitialDTO> FindEventInitial(int id)
        {

            var model = new EventModel();

            var result = model.FindEventInitial(id);

            return result;

        }

        [HttpPost]
        [Route("Checkout")]
        //[Authorize(Roles = "Cliente")]
        public ReturnDTO<EventInitialDTO> Checkout(EventInitialDTO @event)
        {

            var model = new EventModel();

            var result = model.Checkout(@event);

            return result;

        }

        [HttpPost]
        [Route("Save")]
        //[Authorize(Roles = "Administrador")]
        public ReturnDTO<EventDTO> Save(EventDTO @event)
        {

            var model = new EventModel();

            var result = model.Save(@event);

            return result;

        }

        [HttpPost]
        [Route("EventRoomSave")]
        //[Authorize(Roles = "Administrador")]
        public ReturnDTO<EventsRoomSaveDTO> EventRoomSave(EventsRoomSaveDTO eventRoom)
        {

            var model = new EventModel();

            var result = model.EventsRoomSave(eventRoom);

            return result;

        }

        [HttpGet]
        [Route("EventRoomListAll")]
        //[Authorize]
        public ReturnDTO<List<EventsRoomSaveDTO>> EventRoomListAll()
        {

            var model = new EventModel();

            var result = model.EventRoomListAll();

            return result;

        }

        [Route("EventRoomFind")]
        [HttpGet]
        public ReturnDTO<EventsRoomSaveDTO> EventRoomFind(int id)
        {

            var model = new EventModel();

            var result = model.EventRoomFind(id);

            return result;

        }

        [HttpDelete]
        [Route("Inactivate")]
        [Authorize(Roles = "Administrador")]
        public ReturnDTO<EventDTO> Inactivate(int id)
        {

            var model = new EventModel();

            var result = model.Inactivate(id);

            return result;

        }

        [HttpGet]
        [Route("ListInitialEvent")]
        public ReturnDTO<List<EventDTO>> ListInitialEvent()
        {

            var model = new EventModel();

            var result = model.ListInitialEvent();

            return result;

        }

        [HttpGet]
        [Route("ListComingSoon")]
        public ReturnDTO<List<EventDTO>> ListComingSoon()
        {

            var model = new EventModel();

            var result = model.ListComingSoon();

            return result;

        }

        [HttpGet]
        [Route("ListNowShowing")]
        public ReturnDTO<List<EventDTO>> ListNowShowing()
        {

            var model = new EventModel();

            var result = model.ListNowShowing();

            return result;

        }

    }
}
