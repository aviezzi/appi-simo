namespace AppiSimo.Client.Pages.ProfileComponent
{
    using Abstract;
    using Model;
    using System;
    using ViewModels;

    public class ProfileDetailComponent : DetailComponentBase<Profile, ProfileViewModel>
    {
        private protected override Func<Profile, ProfileViewModel> BuildViewModel =>
            profile => new ProfileViewModel(profile);

        public ProfileDetailComponent()
            : base("profiles")
        {
        }
    }
}