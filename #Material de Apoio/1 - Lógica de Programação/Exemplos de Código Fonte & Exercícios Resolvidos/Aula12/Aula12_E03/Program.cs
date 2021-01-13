using System;

namespace Aula12_E03
{
	class Program
	{
		public static void Main(string[] args)
		{
			int cont = 0;
			int numero;
			
			Console.Write("Informe um número: ");
			numero = Convert.ToInt32(Console.ReadLine());
			
			for(int i=2; i <= numero/2 && cont==0; i++){
				if(numero % i == 0){
					cont++;
				}
			}
			
			if(cont==0){
				Console.Write("\n{0} é primo", numero);
			}
			else{
				Console.Write("\n{0} não é primo", numero);
			}			
			
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}