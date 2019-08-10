namespace AppiSimo.Client.Pages.ClubDashboard.Details.RateDetail
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Model;
    using NodaTime;

    public class RateViewModel : IDetailViewModel<Rate>
    {
        public IEnumerable<Court> Courts { get; }
        public Rate Entity { get; }

        public RateViewModel()
            : this(new List<Court>())
        {
        }

        public RateViewModel(IEnumerable<Court> courts)
            : this(courts, new Rate())
        {
        }

        public RateViewModel(IEnumerable<Court> courts, Rate rate)
        {
            Courts = courts ?? throw new NullReferenceException("Courts cannot be null.");
            Entity = rate ?? throw new NullReferenceException("Rate cannot be null.");
        }

        public bool IsNew => Entity.Id == Guid.Empty;

        [Required(ErrorMessage = "È obbligatorio inserire la data di inizio validita'.")]
        public LocalDate StartDate { get => Entity.Start; set => Entity.Start = value; }

        [Required(ErrorMessage = "È obbligatorio inserire la data di fine validita'.")]
        public LocalDate EndDate { get => Entity.End; set => Entity.End = value; }

        public IEnumerable<DailyRateViewModel> DailyRatesViewModel => Entity.DailyRates.Select(dr => new DailyRateViewModel(dr)).ToList();

        public void AddDailyRate() => Entity.DailyRates.Add(new DailyRate());

        public void RemoveDailyRate(Guid id) => Entity.DailyRates = Entity.DailyRates.Where(dailyRate => dailyRate.Id != id).ToList();
    }
}