namespace AppiSimo.Client.ViewModels
{
    using Abstract;
    using Model.Auth;
    using NodaTime;
    using System;

    public class ProfileViewModel : ViewModelBase<Profile>
    {
        readonly ITypeConverter<LocalDate> _converter;

        public string Name
        {
            get => Entity.Name;
            set => Entity.Name = value;
        }

        public string Surname
        {
            get => Entity.Surname;
            set => Entity.Surname = value;
        }

        public string Gender
        {
            get => Entity.Gender.ToString();
            set => Entity.Gender = (Gender) Enum.Parse(typeof(Gender), value);
        }

        public LocalDate? Birthdate
        {
            get => Entity.BirthDate == new LocalDate() ? default(LocalDate?) : Entity.BirthDate;
            set => Entity.BirthDate = value ?? new LocalDate();
        }

        public string Address
        {
            get => Entity.Address;
            set => Entity.Address = value;
        }

        public string Email
        {
            get => Entity.Email;
            set => Entity.Email = value;
        }

        public ProfileViewModel(ITypeConverter<LocalDate> converter)
            : base(typeof(ProfileViewModel))
        {
            _converter = converter;
            Console.WriteLine(_converter.Pattern);
        }

        public string FormattedBirthDate() =>
            _converter.FormatValueAsString(Entity.BirthDate);
    }
}