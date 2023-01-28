using AutoMapper;
using DataTransferObject;
using Entity;
using Interface.Domain;
using Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EventDomain : IEventDomain
    {

        private IEventRepository _repository { get; set; }

        private IErrorDomain Erro { get; set; }

        public EventDomain(IEventRepository repository, IErrorDomain error)
        {

            this._repository = repository;
            this.Erro = error;

        }
        
        public void Dispose()
        {

            this._repository.Dispose();

        }

        public ReturnDTO<EventDTO> Save(EventDTO obj)
        {

            var result = new ReturnDTO<EventDTO>();

            try
            {

                if(obj != null)
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                    var entity = new Event();

                    entity = mapper.Map<Event>(obj);

                    if (entity.Id == 0)
                    {

                        entity.Active = true;
                        entity.ReleaseDate = DateTime.Now;

                        this._repository.Insert(entity);
                        this._repository.Save();

                        obj = mapper.Map<EventDTO>(entity);

                        result.Result = obj;

                    }
                    else
                    {

                        var returnFind = this._repository.FindEvent(x => x.Id == entity.Id);

                        if(returnFind != null)
                        {

                            entity.Active = returnFind.Active;
                            entity.ReleaseDate = returnFind.ReleaseDate;

                            this._repository.Update(entity);
                            this._repository.Save();

                            obj = mapper.Map<EventDTO>(entity);

                            result.Result = obj;

                        }
                        else
                        {

                            result.Success = false;
                            result.Message = "Evento não encontrado para alteração!";

                        }


                    }

                }

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Save");
                result.Success = false;
                result.Message = ex.Message;

            }

            return result;

        }

        public ReturnDTO<EventsRoomSaveDTO> EventsRoomSave(EventsRoomSaveDTO obj)
        {

            var result = new ReturnDTO<EventsRoomSaveDTO>();

            try
            {

                if (obj != null)
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                    var entity = new EventsRoom();

                    entity = mapper.Map<EventsRoom>(obj);

                    var returnFind = this._repository.FindEventRoom(x => 
                        x.IdRoom == entity.IdRoom 
                        && x.DatePresetion <= entity.DatePresetion
                        && x.DatePresetion.AddHours(x.Duration) > entity.DatePresetion
                        && x.Active == true);

                    if (returnFind == null || (entity.Id > 0 && entity.Id == returnFind.Id))
                    {

                        if (entity.Id == 0)
                        {

                            entity.Active = true;

                            this._repository.InsertEventsRoom(entity);
                            this._repository.Save();

                            obj = mapper.Map<EventsRoomSaveDTO>(entity);

                            result.Result = obj;

                        }
                        else
                        {

                            var returnFindEvent = this._repository.FindEventRoom(x => x.Id == entity.Id);

                            if (returnFindEvent != null)
                            {

                                this._repository.UpdateEventsRoom(entity);
                                this._repository.Save();
                                
                                obj = mapper.Map<EventsRoomSaveDTO>(entity);

                                result.Result = obj;

                            }
                            else
                            {

                                result.Success = false;
                                result.Message = "Ensalamento não encontrado para alteração!";

                            }

                        }

                    }
                    else
                    {

                        result.Success = false;
                        result.Message = "A sala já foi reservado nessa data e horário!";

                    }

                }

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "EventsRoomSave");
                result.Success = false;
                result.Message = ex.Message;

            }

            return result;

        }

        public ReturnDTO<List<EventsRoomSaveDTO>> EventRoomListAll()
        {

            var result = new ReturnDTO<List<EventsRoomSaveDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<EventsRoom>();

                list = _repository.EventRoomListAll();

                var events = new List<EventsRoomSaveDTO>();

                foreach (EventsRoom item in list)
                {

                    var eventItem = new EventsRoomSaveDTO();

                    eventItem.Id = item.Id;
                    eventItem.IdEvents = item.IdEvents;
                    eventItem.IdRoom = item.IdRoom;
                    eventItem.NameEvent = item.IdEventsNavigation.Name;
                    eventItem.NameRoom = item.IdRoomNavigation.Name;
                    eventItem.DatePresetion = item.DatePresetion;
                    eventItem.Active = item.Active;

                    events.Add(eventItem);

                }

                result.Result = events;

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<EventsRoomSaveDTO> EventRoomFind(int id)
        {

            var result = new ReturnDTO<EventsRoomSaveDTO>();

            try
            {

                var item = _repository.FindEventRoom(x => x.Id == id);

                if (item != null)
                {

                    var eventItem = new EventsRoomSaveDTO();

                    eventItem.Id = item.Id;
                    eventItem.IdEvents = item.IdEvents;
                    eventItem.IdRoom = item.IdRoom;
                    eventItem.NameEvent = item.IdEventsNavigation.Name;
                    eventItem.NameRoom = item.IdRoomNavigation.Name;
                    eventItem.DatePresetion = item.DatePresetion;
                    eventItem.Duration = item.Duration;
                    eventItem.Active = item.Active;

                    result.Result = eventItem;

                }

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "EventRoomFind");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<EventDTO> Find(int id)
        {

            var result = new ReturnDTO<EventDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new Event();

                list = _repository.Find(x => x.Id == id);

                result.Result = mapper.Map<EventDTO>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Find");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<EventDTO>> FindAll(Expression<Func<Event, bool>> expression)
        {

            var result = new ReturnDTO<List<EventDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Event>();

                list = _repository.FindAll(expression);

                result.Result = mapper.Map<List<EventDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "FindAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<EventDTO>> ListAll()
        {

            var result = new ReturnDTO<List<EventDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Event>();

                list = _repository.ListAll();

                result.Result = mapper.Map<List<EventDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<EventInitialDTO> Checkout(EventInitialDTO obj)
        {

            var result = new ReturnDTO<EventInitialDTO>();

            try
            {

                if (obj != null)
                {

                    var eventRoom = this._repository.FindEventRoom(x => x.Id == obj.IdEvent);

                    var sale = new Sale();
                    sale.IdLogin = obj.IdLogin;
                    sale.Data = DateTime.Now;
                    sale.Active = true;

                    sale = this._repository.InsertSale(sale);
                    this._repository.Save();

                    for (var i = 0; i < obj.QuantitySeat; i++)
                    {

                        var ticket = new Ticket();
                        ticket.IdMovieRoom = eventRoom.Id;
                        ticket.IdSeat = 1;
                        ticket.IdSale = sale.Id;
                        ticket.Date = DateTime.Now;
                        ticket.Active = true;

                        ticket = this._repository.InsertTicket(ticket);
                        this._repository.Save();

                    }

                    result.Success = true;
                    result.Result = obj;

                }

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Checkout");
                result.Success = false;
                result.Message = ex.Message;

            }

            return result;

        }


        public ReturnDTO<EventInitialDTO> Assessments(EventInitialDTO obj)
        {

            var result = new ReturnDTO<EventInitialDTO>();

            try
            {

                if (obj != null)
                {

                    var Assessments = new Assessment();

                    Assessments.IdEvent = obj.IdEvent;
                    Assessments.IdLogin = obj.IdLogin;
                    Assessments.Note = obj.Note;
                    Assessments.Comment = obj.Comment;

                    Assessments = this._repository.InsertAssessments(Assessments);
                    this._repository.Save();

                    result.Success = true;
                    result.Result = obj;

                }

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "Checkout");
                result.Success = false;
                result.Message = ex.Message;

            }

            return result;

        }

        public ReturnDTO<List<EventInitialDTO>> GetEventInitial()
        {

            var result = new ReturnDTO<List<EventInitialDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<EventsRoom>();

                list = _repository.ListInitialEvent(x => x.IdEventsNavigation.Active == true);

                var events = new List<EventInitialDTO>();

                foreach (EventsRoom item in list)
                {
                    
                    int qty = _repository.CountSeatEventRoom(x => x.IdMovieRoomNavigation.Id == item.Id).Count();

                    var initial = new EventInitialDTO();

                    initial.IdEvent = item.IdEvents;
                    initial.IdCategory = item.IdEventsNavigation.IdCategory;
                    initial.IdRoom = item.IdRoom;
                    initial.NameRoom = item.IdRoomNavigation.Name;
                    initial.RemainingSeat = item.IdRoomNavigation.MaxSeats - qty;
                    initial.NameCategory = item.IdEventsNavigation.IdCategoryNavigation.Description;
                    initial.NameEvent = item.IdEventsNavigation.Name;
                    initial.DescriptionEvent = item.IdEventsNavigation.Description;
                    initial.DatePresetion = item.DatePresetion;
                    initial.ActiveEvent = item.IdEventsNavigation.Active;

                    events.Add(initial);

                }

                result.Result = events;

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListAll");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<EventInitialDTO>> ListBought(int id)
        {

            var result = new ReturnDTO<List<EventInitialDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Ticket>();

                var login = _repository.TicketUserLogin(x => x.Id == id);

                list = _repository.ListBoughtByUser(x => x.IdSaleNavigation.IdLogin == login.Id);
                
                var events = new List<EventInitialDTO>();

                foreach (Ticket item in list)
                {

                    int qty = _repository.CountSeatEventRoom(x => x.IdMovieRoomNavigation.Id == item.Id).Count();
                    var note = _repository.GetNoteEventUser(x => x.IdLogin == login.Id && x.IdEvent == item.IdMovieRoomNavigation.IdEvents);

                    var initial = new EventInitialDTO();

                    initial.IdEvent = item.IdMovieRoomNavigation.IdEvents;
                    initial.IdCategory = item.IdMovieRoomNavigation.IdEventsNavigation.IdCategory;
                    initial.IdRoom = item.IdMovieRoomNavigation.IdRoom;
                    initial.RemainingSeat = item.IdMovieRoomNavigation.IdRoomNavigation.MaxSeats - qty;
                    initial.NameRoom = item.IdMovieRoomNavigation.IdRoomNavigation.Name;
                    initial.NameCategory = item.IdMovieRoomNavigation.IdEventsNavigation.IdCategoryNavigation.Description;
                    initial.NameEvent = item.IdMovieRoomNavigation.IdEventsNavigation.Name;
                    initial.DescriptionEvent = item.IdMovieRoomNavigation.IdEventsNavigation.Description;
                    initial.DatePresetion = item.IdMovieRoomNavigation.DatePresetion;
                    initial.DataBuy = item.IdSaleNavigation.Data;
                    initial.ActiveEvent = item.IdMovieRoomNavigation.IdEventsNavigation.Active;
                    initial.Note = note.Note;

                    events.Add(initial);

                }

                result.Result = events;

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListBought");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<EventInitialDTO> FindEventInitial(int id)
        {

            var result = new ReturnDTO<EventInitialDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                
                var item = _repository.FindInitialEvent(x => x.IdEvents == id && x.IdEventsNavigation.Active == true);

                if (item != null)
                {

                    var initial = new EventInitialDTO();

                    int qty = _repository.CountSeatEventRoom(x => x.IdMovieRoomNavigation.Id == item.Id).Count();

                    initial.IdEvent = item.Id;
                    initial.IdCategory = item.IdEventsNavigation.IdCategory;
                    initial.IdRoom = item.IdRoom;
                    initial.NameRoom = item.IdRoomNavigation.Name;
                    initial.RemainingSeat = item.IdRoomNavigation.MaxSeats - qty;
                    initial.NameCategory = item.IdEventsNavigation.IdCategoryNavigation.Description;
                    initial.NameEvent = item.IdEventsNavigation.Name;
                    initial.DescriptionEvent = item.IdEventsNavigation.Description;
                    initial.DatePresetion = item.DatePresetion;
                    initial.ActiveEvent = item.IdEventsNavigation.Active;

                    result.Result = initial;

                }

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "FindEventInitial");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<EventDTO>> ListInitialEvent()
        {

            var result = new ReturnDTO<List<EventDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Event>();

                result.Result = mapper.Map<List<EventDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListInitialEvent");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<EventDTO>> ListComingSoon()
        {

            var result = new ReturnDTO<List<EventDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Event>();

                list = _repository.ListComingSoon(x => x.Active == true);

                result.Result = mapper.Map<List<EventDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListComingSoon");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<EventDTO>> ListNowShowing()
        {

            var result = new ReturnDTO<List<EventDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Event>();

                list = _repository.ListNowShowing(x => x.Active == true);

                result.Result = mapper.Map<List<EventDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListNowShowing");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<List<EventDTO>> ListNewOnRise()
        {

            var result = new ReturnDTO<List<EventDTO>>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var list = new List<Event>();

                result.Result = mapper.Map<List<EventDTO>>(list);

            }
            catch (Exception ex)
            {

                this.Erro.Add(ex, "ListNewOnRise");
                result.Error = ex.Message;
                result.Success = false;

            }

            return result;

        }

        public ReturnDTO<EventDTO> Inactivate(int id)
        {

            var result = new ReturnDTO<EventDTO>();

            try
            {

                var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                var @event = new Event();

                @event = _repository.Find(x => x.Id == id);

                if (@event.Id > 0)
                {

                    @event.Active = !@event.Active;

                    this._repository.Update(@event);

                    this._repository.Save();

                }
                else
                {

                    result.Error = "Código do item não encontrado!";
                    result.Success = false;

                }

                result.Result = mapper.Map<EventDTO>(@event);

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
