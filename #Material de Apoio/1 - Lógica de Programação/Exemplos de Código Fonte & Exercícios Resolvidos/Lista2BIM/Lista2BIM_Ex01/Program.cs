using System;

namespace Lista2BIM_Ex01
{
	class Program
	{
		static void Inverter(string s)
		{
			Console.Write("\nString modificada: ");
			
			for(int i=0; i < s.Length; i++)
			{
				if(s[i] >= 'a' && s[i] <= 'z')
				{
					Console.Write("{0}", Convert.ToChar(s[i]-32));
				}
				else
				{
					if(s[i] >= 'A' && s[i] <= 'Z')
					{
						Console.Write("{0}", Convert.ToChar(s[i]+32));
					}
					else
					{
						Console.Write("{0}", s[i]);
					}
				}
			}
		}
		
		public static void Main(string[] args)
		{
			string s;
			
			Console.Write("Informe a string: ");
			s = Console.ReadLine();
			
			Inverter(s);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}