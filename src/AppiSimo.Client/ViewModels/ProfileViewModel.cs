namespace AppiSimo.Client.ViewModels
{
    using Model.Auth;
    using NodaTime;
    using System;
    using Profile = Model.Profile;

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

        public LocalDate Birthdate
        {
            get => Entity.BirthDate;
            set => Entity.BirthDate = value;
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

        public string Phone
        {
            get => Entity.Phone;
            set => Entity.Phone = value;
        }

        public decimal Debt => Entity.Debt.Value;

        public ProfileViewModel(Profile profile)
            : base(profile)
        {
        }
    }
}