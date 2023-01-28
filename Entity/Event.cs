using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Event
    {
        public Event()
        {
            Assessments = new HashSet<Assessment>();
            EventsRooms = new HashSet<EventsRoom>();
            ImagesEvents = new HashSet<ImagesEvent>();
            InitialEvents = new HashSet<InitialEvent>();
            News = new HashSet<News>();
            VideosEvents = new HashSet<VideosEvent>();
        }

        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Active { get; set; }
        public string? UrlPhoto { get; set; }

        public virtual Category IdCategoryNavigation { get; set; } = null!;
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<EventsRoom> EventsRooms { get; set; }
        public virtual ICollection<ImagesEvent> ImagesEvents { get; set; }
        public virtual ICollection<InitialEvent> InitialEvents { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<VideosEvent> VideosEvents { get; set; }
    }
}
