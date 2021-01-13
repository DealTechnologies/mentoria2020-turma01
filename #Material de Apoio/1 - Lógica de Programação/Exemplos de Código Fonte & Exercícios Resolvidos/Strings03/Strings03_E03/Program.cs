using System;
using System.Text;

namespace Strings03_E03
{
	class Program
	{
		public static void Main(string[] args)
		{
			string s;
			StringBuilder vogais = new StringBuilder();
			StringBuilder consoantes = new StringBuilder();
			
			Console.Write("Informe a string: ");
			s = Console.ReadLine();
			
			for(int i=0; i<s.Length; i++)
			{
				if(s[i]!=' ')
				{
					if(s[i]=='a' || s[i]=='e' || s[i]=='i' || s[i]=='o' || s[i]=='u' || 
				   	   s[i]=='A' || s[i]=='E' || s[i]=='I' || s[i]=='O' || s[i]=='U')
					{
						vogais.Append(s[i]);
					}
					else
					{
						consoantes.Append(s[i]);
					}
				}
			}
			
			Console.WriteLine("\nVogais    : {0}",vogais);
			Console.WriteLine("Consoantes: {0}",consoantes);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}