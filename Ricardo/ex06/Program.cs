using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex06
{
    class Program
    {
        static void Main(string[] args)
        {
            int segundos, minutos, horas, segundosUsuario;

            Console.Write("Digite a quantidade de segundos: ");
            segundosUsuario = Convert.ToInt32(Console.ReadLine());
            horas = segundosUsuario / 3600;
            minutos = segundosUsuario / 60;
            segundos = segundosUsuario % 60;
            Console.WriteLine("{0} hora(s), {1} minuto(s) e {2} segundo(s).",horas, minutos, segundos);
            Console.ReadKey();

        }
    }
}
