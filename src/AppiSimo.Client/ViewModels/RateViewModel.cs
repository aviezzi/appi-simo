namespace AppiSimo.Client.ViewModels
{
    using Attributes;
    using Model;
    using NodaTime;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class RateViewModel : ViewModelBase<Rate>
    {
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
            Entity.DailyRates.Select(dr => new DailyRateViewModel
            {
                Entity = dr
            });

        public RateViewModel()
            : base(typeof(RateViewModel))
        {
        }

        public void AddDailyRate() => Entity.DailyRates.Add(new DailyRate());

        public void RemoveDailyRate(Guid id) =>
            Entity.DailyRates = Entity.DailyRates.Where(dailyRate => dailyRate.Id != id).ToList();
    }
}