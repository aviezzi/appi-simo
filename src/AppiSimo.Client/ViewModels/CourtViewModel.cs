namespace AppiSimo.Client.ViewModels
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CourtViewModel : ViewModelBase<Court>
    {
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

        public CourtViewModel(Court court, IEnumerable<Light> lights, IEnumerable<Heat> heats)
            : base(court)
        {
            Lights = lights ?? throw new NullReferenceException("Lights cannot be null.");
            Heats = heats ?? throw new NullReferenceException("Heats cannot be null.");
        }
    }
}