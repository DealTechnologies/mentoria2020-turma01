using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex10
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Pessoa objpessoa = new Funcionario();
            objpessoa.registrarIdade(23);
            objpessoa.registrarNome("Ricardo");
            objpessoa.qtdPessoas();
            Console.WriteLine(objpessoa.saudacao());

            Pessoa objcliente = new Cliente();
            //Console.WriteLine(objcliente.qtdPessoas());

            


            Pessoa objpessoa2 = new Pessoa();
            objpessoa2.registrarIdade(52);
            objpessoa2.registrarNome("Marcio");
            Console.WriteLine(objpessoa2.saudacao());

            Funcionario objfuncionario = new Funcionario();
            objfuncionario.insereSalario(5000.0);
            // objfuncionario.insereAumento();
            Console.WriteLine(objfuncionario.obterSalario());

            Pessoa[] vetPessoa = new Pessoa[2];
            vetPessoa[0] = objfuncionario;
            vetPessoa[1] = objcliente;

            contarPessoas(vetPessoa);




            Console.ReadKey();

        }
       
        public static void contarPessoas(Pessoa[] objpessoa)
        {
            
            foreach (var itemPessoa in objpessoa)
            {
                itemPessoa.qtdPessoas();
            }
        }
    }
}
