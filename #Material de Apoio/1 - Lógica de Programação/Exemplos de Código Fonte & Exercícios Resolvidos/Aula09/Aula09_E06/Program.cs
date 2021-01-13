using System;

namespace Aula09_E06
{
	class Program
	{
		static double CalculoNotas(double prova1, double prova2){
			double media = 5;
			double prova3;
			prova3 = (media * 4) - 2 - prova2 - prova1;
			return prova3;
		}
		
		public static void Main(string[] args)
		{
			double prova1, prova2, prova3;
			
			Console.Write("Valor prova 1: ");
			prova1 = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Valor prova 2: ");
			prova2 = Convert.ToDouble(Console.ReadLine());
			
			prova3 = CalculoNotas(prova1, prova2);
			
			if(prova3>0){
				Console.WriteLine("\nA nota mínima para a prova 3 é: {0:N2}",prova3);
			}
			else{
				Console.WriteLine("\nO aluno já está aprovado!");
			}			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}