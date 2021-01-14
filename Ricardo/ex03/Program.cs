using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;

            Console.Write("Digite um número para ver seu sucessor e antecessor: ");
            numero = Convert.ToInt32(Console.ReadLine());
            int sucessor = numero + 1;
            int antecessor = numero - 1;

            Console.WriteLine("O sucessor de {0} é {1} e o antecessor é {2}.", numero, sucessor, antecessor);
            Console.ReadKey();

        }
    }
}
