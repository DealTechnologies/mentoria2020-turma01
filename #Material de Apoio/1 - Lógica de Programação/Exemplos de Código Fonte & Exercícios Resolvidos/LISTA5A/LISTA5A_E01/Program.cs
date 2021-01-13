using System;

namespace LISTA5A_E01
{
	class Program
	{
		public static void Main(string[] args)
		{			
			double imc, massa, altura;
			
			Console.Write("Digite seu peso: ");
			massa = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Digite sua altura: ");
			altura = Convert.ToDouble(Console.ReadLine());
			
			imc = massa / (altura*altura);
			
			Console.WriteLine("\nO IMC é: {0:N2}", imc);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}