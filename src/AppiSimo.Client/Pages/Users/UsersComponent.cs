namespace AppiSimo.Client.Pages.Users
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Model.Auth;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsersComponent : ComponentBase
    {
        [Inject] IGraphQlService<Profile> ProfileService { get; set; }

        protected ICollection<Profile> Profiles { get; private set; }

        protected override async Task OnInitializedAsync() => 
            Profiles = await ProfileService.GetAllAsync();
    }
}