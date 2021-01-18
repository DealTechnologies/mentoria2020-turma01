using System;

namespace LISTA5A_E07
{
	class Program
	{
		public static void Main(string[] args)
		{
			double chico = 1.5;
			double ze = 1.4;
			int cont = 0;
			
			while(chico>ze){
				chico += 0.02;
				ze += 0.03;
				cont++;
			}
			
			Console.WriteLine("Serão necessários {0} anos", cont);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}