using System;

namespace Strings02_E07
{
	class Program
	{
		static void InverterString(string s)
		{
			Console.Write("\nSaida  : ");
			
			for(int i=s.Length-1; i>=0; i--)
			{
					Console.Write("{0}",s[i]);
			}
		}
		
		public static void Main(string[] args)
		{			
			string s;
			
			Console.Write("Informe uma string: ");
			s = Console.ReadLine();
			
			Console.Write("Entrada: {0}", s);
			
			InverterString(s);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}