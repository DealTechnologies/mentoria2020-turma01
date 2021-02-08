using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Locadora.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string EnderecoEmail { get; set; }

        public Email(string enderecoEmail)
        {
            EnderecoEmail = enderecoEmail;
        }

        protected override IEnumerable<object> ObterComponentesParaComparacaoIgualdade()
        {
            yield return EnderecoEmail;
        }

        public bool EhValido()
        {
            Regex rgx = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rgx.IsMatch(EnderecoEmail))
                return true;

            return false;
        }
    }
}
