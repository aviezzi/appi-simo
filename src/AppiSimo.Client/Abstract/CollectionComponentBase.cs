namespace AppiSimo.Client.Abstract
{
    using Microsoft.AspNetCore.Components;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels;

    public abstract class CollectionComponentBase<T, TViewModel> : ComponentBase
        where T : Entity, new()
        where TViewModel : ViewModelBase<T>
    {
        readonly string _uri;
        [Inject] NavigationManager NavigationManager { get; set; }

        protected IEnumerable<TViewModel> ViewModel { get; private set; }

        protected CollectionComponentBase(string uri)
        {
            _uri = uri;
        }

        private protected abstract Task<IEnumerable<TViewModel>> BuildViewModel();

        protected override async Task OnParametersSetAsync() => ViewModel = await BuildViewModel();

        protected void GoToCreate() => NavigationManager.NavigateTo($"{_uri}/create");

        protected void GoToEdit(Guid key) => NavigationManager.NavigateTo($"{_uri}/edit/{key}");
    }
}