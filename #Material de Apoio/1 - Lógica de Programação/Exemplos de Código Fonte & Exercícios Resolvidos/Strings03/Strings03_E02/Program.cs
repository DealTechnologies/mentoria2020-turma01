using System;
using System.Diagnostics;

namespace Strings03_E02
{
	class Program
	{
		static void Estatistica(string s)
		{			
			int vogais=0, consoantes=0, outros=0;
			
			for(int i=0; i<s.Length; i++)
			{
				if((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z'))
				{
					if(s[i]=='a' || s[i]=='e' || s[i]=='i' || s[i]=='o' || s[i]=='u' || 
					   s[i]=='A' || s[i]=='E' || s[i]=='I' || s[i]=='O' || s[i]=='U')
					{
						vogais++;
					}
					else
					{
						consoantes++;
					}
				}
				else
				{
					outros++;
				}
			}
			Console.Write("\n\nNúmero de vogais: {0}",vogais);
			Console.Write("\nNúmero de consoantes: {0}",consoantes);
			Console.Write("\nNúmero de outros: {0}",outros);
		}
		
		
		public static void Main(string[] args)
		{
			string s;
			
			Console.Write("Informe a string: ");
			s = Console.ReadLine();
			
			Console.Write("\nString: {0}",s);
			
			Estatistica(s);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}