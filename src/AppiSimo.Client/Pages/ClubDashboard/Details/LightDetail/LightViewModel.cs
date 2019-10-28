namespace AppiSimo.Client.Pages.ClubDashboard.Details.LightDetail
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Abstract;
    using Model;

    public class LightViewModel : IDetailViewModel<Light>
    {
        public LightViewModel()
            : this(new Light())
        {
        }

        public LightViewModel(Light light)
        {
            Entity = light ?? throw new NullReferenceException("Light cannot be null.");
        }

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

        public bool Enable
        {
            get => Entity.Enabled;
            set => Entity.Enabled = value;
        }

        public Light Entity { get; }

        public bool IsNew => Entity.Id == Guid.Empty;
    }
}