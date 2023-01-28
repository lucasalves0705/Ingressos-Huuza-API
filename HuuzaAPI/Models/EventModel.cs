using DataTransferObject;
using Infrastructure.Fabric;

namespace HuuzaAPI.Models
{
    public class EventModel
    {

        public ReturnDTO<List<EventDTO>> ListAll()
        {

            var result = new ReturnDTO<List<EventDTO>>();

            using(var fabric = new EventFabric())
            {

                result = fabric.GetInstance().ListAll();

            }

            return result;

        }

        public ReturnDTO<List<EventInitialDTO>> GetEventInitial()
        {

            var result = new ReturnDTO<List<EventInitialDTO>>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().GetEventInitial();

            }

            return result;

        }

        public ReturnDTO<List<EventInitialDTO>> ListBought(int id)
        {

            var result = new ReturnDTO<List<EventInitialDTO>>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().ListBought(id);

            }

            return result;

        }

        public ReturnDTO<EventDTO> Find(int id)
        {

            var result = new ReturnDTO<EventDTO>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().Find(id);

            }

            return result;

        }

        public ReturnDTO<EventInitialDTO> FindEventInitial(int id)
        {

            var result = new ReturnDTO<EventInitialDTO>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().FindEventInitial(id);

            }

            return result;

        }

        public ReturnDTO<EventInitialDTO> Checkout(EventInitialDTO obj)
        {

            var result = new ReturnDTO<EventInitialDTO>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().Checkout(obj);

            }

            return result;

        }

        public ReturnDTO<EventInitialDTO> Assessments(EventInitialDTO obj)
        {

            var result = new ReturnDTO<EventInitialDTO>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().Assessments(obj);

            }

            return result;

        }

        public ReturnDTO<EventDTO> Save(EventDTO obj)
        {

            var result = new ReturnDTO<EventDTO>();

            using(var fabric = new EventFabric())
            {

                result = fabric.GetInstance().Save(obj);

            }

            return result;

        }

        public ReturnDTO<EventsRoomSaveDTO> EventsRoomSave(EventsRoomSaveDTO obj)
        {

            var result = new ReturnDTO<EventsRoomSaveDTO>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().EventsRoomSave(obj);

            }

            return result;

        }

        public ReturnDTO<List<EventsRoomSaveDTO>> EventRoomListAll()
        {

            var result = new ReturnDTO<List<EventsRoomSaveDTO>>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().EventRoomListAll();

            }

            return result;

        }

        public ReturnDTO<EventsRoomSaveDTO> EventRoomFind(int id)
        {

            var result = new ReturnDTO<EventsRoomSaveDTO>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().EventRoomFind(id);

            }

            return result;

        }

        public ReturnDTO<List<EventDTO>> ListInitialEvent()
        {

            var result = new ReturnDTO<List<EventDTO>>();

            using(var fabric = new EventFabric())
            {

                result = fabric.GetInstance().ListInitialEvent();

            }

            return result;

        }

        public ReturnDTO<List<EventDTO>> ListComingSoon()
        {

            var result = new ReturnDTO<List<EventDTO>>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().ListComingSoon();

            }

            return result;

        }

        public ReturnDTO<List<EventDTO>> ListNowShowing()
        {

            var result = new ReturnDTO<List<EventDTO>>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().ListNowShowing();

            }

            return result;

        }

        public ReturnDTO<EventDTO> Inactivate(int id)
        {

            var result = new ReturnDTO<EventDTO>();

            using (var fabric = new EventFabric())
            {

                result = fabric.GetInstance().Inactivate(id);

            }

            return result;

        }

    }

}
