using System;

namespace Aula03
{
	class Program
	{
		public static void Main(string[] args)
		{
			String nome;
			int idade;
			double salario;
			
			Console.WriteLine();
			Console.Write("Digite seu nome   : ");
			nome = Console.ReadLine();
						
			Console.Write("Digite sua idade  : ");
			idade = Convert.ToInt32(Console.ReadLine());
			
			Console.Write("Digite seu salário: ");
			salario = Convert.ToDouble(Console.ReadLine());
			
			Console.WriteLine("\nOlá {0} você tem {1} anos e recebe R$ {2:N2}.",nome,idade,salario);			
			
			Console.Write("\n\n\nPress any key to continue . . . ");
			Console.ReadKey();
		}
	}
}