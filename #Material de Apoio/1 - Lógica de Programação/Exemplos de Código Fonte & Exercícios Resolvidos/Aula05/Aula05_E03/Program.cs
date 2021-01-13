using System;

namespace Aula05_E03
{
	class Program
	{
		public static void Main(string[] args)
		{
			double lado1, lado2, baset, altura, area, perimetro;
			
			Console.WriteLine("Informe as medidas do triângulo\n");
			
			Console.Write("Informe o valor do primeiro lado: "); lado1 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Informe o valor do segundo lado : "); lado2 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Informe o valor da base         : "); baset = Convert.ToDouble(Console.ReadLine());
			Console.Write("Informe o valor da altura       : "); altura = Convert.ToDouble(Console.ReadLine());
			
			area = (baset * altura) /2;
			perimetro = lado1 + lado2 + baset;
			
			
			Console.WriteLine("\nA área do triângulo é     : {0}", area);
			Console.WriteLine("O perímetro do triângulo é: {0}", perimetro);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}