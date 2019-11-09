namespace AppiSimo.Client.Abstract
{
    using Model;
    using System;

    public abstract class ViewModelBase<T>
        where T : Entity, new()
    {
        public T Entity { get; set; } = new T();

        public Guid Id => Entity.Id;
        public bool IsNew => Entity.Id == default;
    }
}