using System;

namespace Classes02_Ex02
{
	class Program
	{
		public static void Main(string[] args)
		{
			Pessoa pessoa = new Pessoa();
			
			Console.Write("Informe sua altura: ");
			pessoa.altura = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Informe seu peso: ");
			pessoa.peso = Convert.ToDouble(Console.ReadLine());
			
			Console.WriteLine("\nAltura: {0}", pessoa.altura);
			Console.WriteLine("Peso  : {0}", pessoa.peso);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}