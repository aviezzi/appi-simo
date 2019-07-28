namespace AppiSimo.Client.Pages.ClubDashboard.Details.CourtDetail
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Model;

    public class CourtViewModel
    {
        public IEnumerable<Light> Lights { get; }
        public IEnumerable<Heat> Heats { get; }
        public Court Court { get; }

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
            Court = court ?? throw new NullReferenceException("Court cannot be null.");
        }

        public bool IsNew => Court.Id == Guid.Empty;

        [Required(ErrorMessage = "È obbligatorio inserire il nome del campo.")]
        public string Name { get => Court.Name ?? string.Empty; set => Court.Name = value; }

        public string Light { get => $"{Court.Light.Id}"; set => Court.Light.Id = Guid.Parse(value); }

        public string Heat { get => $"{Court.Heat.Id}"; set => Court.Heat.Id = Guid.Parse(value); }

        public bool Enable { get => Court.Enabled; set => Court.Enabled = value; }
    }
}