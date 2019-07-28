namespace AppiSimo.Client.Pages.ClubDashboard.Details.HeatDetail
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Model;

    public class HeatViewModel : IDetailViewModel<Heat>
    {
        public Heat Entity { get; }

        public HeatViewModel()
            : this(new Heat())
        {
        }

        public HeatViewModel(Heat heat)
        {
            Entity = heat ?? throw new NullReferenceException("Heat cannot be null.");
        }

        public bool IsNew => Entity.Id == Guid.Empty;

        [Required(ErrorMessage = "È obbligatorio inserire la tipologia del riscladamento.")]
        public string Type { get => Entity.HeatType ?? string.Empty; set => Entity.HeatType = value; }

        [Required(ErrorMessage = "È obbligatorio inserire un prezzo.")]
        public decimal Price { get => Entity.Price; set => Entity.Price = value; }

        public bool Enable { get => Entity.Enabled; set => Entity.Enabled = value; }
    }
}