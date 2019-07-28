namespace AppiSimo.Client.Pages.ClubDashboard.Details.LightDetail
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Model;

    public class LightViewModel : IDetailViewModel<Light>
    {
        public Light Entity { get; }

        public LightViewModel()
            : this(new Light())
        {
        }

        public LightViewModel(Light light)
        {
            Entity = light ?? throw new NullReferenceException("Light cannot be null.");
        }

        public bool IsNew => Entity.Id == Guid.Empty;

        [Required(ErrorMessage = "È obbligatorio inserire la tipologia della luce.")]
        public string Type { get => Entity.LightType ?? string.Empty; set => Entity.LightType = value; }

        [Required(ErrorMessage = "È obbligatorio inserire un prezzo.")]
        public decimal Price { get => Entity.Price; set => Entity.Price = value; }

        public bool Enable { get => Entity.Enabled; set => Entity.Enabled = value; }
    }
}