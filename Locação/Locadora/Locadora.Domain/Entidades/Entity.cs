using System;

namespace Locadora.Domain.Entidades
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        protected Entity(Guid id)
        {
            if (Guid.Empty == id)
                Id = Guid.NewGuid();
            else
                Id = id;
        }

        public Guid GetId()
        {
            return Id;
        }
    }
}
