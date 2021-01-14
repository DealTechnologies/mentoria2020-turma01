using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            float celsius, farenheit;

            Console.Write("Digite a temperatura em graus celsius: ");
            celsius = Convert.ToSingle(Console.ReadLine());
            farenheit = (9 * celsius + 160) / 5;
            Console.WriteLine("{0} Graus Celsius equivalem a {1} Graus Farenheit.", celsius, farenheit);
            Console.ReadKey();
        }
    }
}
