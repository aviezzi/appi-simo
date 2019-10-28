namespace AppiSimo.Client.Pages.ClubDashboard.Details.CourtDetail
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abstract;
    using Model;

    public class CourtViewModel : IDetailViewModel<Court>
    {
        public CourtViewModel()
            : this(new List<Light>(), new List<Heat>())
        {
        }

        public CourtViewModel(IEnumerable<Light> lights, IEnumerable<Heat> heats)
            : this(lights, heats, new Court())
        {
        }

        public CourtViewModel(IEnumerable<Light> lights, IEnumerable<Heat> heats, Court court)
        {
            Lights = lights ?? throw new NullReferenceException("Lights cannot be null.");
            Heats = heats ?? throw new NullReferenceException("Heats cannot be null.");
            Entity = court ?? throw new NullReferenceException("Court cannot be null.");
        }

        public IEnumerable<Light> Lights { get; }
        public IEnumerable<Heat> Heats { get; }

        [Required(ErrorMessage = "È obbligatorio inserire il nome del campo.")]
        public string Name
        {
            get => Entity.Name ?? string.Empty;
            set => Entity.Name = value;
        }

        public string Light
        {
            get => $"{Entity.Light.Id}";
            set => Entity.Light.Id = Guid.Parse(value);
        }

        public string Heat
        {
            get => $"{Entity.Heat.Id}";
            set => Entity.Heat.Id = Guid.Parse(value);
        }

        public bool Enable
        {
            get => Entity.Enabled;
            set => Entity.Enabled = value;
        }

        public Court Entity { get; }

        public bool IsNew => Entity.Id == Guid.Empty;
    }
}