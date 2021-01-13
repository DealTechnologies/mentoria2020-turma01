using System;

namespace Classes_Exemplo
{
	class Program
	{
		public static void Main(string[] args)
		{
			Pessoa[] pessoas = new Pessoa[5];
			Pessoa atual;
			
			for(int i=0; i < pessoas.Length; i++)
			{
				atual = new Pessoa();
				Console.WriteLine("Nova pessoa:");
				
				Console.Write(" - Nome: ");
				atual.setNome(Console.ReadLine());
				
				Console.Write(" - Altura: ");
				atual.setAltura(Convert.ToDouble(Console.ReadLine()));
				
				pessoas[i] = atual;				
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}