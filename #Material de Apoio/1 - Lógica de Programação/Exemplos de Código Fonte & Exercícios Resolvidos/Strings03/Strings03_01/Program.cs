using System;
using System.Text;

namespace Strings03_01
{
	class Program
	{
		static void RemoverEspacos(string s)
		{	
			Console.Write("\nString sem espaços: ");
			
			for(int i=0; i<s.Length; i++)
			{
				if(s[i]!=' ')
				{
					Console.Write("{0}", s[i]);
				}
			}
		}
		
		static string RemoverEspacos2(string s)
		{	
			StringBuilder sb = new StringBuilder();
			
			Console.Write("\nString sem espaços: ");
			
			for(int i=0; i<s.Length; i++)
			{
				if(s[i]!=' ')
				{
					sb.Append(s[i]);
				}
			}
			
			return sb.ToString();
		}
		
		public static void Main(string[] args)
		{
			string s;
			
			Console.Write("Informe a string: ");
			s = Console.ReadLine();
			
			Console.Write("\nString com espaços: {0}",s);
			
			RemoverEspacos(s);
			
			Console.Write("\n\nString com espaços: {0}",s);
			
			Console.Write(RemoverEspacos2(s));
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}