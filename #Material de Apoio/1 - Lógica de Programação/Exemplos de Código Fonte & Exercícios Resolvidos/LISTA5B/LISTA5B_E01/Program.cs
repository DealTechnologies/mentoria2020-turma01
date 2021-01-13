using System;

namespace LISTA5B_E01
{
	class Program
	{
		static double SalarioLiquido(double salarioB, double valorEx, int numeroEx){
			double salarioL;
			salarioL = (salarioB + (valorEx*numeroEx)) * 0.8;
			return salarioL;
		}
		
		public static void Main(string[] args)
		{
			double salarioB, valorEx, salarioL;
			int numeroEx;
			
			Console.Write("Informe seu saláio: ");
			salarioB = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe o valor de horas extras: ");
			valorEx = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe o número de horas extras:");
			numeroEx = Convert.ToInt32(Console.ReadLine());
			
			salarioL = SalarioLiquido(salarioB,valorEx,numeroEx);
			
			Console.Write("\nO salário líquido é: {0:N2}",salarioL);
			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}