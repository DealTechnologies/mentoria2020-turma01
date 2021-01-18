using System;

namespace Aula08_E01
{
	class Program
	{
		static void MediaNumeros(double n1, double n2, double n3){
			double media;
			media = (n1+n2+n3)/3;
			Console.WriteLine("\nA média é: {0}", media);			
		}
		
		public static void Main(string[] args)
		{
			double n1, n2, n3;
				
			Console.Write("Digite o primeiro número:"); n1 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Digite o segundo número :"); n2 = Convert.ToDouble(Console.ReadLine());
			Console.Write("Digite o terceiro número:"); n3 = Convert.ToDouble(Console.ReadLine());
			
			MediaNumeros(n1, n2, n3);			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}