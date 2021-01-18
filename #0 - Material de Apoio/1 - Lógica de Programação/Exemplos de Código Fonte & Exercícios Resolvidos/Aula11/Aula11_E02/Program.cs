using System;

namespace Aula11_E01
{
	class Program
	{
		static double LerTecladoDouble(){
			double x;
			x = Convert.ToDouble(Console.ReadLine());
			return x;
		}
		
		static void Valores(double numero1, double numero2){
			
			Console.WriteLine();
			
			if(numero1>0 && numero2>0){
				Console.WriteLine("Valores válidos");
			}
			else{
				Console.WriteLine("Valores inválidos");
			}
		}
		
		public static void Main(string[] args)
		{
			double numero1, numero2;
			
			Console.Write("Digite o primeiro número: ");
			numero1 = LerTecladoDouble();
			
			Console.Write("Digite o segundo número : ");
			numero2 = LerTecladoDouble();
			
			Valores(numero1, numero2);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}