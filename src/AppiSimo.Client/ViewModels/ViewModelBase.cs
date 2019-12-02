namespace AppiSimo.Client.ViewModels
{
    using Model;
    using System;

    public abstract class ViewModelBase<T>
        where T : Entity, new()
    {
        public T Entity { get; }

        public bool IsNew => Entity.Id == default;

        public string Id
        {
            get => $"{Entity.Id}";
            set => Entity.Id = Guid.Parse(value);
        }

        protected ViewModelBase(T entity)
        {
            Entity = entity;
        }
    }
}