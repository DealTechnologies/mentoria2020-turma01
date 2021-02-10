using Flunt.Notifications;
using System;

namespace Locadora.Domain.Entidades
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }
        public DateTime ts { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            ts = DateTime.Now;
        }
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid GetId()
        {
            return Id;
        }
    }
}