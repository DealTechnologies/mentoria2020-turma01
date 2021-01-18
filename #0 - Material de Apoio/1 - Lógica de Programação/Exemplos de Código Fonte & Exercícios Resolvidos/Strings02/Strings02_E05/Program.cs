using System;

namespace Strings02_E05
{
	class Program
	{
		public static void Main(string[] args)
		{
			string s;
			
			Console.Write("Informe uma string: ");
			s = Console.ReadLine();
			
			Console.WriteLine("\nEntrada: {0}", s);
			
			Console.Write("Saída  : {0}", Convert.ToChar(s[0]-32));
			
			for(int i=1; i<s.Length; i++)
			{
				if(s[i]==' ')
				{
					Console.Write("{0}",s[i]);
					Console.Write("{0}", Convert.ToChar(s[i+1]-32));
					i++;
				}
				else
				{
					Console.Write("{0}",s[i]);
				}
			}
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}