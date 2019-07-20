namespace AppiSimo.Client.Pages.ClubSettings.ViewModels
{
    using System;
    using Model;

    public class EquipmentViewModel<T>
        where T : Entity, new()
    {
        public T Equipment { get; }

        public EquipmentViewModel(T equipment)
        {
            Equipment = equipment ?? new T();
        }

        public bool IsNew => Equipment?.Id == Guid.Empty;
    }
}