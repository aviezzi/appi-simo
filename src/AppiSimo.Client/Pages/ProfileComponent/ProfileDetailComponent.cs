namespace AppiSimo.Client.Pages.ProfileComponent
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model.Auth;
    using NodaTime;
    using System;
    using ViewModels;

    public class ProfileDetailComponent : DetailComponentBase<Profile, ProfileViewModel>
    {
        [Inject] ITypeConverter<LocalDate> LocalDateConverter { get; set; }

        protected override Func<Profile, ProfileViewModel> BuildViewModel =>
            profile => new ProfileViewModel(LocalDateConverter)
            {
                Entity = profile
            };

        public ProfileDetailComponent()
            : base("profiles")
        {
        }
    }
}