namespace AppiSimo.Client.Pages.UserDetail
{
    using Model.Auth;
    using NodaTime;
    using System;

    public class UserDetailViewModel
    {
        public Profile Profile { get; }

        public string Name
        {
            get => Profile.Name;
            set => Profile.Name = value;
        }

        public string Surname
        {
            get => Profile.Surname;
            set => Profile.Surname = value;
        }

        public string Gender
        {
            get => Profile.Gender.ToString();
            set => Profile.Gender = (Gender) Enum.Parse(typeof(Gender), value);
        }

        public LocalDate? Birthdate
        {
            get => Profile.BirthDate == new LocalDate() ? default(LocalDate?) : Profile.BirthDate;
            set => Profile.BirthDate = value ?? new LocalDate();
        }

        public string Address
        {
            get => Profile.Address;
            set => Profile.Address = value;
        }

        public string Email
        {
            get => Profile.Email;
            set => Profile.Name = value;
        }

        public bool IsNew => Profile.Id == Guid.Empty;

        public UserDetailViewModel(Profile profile)
        {
            Profile = profile;
        }
    }
}