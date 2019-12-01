namespace AppiSimo.Client.Pages.ProfileComponent
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ViewModels;

    public class ProfilesComponent : CollectionComponentBase<Profile, ProfileViewModel>
    {
        [Inject] IGraphQlService<Profile> ProfileService { get; set; }

        public ProfilesComponent() : base("profile")
        {
        }

        private protected override async Task<IEnumerable<ProfileViewModel>> BuildViewModel() =>
            (await ProfileService.GetAllAsync()).Select(profile =>
                new ProfileViewModel(profile));
    }
}