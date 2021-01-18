using System;

namespace Aula09_E04
{
	class Program
	{	
		static double Calcular(double a, double b){
			double resultado;
			resultado = Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));
			return resultado;
		}		
		
		public static void Main(string[] args)
		{
			double a, b, resultado;
			
			Console.Write("Digite o valor de A: ");
			a = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Digite o valor de B: ");
			b = Convert.ToDouble(Console.ReadLine());
			
			resultado = Calcular(a, b);
			Console.WriteLine("\nResultado: {0:N2}",resultado);
				
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}