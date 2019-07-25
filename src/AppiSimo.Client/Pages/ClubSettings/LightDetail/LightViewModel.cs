namespace AppiSimo.Client.Pages.ClubSettings.LightDetail
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Model;

    public class LightViewModel
    {
        public Light Light { get; }

        public LightViewModel()
            : this(new Light())
        {
        }

        public LightViewModel(Light light)
        {
            Light = light ?? throw new NullReferenceException("Light cannot be null.");
        }

        public bool IsNew => Light.Id == Guid.Empty;

        [Required(ErrorMessage = "È obbligatorio inserire la tipologia della luce.")]
        public string Type { get => Light.LightType ?? string.Empty; set => Light.LightType = value; }
        
        [Required(ErrorMessage = "È obbligatorio inserire un prezzo.")]
        public decimal Price { get => Light.Price; set => Light.Price = value; }

        public bool Enable { get => Light.Enabled; set => Light.Enabled = value; }
    }
}