using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Locadora.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Cep Cep { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public bool Principal { get; private set; }

        public Endereco(string cep, string rua, int numero, string complemento, string cidade, string estado, string pais, bool principal = true)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Principal = principal;

            AtribuirCep(cep);
        }

        protected override IEnumerable<object> ObterComponentesParaComparacaoIgualdade()
        {
            yield return Cep;
            yield return Rua;
            yield return Numero;
            yield return Complemento;
            yield return Cidade;
            yield return Estado;
            yield return Pais;
            yield return Principal;
        }

        public bool EhValido()
        {
            //if (!Cep.EhValido())
            //    return false;

            return true;
        }

        public void AtribuirCep(string numeroCep)
        {
            var cep = new Cep(numeroCep);
            if (!cep.EhValido())
                return;

            Cep = cep;
        }

        public string ObterEnderecoCompleto()
        {
            return $"{Rua} {Numero.ToString()} {Complemento} {Cidade}/{Estado} - {Cep.NumeroCep} {Pais}";
        }
    }
}
