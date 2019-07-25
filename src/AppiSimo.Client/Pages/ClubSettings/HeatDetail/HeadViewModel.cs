namespace AppiSimo.Client.Pages.ClubSettings.HeatDetail
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Model;

    public class HeatViewModel
    {
        public Heat Heat { get; }

        public HeatViewModel()
            : this(new Heat())
        {
        }

        public HeatViewModel(Heat heat)
        {
            Heat = heat ?? throw new NullReferenceException("Heat cannot be null.");
        }

        public bool IsNew => Heat.Id == Guid.Empty;

        [Required(ErrorMessage = "È obbligatorio inserire la tipologia del riscladamento.")]
        public string Type { get => Heat.HeatType?? string.Empty; set => Heat.HeatType = value; }
        
        [Required(ErrorMessage = "È obbligatorio inserire un prezzo.")]
        public decimal Price { get => Heat.Price; set => Heat.Price = value; }

        public bool Enable { get => Heat.Enabled; set => Heat.Enabled = value; }
    }
}