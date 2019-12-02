namespace AppiSimo.Client.ViewModels
{
    using Model;
    using NodaTime;
    using System.Collections.Generic;
    using System.Linq;

    public class EventViewModel : ViewModelBase<Event>
    {
        public IEnumerable<CourtViewModel> Courts { get; set; }

        public LocalDate Date
        {
            get => Entity.Date;
            set => Entity.Date = value;
        }

        public LocalTime Start
        {
            get => Entity.Start;
            set => Entity.Start = value;
        }

        public LocalTime End
        {
            get => Entity.End;
            set => Entity.End = value;
        }

        public CourtViewModel Court { get; }

        public double LightDuration
        {
            get => Entity.LightDuration ?? default;
            set => Entity.LightDuration = value;
        }

        public double HeatDuration
        {
            get => Entity.HeatDuration ?? default;
            set => Entity.HeatDuration = value;
        }
        
        public IEnumerable<ProfileEventViewModel> ProfileEvents { get; set; }

        public decimal Price => Entity.ProfileEvents.Sum(pe => pe.Price);

        public EventViewModel(Event @event)
            : this(@event, new List<Court>())
        {
        }

        public EventViewModel(Event @event, IEnumerable<Court> courts)
            : base(@event)
        {
            Court = new CourtViewModel(Entity.Court);
            Courts = courts.Select(court => new CourtViewModel(court));

            ProfileEvents = Entity.ProfileEvents.Select(pe => new ProfileEventViewModel(pe));
        }
    }
}