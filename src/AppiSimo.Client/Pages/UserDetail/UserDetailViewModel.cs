namespace AppiSimo.Client.Pages.UserDetail
{
    using Abstract;
    using Model.Auth;
    using NodaTime;
    using System;

    public class UserDetailViewModel
    {
        readonly ITypeConverter<LocalDate> _converter;
        public Profile Profile { get; }

        public string Name
        {
            get => Profile.Name;
            set => Profile.Name = value;
        }

        public string Surname
        {
            get => Profile.FamilyName;
            set => Profile.FamilyName = value;
        }

        public string Gender
        {
            get => Profile.Gender.ToString();
            set => Profile.Gender = (Gender) Enum.Parse(typeof(Gender), value);
        }

        public string Email
        {
            get => Profile.Email;
            set => Profile.Name = value;
        }
        
        public string Birthdate
        {
            get => _converter.FormatValueAsString(Profile.BirthDate);
            set
            {
                var success = _converter.TryParseValueFromString(value, out var result);
                Profile.BirthDate = success ? result : throw new InvalidCastException("Profile_Birthdate");
            }
        }

        public bool IsNew => Profile.Id == Guid.Empty;

        public UserDetailViewModel(Profile profile, ITypeConverter<LocalDate> converter)
        {
            _converter = converter;
            Profile = profile;
        }
    }
}