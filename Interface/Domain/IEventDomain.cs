using DataTransferObject;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Domain
{
    public interface IEventDomain : IDisposable
    {

        ReturnDTO<EventDTO> Save(EventDTO entity);

        ReturnDTO<EventsRoomSaveDTO> EventsRoomSave(EventsRoomSaveDTO entity);

        ReturnDTO<List<EventsRoomSaveDTO>> EventRoomListAll();

        ReturnDTO<EventDTO> Find(int id);

        ReturnDTO<EventInitialDTO> FindEventInitial(int id);
        
        ReturnDTO<EventsRoomSaveDTO> EventRoomFind(int id);

        ReturnDTO<List<EventDTO>> FindAll(Expression<Func<Event, bool>> expression);

        ReturnDTO<List<EventDTO>> ListAll();

        ReturnDTO<List<EventInitialDTO>> GetEventInitial();
        
        ReturnDTO<List<EventInitialDTO>> ListBought(int id);

        ReturnDTO<List<EventDTO>> ListInitialEvent();

        ReturnDTO<List<EventDTO>> ListComingSoon();

        ReturnDTO<List<EventDTO>> ListNowShowing();
        
        ReturnDTO<List<EventDTO>> ListNewOnRise();

        ReturnDTO<EventDTO> Inactivate(int idEvent);

        ReturnDTO<EventInitialDTO> Checkout(EventInitialDTO obj);

        ReturnDTO<EventInitialDTO> Assessments(EventInitialDTO obj);

    }
}
