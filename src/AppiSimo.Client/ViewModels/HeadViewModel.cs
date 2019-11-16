namespace AppiSimo.Client.ViewModels
{
    using Model;
    using System.ComponentModel.DataAnnotations;

    public class HeatViewModel : ViewModelBase<Heat>
    {
        [Required(ErrorMessage = "È obbligatorio inserire la tipologia del riscladamento.")]
        public string Type
        {
            get => Entity.HeatType ?? string.Empty;
            set => Entity.HeatType = value;
        }

        [Required(ErrorMessage = "È obbligatorio inserire un prezzo.")]
        public decimal? Price
        {
            get => Entity.Price;
            set => Entity.Price = value ?? 0;
        }

        public bool Enable
        {
            get => Entity.Enabled;
            set => Entity.Enabled = value;
        }

        public HeatViewModel(Heat entity) : base(entity)
        {
        }
    }
}