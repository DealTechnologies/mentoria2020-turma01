using System;

namespace Aula02
{
	class Program
	{
		public static void Main(string[] args)
		{
			String nome = "Lucas";
			int idade = 22;
			char sexo = 'M';
			
			Console.WriteLine();
			Console.WriteLine("Meu nome é: {0}",nome);
			Console.WriteLine("Minha idade é: {0}",idade);
			Console.WriteLine("Sou do sexo: {0}",sexo);
			
			Console.Write("\nPress any key to continue . . . ");
			Console.ReadKey();
		}
	}
}