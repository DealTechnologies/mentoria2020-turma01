using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Domain.ValueObjects
{
    public abstract class ValueObject
    {
        protected static bool OperadorIgual(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool OperadorDiferente(ValueObject left, ValueObject right)
        {
            return !(OperadorIgual(left, right));
        }

        protected abstract IEnumerable<object> ObterComponentesParaComparacaoIgualdade();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.ObterComponentesParaComparacaoIgualdade().SequenceEqual(other.ObterComponentesParaComparacaoIgualdade());
        }

        public override int GetHashCode()
        {
            return ObterComponentesParaComparacaoIgualdade()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
