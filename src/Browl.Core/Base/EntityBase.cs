using System;

namespace Browl.Core.Base
{
    public abstract class EntityBase : IEntityBase, IDeleteEntity, IAuditEntity
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
            //Active = true;
            //CreatedDate = DateTime.Now;
            //UpdatedDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        // public bool Active { get; private set; }


        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase;

            if(ReferenceEquals(this, compareTo))
                return false;
            if(ReferenceEquals(null, compareTo))
                return false;

            return Id.Equals(compareTo.Id);
        }


        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if(ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if(ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

    }
}
