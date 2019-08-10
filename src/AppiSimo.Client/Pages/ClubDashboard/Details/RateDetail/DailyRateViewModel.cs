namespace AppiSimo.Client.Pages.ClubDashboard.Details.RateDetail
{
    using System.ComponentModel.DataAnnotations;
    using Model;
    using NodaTime;

    public class DailyRateViewModel : IDetailViewModel<DailyRate>
    {
        public DailyRate Entity { get; }

        public DailyRateViewModel()
            : this(new DailyRate())
        {
        }

        public DailyRateViewModel(DailyRate entity)
        {
            Entity = entity;
        }

        public bool IsNew { get; }

//        [Required(ErrorMessage = "È obbligatorio inserire l'ora di inizio validita'.")]
        public LocalTime Start { get => Entity.Start; set => Entity.Start = value; }

        [Required(ErrorMessage = "È obbligatorio inserire l'ora di fine validita'.")]
        public LocalTime End { get => Entity.End; set => Entity.End = value; }

        [Required(ErrorMessage = "È obbligatorio inserire il prezzo.")]
        public decimal Price { get => Entity.Price; set => Entity.Price = value; }
    }
}