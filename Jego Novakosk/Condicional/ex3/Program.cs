using System;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Digite um numero");
            n = Convert.ToInt32(Console.ReadLine());

            if ((n %2) == 0 && (n %3) == 0)
            {
                Console.WriteLine("\n {0} divisivel por 2 e 3", n);
            }else if((n%2) == 0)
            {
                Console.WriteLine("\n {0} divisivel por 2 ", n);
            }
            else
            {
                Console.WriteLine("\n {0} não e divisivel por 2", n);
            }
        }
    }
}
