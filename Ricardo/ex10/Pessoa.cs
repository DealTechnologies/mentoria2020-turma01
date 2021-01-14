using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex10
{
    class Pessoa
    {
        private int idade { get; set; }
        private string nome { get; set; }
        private string cpf { get; set; }
        private string rg { get; set; }
        //private int qtdpessoas { get; set; }


        public int obterIdade()
        {
            return idade;
        }

        public string saudacao()
        {
            return $"Olá, {nome}, você tem {idade} anos.";
        }

        public void registrarIdade(int idadepessoa)
        {
            idade = idadepessoa;
        }

        public string obterNome()
        {
            return nome;
        }

        public void registrarNome(string nomepessoa)
        {
            nome = nomepessoa;
        }

        public virtual void qtdPessoas()
        {

        }

        
    }
}
