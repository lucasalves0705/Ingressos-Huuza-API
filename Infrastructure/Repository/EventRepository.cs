using Entity;
using Interface.Repository;
using Interface.WorkUnit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {

        public EventRepository(IHuuzaApiWorkUnit context) : base(context)
        {
        }
        
        public List<EventsRoom> ListInitialEvent(Expression<Func<EventsRoom, bool>> expression)
        {

            var result = this._context.EventsRooms
                .Include(s => s.IdEventsNavigation)
                .Include(s => s.IdRoomNavigation)
                .Include(s => s.IdEventsNavigation.IdCategoryNavigation)
                .ToList();

            return result;

        }

        public List<Ticket> ListBoughtByUser(Expression<Func<Ticket, bool>> expression)
        {

            var result = this._context.Tickets
                .Include(s => s.IdSaleNavigation)
                .Include(s => s.IdSaleNavigation.IdLoginNavigation)
                .Include(s => s.IdMovieRoomNavigation)
                .Include(s => s.IdMovieRoomNavigation.IdEventsNavigation)
                .Include(s => s.IdMovieRoomNavigation.IdEventsNavigation.IdCategoryNavigation)
                .Include(s => s.IdMovieRoomNavigation.IdRoomNavigation)
                .ToList();

            return result;

        }

        public List<Sale> ListBoughtByUserSale(Expression<Func<Sale, bool>> expression)
        {

            var result = this._context.Sales
                .Include(s => s.IdLoginNavigation)
                .ToList();

            return result;

        }

        public Login TicketUserLogin(Expression<Func<Login, bool>> expression)
        {

            var result = this._context.Logins
                .Include(s => s.IdUserNavigation)
                .FirstOrDefault();

            return result;

        }

        public List<Ticket> CountSeatEventRoom(Expression<Func<Ticket, bool>> expression)
        {

            var result = this._context.Tickets
                .Include(s => s.IdMovieRoomNavigation)
                .ToList();

            return result;

        }

        public Assessment GetNoteEventUser(Expression<Func<Assessment, bool>> expression)
        { 

            var result = this._context.Assessments
                .FirstOrDefault();

            return result;

        }

        public EventsRoom FindInitialEvent(Expression<Func<EventsRoom, bool>> expression)
        {

            var result = this._context.EventsRooms
                .Include(s => s.IdEventsNavigation)
                .Include(s => s.IdRoomNavigation)
                .Include(s => s.IdEventsNavigation.IdCategoryNavigation)
                .Where(expression)
                .FirstOrDefault();

            return result;

        }

        public EventsRoom FindEventRoom(Expression<Func<EventsRoom, bool>> expression)
        {

            var result = this._context.EventsRooms
                .Include(s => s.IdEventsNavigation)
                .Include(s => s.IdRoomNavigation)
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();

            return result;

        }

        public Event FindEvent(Expression<Func<Event, bool>> expression)
        {

            var result = this._context.Events
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();

            return result;

        }

        public List<Event> ListComingSoon(Expression<Func<Event, bool>> expression)
        {

            var result = this._context.Events
                .Where(expression)
                .Include(s => s.InitialEvents)
                .Include(s => s.VideosEvents)
                .ToList();

            return result;

        }

        public List<Event> ListNowShowing(Expression<Func<Event, bool>> expression)
        {

            var result = this._context.Events
                .Where(expression)
                .Include(s => s.InitialEvents)
                .Include(s => s.VideosEvents)
                .ToList();

            return result;

        }

        public Ticket InsertTicket(Ticket entity)
        {

            base._context.Set<Ticket>().Add(entity);

            return entity;

        }

        public Assessment InsertAssessments(Assessment entity)
        {

            base._context.Set<Assessment>().Add(entity);

            return entity;

        }

        public Sale InsertSale(Sale entity)
        {

            base._context.Set<Sale>().Add(entity);

            return entity;

        }

        public EventsRoom InsertEventsRoom(EventsRoom entity)
        {

            base._context.Set<EventsRoom>().Add(entity);

            return entity;

        }

        public EventsRoom UpdateEventsRoom(EventsRoom entity)
        {

            base._context.Set<EventsRoom>().Update(entity);

            return entity;

        }

        public List<EventsRoom> EventRoomListAll()
        {

            var result = this._context.EventsRooms
                .Include(s => s.IdEventsNavigation)
                .Include(s => s.IdRoomNavigation)
                .ToList();

            return result;

        }

    }
}
