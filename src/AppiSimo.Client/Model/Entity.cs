namespace AppiSimo.Client.Model
{
    using Abstract;
    using System;

    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }

        bool Equals(IEntity other) => Id.Equals(other.Id);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((Entity) obj);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Entity left, Entity right) => Equals(left, right);

        public static bool operator !=(Entity left, Entity right) => !Equals(left, right);
    }
}