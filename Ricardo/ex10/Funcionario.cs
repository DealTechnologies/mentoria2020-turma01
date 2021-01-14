using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex10
{
    class Funcionario : Pessoa
    {
        private double valorsalario { get; set; }
        private double salarioBruto { get; set; }
        private double valoraumento { get; set; }

        private void calcularSalario()
        {
            if (valoraumento == 0.0)
            {
                valoraumento = 50.0;
            }
            salarioBruto = valorsalario + valoraumento;
        }

        public void insereSalario(double salarioFuncionario)
        {
            valorsalario = salarioFuncionario;
        }

        public string obterSalario()
        {
            calcularSalario();
            return $"O novo salário do funcionário é R${salarioBruto.ToString()}.";
        }

        public void insereAumento(double aumento=100.0)
        {
            valoraumento = aumento;
        }

        public override void qtdPessoas()
        {
            Console.WriteLine("Contando funcionarios..");
            base.qtdPessoas();
        }
    }
}
