using System;

namespace Aula05
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			double salariofuncionario, salariominimo, numerosalarios;
			
			Console.Write("Informe o salário mínimo:"); salariominimo = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe seu salário:"); salariofuncionario = Convert.ToDouble(Console.ReadLine());
			
			numerosalarios = salariofuncionario / salariominimo;
			
			Console.WriteLine("\nO número de salarios é: {0}", numerosalarios);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey();
		}
	}
}