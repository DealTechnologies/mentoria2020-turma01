using System;
using System.Xml.Schema;

namespace Strings01_E01
{
	class Program
	{
		public static void Main(string[] args)
		{
			string nome;
			int espacos=0;
			
			Console.Write("Digite seu nome: ");
			nome = Console.ReadLine();
			
			if(nome == "")
			{
				Console.WriteLine("\nNome inválido");
			}
			else
			{
				Console.WriteLine("\nOlá {0}", nome);
				Console.WriteLine("\nPrimeira letra: {0}", nome[0]);
				Console.WriteLine("\nÚltima letra : {0}", nome[nome.Length-1]);
				Console.WriteLine("\nNúmero de letras: {0}", nome.Length);
			}			
			
			for(int i=0; i < nome.Length; i++)
			{
				if(nome[i] == ' '){
					espacos++;
				}
			}
			
			Console.WriteLine("\nNúmero de espaço(s): {0}", espacos);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}