using System;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*double raio;
            double area;

            Console.WriteLine("Informe o raio do circulo: ");
            raio = Convert.ToDouble(Console.ReadLine());

            area = 3.14159 * raio * raio;

            Console.WriteLine("Area do circulo: {0}", area);
            Console.ReadKey();*/

            //exercicio 1 

            /* double fahrenheit;
             double celsius;

             Console.WriteLine("Digite a temperatura  em Celsius:");
             celsius = Convert.ToDouble(Console.ReadLine());

             fahrenheit = (9 * celsius + 160) / 5;

             Console.WriteLine("Valor em Fahrenheit: {0}", fahrenheit);
             Console.WriteLine("********************************************************************");
            */

            // exercicio 2

            /*
            float salarioMin;
            float salario;
            float quantidadeDeSalarioMin;

            Console.WriteLine("Digite o salario minino: ");
            salarioMin = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Digite o salario do funcionario: ");
            salario = Convert.ToSingle(Console.ReadLine());
            quantidadeDeSalarioMin = salario / salarioMin;
            Console.WriteLine("O funcionario ganha {0} salarios Minimos", quantidadeDeSalarioMin);
            Console.WriteLine("*********************************************************************");
            */

            //exercicio 3

            /*
            float ladoA;
            float ladoB;
            float ladoC;
            float perimetro;

            Console.WriteLine("Digite o valor do lado A :");
            ladoA = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Digite o valor do lado B :");
            ladoB = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Digite o valor do lado C :");
            ladoC = Convert.ToSingle(Console.ReadLine());

            perimetro = ladoA + ladoB + ladoC;

            Console.WriteLine("O perimetro do triangulo é {0}", perimetro);
            Console.WriteLine("*********************************************************************");
            */

            // exercicio 4
            /*
            int numero;


            Console.WriteLine("Digite um numero:");
            numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("O seu numero e {0} seu antecessoer e {1} e sucessor {2}", numero, numero - 1, numero + 1);
            Console.WriteLine("*********************************************************************");
            */

            // exercicio 5
            /*
            float valorProduto;
            float desconto = 25;
            float valorFinal;

            Console.WriteLine("Digite o  valor do produto:");
            valorProduto = Convert.ToSingle(Console.ReadLine());
            valorFinal = valorProduto - (valorProduto * (desconto / 100));
            Console.WriteLine("valor com desconto - {0} ", valorFinal);
            Console.WriteLine("*********************************************************************");
            */

            // exercico 6 
            /*
            float hora;
            int horaA;
            float min;
            int seg;
            int minA;
            float valorSeg;

            Console.WriteLine("Digite o valor em segundos: ");
            valorSeg = Convert.ToSingle(Console.ReadLine());
            min = valorSeg / 60;
            minA = (int)min;
            seg = (int)((min - minA) * 60);
            hora = (float)minA / 60;
            horaA = (int)hora;
            minA = (int)((hora - horaA) * 60);

            Console.WriteLine("Em {0} tem {1} horas e {2} minutos e {3} segundos ", valorSeg, horaA, minA, seg);

            */
        }
    }
}
