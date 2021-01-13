using System;

namespace Strings02_E04
{
	class Program
	{
		static int NumeroVogais(string s)
		{
			int cont=0;
						
			for(int i=0; i<s.Length; i++)
			{
				switch(s[i])
				{
					case 'a':
					case 'A':
					case 'e':
					case 'E':
					case 'i':
					case 'I':
					case 'o':
					case 'O':
					case 'u':
					case 'U':
						cont++;
						break;				
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
			
			cont = NumeroVogais(s);
			
			Console.WriteLine("\nO número de espaços na string é: {0}",cont);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}