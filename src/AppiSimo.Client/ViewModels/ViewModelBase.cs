namespace AppiSimo.Client.ViewModels
{
    using Model;
    using System;

    public abstract class ViewModelBase<T>
        where T : Entity, new()
    {
        public T Entity { get; }

        public Guid Id => Entity.Id;
        public bool IsNew => Entity.Id == default;

        protected ViewModelBase(T entity)
        {
            Entity = entity;
        }
    }
}