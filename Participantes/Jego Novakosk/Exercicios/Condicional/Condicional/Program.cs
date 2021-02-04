using System;

namespace Condicional
{
    class Program
    {
        static void Main(string[] args)
        {

            int n1, n2; 
            Console.WriteLine("Informar 2 valore:");
            n1 = Convert.ToInt32(Console.ReadLine());
            n2 = Convert.ToInt32(Console.ReadLine());

            if (n1 > n2)
            {
                Console.WriteLine("primeiro e maior");
            }else if (n1 < n2)
            {
                Console.WriteLine("O primeiro  e menor");
            }else
            {
                Console.WriteLine("Sao Iguais ");
            }
        }
    }
}
