using System;
using System.Collections.Concurrent;

namespace Strings02_E01
{
	class Program
	{
		public static void Main(string[] args)
		{
			string s;
			int cont=0;
			
			Console.Write("Informe uma string: ");
			s = Console.ReadLine();
			
			for(int i=0; i<s.Length; i++)
			{
				if(s[i]==' ')
				{
					cont++;
				}
			}
			
			Console.WriteLine("\nO número de espaços na string é: {0}",cont);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}