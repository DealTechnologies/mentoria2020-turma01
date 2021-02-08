using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Locadora.Domain.ValueObjects
{
    public class Cep : ValueObject
    {
        public string NumeroCep { get; set; }

        public Cep(string numeroCep)
        {
            NumeroCep = numeroCep;
        }

        protected override IEnumerable<object> ObterComponentesParaComparacaoIgualdade()
        {
            yield return NumeroCep;
        }

        public bool EhValido()
        {
            Regex rgx = new Regex(@"^\d{5}-\d{3}$");

            if (rgx.IsMatch(NumeroCep))
                return true;

            return false;
        }
    }
}
