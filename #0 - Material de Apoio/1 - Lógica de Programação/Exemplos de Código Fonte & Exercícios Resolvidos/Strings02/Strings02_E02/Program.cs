using System;

namespace Strings02_E02
{
	class Program
	{
		static int ContarEspacos(string s)
		{
			int cont=0;
			
			for(int i=0; i<s.Length; i++)
			{
				if(s[i]==' ')
				{
					cont++;
				}
			}
			return cont;
		}
		
		public static void Main(string[] args)
		{
			string s;
			int cont=0;
			
			Console.Write("Informe uma string: ");
			s = Console.ReadLine();
			
			cont = ContarEspacos(s);
			
			Console.WriteLine("\nO número de espaços na string é: {0}",cont);			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}