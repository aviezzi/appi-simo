namespace AppiSimo.Client.ViewModels
{
    using Model;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class CourtViewModel : ViewModelBase<Court>
    {
        public IEnumerable<LightViewModel> Lights { get; }
        public IEnumerable<HeatViewModel> Heats { get; }

        [Required(ErrorMessage = "È obbligatorio inserire il nome del campo.")]
        public string Name
        {
            get => Entity.Name ?? string.Empty;
            set => Entity.Name = value;
        }

        public LightViewModel Light { get; }
        public HeatViewModel Heat { get; }

        public bool Enabled
        {
            get => Entity.Enabled;
            set => Entity.Enabled = value;
        }

        public CourtViewModel(Court court)
            : this(court, new List<Light>(), new List<Heat>())
        {
        }

        public CourtViewModel(Court court, IEnumerable<Light> lights, IEnumerable<Heat> heats)
            : base(court)
        {
            Light = Entity.Light != default ? new LightViewModel(Entity.Light) : default;
            Lights = lights.Select(light => new LightViewModel(light));

            Heat = Entity.Heat != default ? new HeatViewModel(Entity.Heat) : default;
            Heats = heats.Select(heat => new HeatViewModel(heat));
        }
    }
}