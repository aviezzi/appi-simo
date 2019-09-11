namespace AppiSimo.Client.Pages.ClubDashboard.Details.RateDetail
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AppiSimo.Client.Attributes;
    using AppiSimo.Client.Model;
    using NodaTime;

    public class RateViewModel : IDetailViewModel<Rate>
    {
        public RateViewModel()
            : this(new Rate())
        {
        }

        public RateViewModel(Rate rate)
        {
            Entity = rate ?? throw new NullReferenceException("Rate cannot be null.");
        }

        [Required(ErrorMessage = "È obbligatorio inserire un nome per questa tariffa.")]
        public string Name
        {
            get => Entity.Name;
            set => Entity.Name = value;
        }


        [Required(ErrorMessage = "È obbligatorio inserire la data di inizio validita'.")]
        public LocalDate? StartDate
        {
            get => Entity.Start == new LocalDate() ? default(LocalDate?) : Entity.Start;
            set => Entity.Start = value ?? new LocalDate();
        }

        [Required(ErrorMessage = "È obbligatorio inserire la data di fine validita'.")]
        public LocalDate? EndDate
        {
            get => Entity.End == new LocalDate() ? default(LocalDate?) : Entity.End;
            set => Entity.End = value ?? new LocalDate();
        }
        
        [ListNotEmpty(ErrorMessage = "È obbligatorio inserire almeno una tariffa.")]
        public IEnumerable<DailyRateViewModel> DailyRatesViewModel =>
            Entity.DailyRates.Select(dr => new DailyRateViewModel(dr));

        public Rate Entity { get; }

        public bool IsNew => Entity.Id == Guid.Empty;

        public void AddDailyRate() => Entity.DailyRates.Add(new DailyRate());

        public void RemoveDailyRate(Guid id) =>
            Entity.DailyRates = Entity.DailyRates.Where(dailyRate => dailyRate.Id != id).ToList();
    }
}