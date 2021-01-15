using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            float salarioMinimo = 1045f, salarioFuncionario, resultado;

            Console.Write("Salário do funcionário: ");
            salarioFuncionario = Convert.ToSingle(Console.ReadLine());
            resultado = salarioFuncionario / salarioMinimo;
            Console.WriteLine("O funcionário recebe {0:N2} salário(s) mínimo(s).", resultado);
            Console.ReadKey();
        }
    }
}
