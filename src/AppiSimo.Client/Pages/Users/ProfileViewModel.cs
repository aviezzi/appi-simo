namespace AppiSimo.Client.Pages.Users
{
    using Abstract;
    using Model.Auth;
    using NodaTime;
    using System;

    public class ProfileViewModel : ViewModelBase<Profile>
    {
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

        public string FormattedBirthDate() => Converters.LocalDate.FormatValueAsString(Entity.BirthDate);
    }
}