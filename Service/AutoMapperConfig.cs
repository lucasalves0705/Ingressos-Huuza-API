using AutoMapper;
using DataTransferObject;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AutoMapperConfig : Profile    
    {

        public static MapperConfiguration RegisterMapper()
        {

            var config = new MapperConfiguration(f =>
            {

                f.CreateMap<User, UserDTO>();
                f.CreateMap<UserDTO, User>();

                f.CreateMap<Employeer, EmployeerDTO>();
                f.CreateMap<EmployeerDTO, Employeer>();

                f.CreateMap<Departament, DepartamentDTO>();
                f.CreateMap<DepartamentDTO, Departament>();

                f.CreateMap<Event, EventDTO>();
                f.CreateMap<EventDTO, Event>();

                f.CreateMap<Category, CategoryDTO>();
                f.CreateMap<CategoryDTO, Category>();

                f.CreateMap<Login, LoginDTO>();
                f.CreateMap<LoginDTO, Login>();

                f.CreateMap<Permission, PermissionDTO>();
                f.CreateMap<PermissionDTO, Permission>();

                f.CreateMap<Room, RoomDTO>();
                f.CreateMap<RoomDTO, Room>();

                f.CreateMap<EventsRoom, EventsRoomSaveDTO>();
                f.CreateMap<EventsRoomSaveDTO, EventsRoom>();

                f.CreateMap<EventsRoom, EventsRoomDTO>();
                f.CreateMap<EventsRoomDTO, EventsRoom>();

            });

            return config;

        }

    }
}
