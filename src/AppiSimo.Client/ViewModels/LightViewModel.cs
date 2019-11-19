namespace AppiSimo.Client.ViewModels
{
    using Model;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LightViewModel : ViewModelBase<Light>
    {
        [Required(ErrorMessage = "È obbligatorio inserire la tipologia della luce.")]
        public string Type
        {
            get => Entity.LightType ?? string.Empty;
            set => Entity.LightType = value;
        }

        [Required(ErrorMessage = "È obbligatorio inserire un prezzo.")]
        public decimal? Price
        {
            get => Entity.Price;
            set => Entity.Price = value ?? 0;
        }

        public bool Enabled
        {
            get => Entity.Enabled;
            set => Entity.Enabled = value;
        }


        public LightViewModel(Light entity) : base(entity)
        {
        }
    }
}