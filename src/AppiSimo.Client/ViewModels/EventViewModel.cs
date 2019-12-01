namespace AppiSimo.Client.ViewModels
{
    using Model;
    using NodaTime;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventViewModel : ViewModelBase<Event>
    {
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

        public LightViewModel Light { get; set; }

        public HeatViewModel Heat { get; set; }


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

        public IEnumerable<ProfileEventViewModel> Profiles { get; set; }

        public decimal Price => Entity.ProfileEvents.Sum(pe => pe.Price);

        public EventViewModel(Event entity) : base(entity)
        {
            Light = Entity.Light != null ? new LightViewModel(Entity.Light) : default;
            Heat =  Entity.Heat != null ? new HeatViewModel(Entity.Heat) : default;
            
            Console.WriteLine($"light flag: {Light != default}");
            Console.WriteLine($"light value: {Light?.Type ?? "zero"}");
            Console.WriteLine($"heat flag: {Heat != default}");
            Console.WriteLine($"heat value: {Heat?.Type ?? "zero"}");
            
            Profiles = Entity.ProfileEvents.Select(pe => new ProfileEventViewModel(pe));
        }
    }
}