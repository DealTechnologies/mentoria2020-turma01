using System;

namespace Strings02_E06
{
	class Program
	{
		static void ImprimirComHifen(string s)
		{
			for(int i=0; i<s.Length; i++)
			{
				if(i==s.Length-1)
				{
					Console.Write("{0}",s[i]);
				}
				else
				{
					Console.Write("{0}-",s[i]);
				}
			}
		}
		
		public static void Main(string[] args)
		{
			string s;
			
			Console.Write("Informe uma string: ");
			s = Console.ReadLine();
			
			ImprimirComHifen(s);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}