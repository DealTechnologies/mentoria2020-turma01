using System;

namespace Aula12_E04
{
	class Program
	{
		public static void Main(string[] args)
		{
			double divida = 10000;
			double aplicacao = 1500;
			int cont = 0;
			
			
			while(divida>=aplicacao){
				divida = divida * 0.025;
				aplicacao = aplicacao * 0.04;
				cont++;
			}
			
			Console.WriteLine("Número de meses necessários: {0}", cont);
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}