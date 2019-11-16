namespace AppiSimo.Client.ViewModels
{
    using Model;
    using NodaTime;
    using System.ComponentModel.DataAnnotations;

    public class DailyRateViewModel : ViewModelBase<DailyRate>
    {
        [Required(ErrorMessage = "È obbligatorio inserire l'ora di inizio validita'.")]
        public LocalTime Start
        {
            get => Entity.Start;
            set => Entity.Start = value;
        }

        [Required(ErrorMessage = "È obbligatorio inserire l'ora di fine validita'.")]
        public LocalTime End
        {
            get => Entity.End;
            set => Entity.End = value;
        }

        [Required(ErrorMessage = "È obbligatorio inserire il prezzo.")]
        public decimal? Price
        {
            get => Entity.Price;
            set => Entity.Price = value ?? 0;
        }

        public DailyRateViewModel(DailyRate entity) : base(entity)
        {
        }
    }
}