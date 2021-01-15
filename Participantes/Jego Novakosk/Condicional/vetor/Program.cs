using System;

namespace vetor
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int[] n = new int[10];

            for(i=0; i<10; i++)
            {
                n[i] = 0;
            }
            Console.WriteLine("Elemento    Valor");
            for(i=0; i<10; i++)
            {
                Console.WriteLine("{0,8} {1,8}\n",i , n[i]);
            }
        }
    }
}
