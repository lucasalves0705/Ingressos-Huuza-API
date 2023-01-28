using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IEventRepository : IBaseRepository<Event>
    {

        List<EventsRoom> ListInitialEvent(Expression<Func<EventsRoom, bool>> expression);

        List<Ticket> ListBoughtByUser(Expression<Func<Ticket, bool>> expression);

        List<Sale> ListBoughtByUserSale(Expression<Func<Sale, bool>> expression);

        Login TicketUserLogin(Expression<Func<Login, bool>> expression);

        List<Ticket> CountSeatEventRoom(Expression<Func<Ticket, bool>> expression);
        
        Assessment GetNoteEventUser(Expression<Func<Assessment, bool>> expression);

        EventsRoom FindInitialEvent(Expression<Func<EventsRoom, bool>> expression);

        EventsRoom FindEventRoom(Expression<Func<EventsRoom, bool>> expression);

        Event FindEvent(Expression<Func<Event, bool>> expression);

        List<Event> ListComingSoon(Expression<Func<Event, bool>> expression);
        
        List<Event> ListNowShowing(Expression<Func<Event, bool>> expression);

        Ticket InsertTicket(Ticket entity);

        Sale InsertSale(Sale entity);

        Assessment InsertAssessments(Assessment entity);

        EventsRoom InsertEventsRoom(EventsRoom entity);

        EventsRoom UpdateEventsRoom(EventsRoom entity);

        List<EventsRoom> EventRoomListAll();

    }
}
