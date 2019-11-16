namespace AppiSimo.Client.Abstract
{
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Threading.Tasks;
    using ViewModels;

    public abstract class DetailComponentBase<T, TViewModel> : ComponentBase
        where T : Entity, new()
        where TViewModel : ViewModelBase<T>
    {
        readonly string _redirectUri;

        [Parameter] public Guid Key { get; set; }

        [Inject] IGraphQlService<T> Service { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        protected TViewModel ViewModel { get; private set; }
        private protected abstract Func<T, TViewModel> BuildViewModel { get; }

        protected DetailComponentBase(string redirectUri)
        {
            _redirectUri = redirectUri;
        }

        protected override async Task OnParametersSetAsync() =>
            ViewModel = BuildViewModel(Key == default ? new T() : await Service.GetOneAsync(Key));

        protected async Task HandleValidSubmit()
        {
            if (ViewModel.IsNew)
                await Service.CreateAsync(ViewModel.Entity);
            else
                await Service.UpdateAsync(ViewModel.Entity);

            NavigationManager.NavigateTo(_redirectUri);
        }
    }
}