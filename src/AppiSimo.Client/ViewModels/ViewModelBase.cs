namespace AppiSimo.Client.ViewModels
{
    using Model;
    using System;

    public abstract class ViewModelBase<T>
        where T : Entity, new()
    {
        readonly Type _type;
        T _entity = new T();

        public T Entity
        {
            get => _entity;
            set => _entity = value == null
                ? throw new ArgumentNullException($"View Model Base. Child: {_type}")
                : value;
        }

        public Guid Id => Entity.Id;
        public bool IsNew => Entity.Id == default;

        protected ViewModelBase(Type type)
        {
            _type = type;
        }
    }
}