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
        public LocalDate StartDate
        {
            get => Entity.Start;
            set => Entity.Start = value;
        }

        [Required(ErrorMessage = "È obbligatorio inserire la data di fine validita'.")]
        public LocalDate EndDate
        {
            get => Entity.End;
            set => Entity.End = value;
        }

        [ListNotEmpty(ErrorMessage = "È obbligatorio inserire almeno una tariffa.")]
        public IEnumerable<DailyRateViewModel> DailyRates =>
            Entity.DailyRates.Select(dr => new DailyRateViewModel(dr));

        public RateViewModel(Rate entity) : base(entity)
        {
        }

        public void AddDailyRate() => Entity.DailyRates.Add(new DailyRate());

        public void RemoveDailyRate(Guid id) =>
            Entity.DailyRates = Entity.DailyRates.Where(dailyRate => dailyRate.Id != id).ToList();
    }
}